using Microsoft.AspNetCore.Identity;
using QuizApplication.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models.Data
{
    public static class ApplicationDbContextExtensions
    {
        public static void Seed(ApplicationDbContext context)
        {

        }
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            IdentityResult roleResult;
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }

            }
        }  
        public static async Task SeedUsersAsync(UserManager<IdentityUser> userManager)
        {
            try
            {
                //admin maken
                if (await userManager.FindByNameAsync("Docent@MCT") == null)
                {
                    var user = new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "Docent@MCT",
                        Email = "Docent@MCT"

                    };
                    var userResult = await userManager.CreateAsync(user, "Docent@1");
                    var roleResult = await userManager.AddToRoleAsync(user, "Admin");

                    if (!userResult.Succeeded || !roleResult.Succeeded)
                    {
                        throw new InvalidOperationException("Failed to build user and roles");
                    }

                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
            }


            }
        }
    }
