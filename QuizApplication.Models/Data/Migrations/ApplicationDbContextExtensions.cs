using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models.Data.Migrations
{
     public static class ApplicationDbContextExtensions
    {
        public async static Task SeedUsers(UserManager<Person> userMgr)
        {
            //admin
            if (await userMgr.FindByNameAsync("Docent@MCT") == null)
            {
                var user = new Person
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Docent@MCT",
                    Name = "Docent",
                    Email = "Docent@MCT",

                };
                var userResult = await userMgr.CreateAsync(user, "Docent@MCT");
                var roleResult = await userMgr.AddToRoleAsync(user, "Admin");

                if (!userResult.Succeeded || !roleResult.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }

               
            }

        }
    }
}
