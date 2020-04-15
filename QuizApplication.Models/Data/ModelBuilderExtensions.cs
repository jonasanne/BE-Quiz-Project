using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApplication.Models.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Quiz>().HasData(
                //stranger things quiz
                new Quiz
                {
                    QuizName = "Stranger things",
                    Difficulty = 2,
                    QuizID = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    SubjectId = Guid.Parse("51a21b7f-557c-4948-9a81-e60de94adad0")
                }
                );




            
        }
    }
}
