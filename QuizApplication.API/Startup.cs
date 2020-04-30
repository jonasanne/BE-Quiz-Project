using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QuizApplication.Data;



//toe te voegen
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies; //Cookie Authenticatie
using System.Text; //nodig voor Byte encoding van de keys
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using QuizApplication.Models.Data;
using QuizApplication.Repositories;
using QuizApplication.Models.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer; //Token Authenticatie
using Microsoft.IdentityModel.Tokens; //Token Authenticatie

namespace QuizApplication.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //setup
            services.AddControllers();

            //loophandling verminderen
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.RespectBrowserAcceptHeader = true;
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //registratie (context en identity)
            //context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //identity (NIET AddDefaultIdentity())

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            //cookie auth
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                options =>
                {
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Events =
                    new CookieAuthenticationEvents()
                    {
                        OnRedirectToLogin = (ctx) =>
                         {
                             if (ctx
                             .Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                             {
                                 ctx.Response.StatusCode = 401;
                                 ctx.Response.WriteAsync("{\"error\": " + ctx.Response.StatusCode + " Geen toegang}");
                             }
                             return Task.CompletedTask;
                         }
                    };
                });


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))

                    };
                    options.SaveToken = false;
                    options.RequireHttpsMetadata = false;
                });

            //registreren van repos
            services.AddScoped<IQuizRepo, QuizRepo>();
            services.AddScoped<ISubjectRepo, SubjectRepo>();
            services.AddScoped<IScoreRepo, ScoreRepo>();

            //open API documentatie
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Security_API", Version = "v1.0" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorizatoin header using the Bearer scheme.",

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            //hsts & HTTPS-redirectoin in production met opties
            if (!env.IsDevelopment())
            {
                services.AddHttpsRedirection(options =>
                {
                    options.HttpsPort = 443;
                });
                services.AddHsts(options =>
                {
                    options.MaxAge = TimeSpan.FromDays(40); // default 30
                });
            }


            //registreren van cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }
            );





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //configuratie openAPI documentatie
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Security_API v1.0");


            });

            //cors opzetten
            app.UseCors("CorsPolicy");

            app.UseMvc();
            //Seeder voor Identity & Data ---------------------------------------------------------
            //1. roleManager en userManager ophalen.
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //2. Seeder oproepen
            context.SeedData().Wait(); //Educations , oproepen als extensiemethode
            ApplicationDbContextExtensions.SeedRolesAsync(roleManager).Wait();  //zonder wait breekt de Task
            ApplicationDbContextExtensions.SeedUsersAsync(userManager).Wait();

        }
    }
}
