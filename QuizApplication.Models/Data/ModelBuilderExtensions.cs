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

                new Quiz
                {
                    QuizName = "Stranger things",
                    Difficulty = 2,
                    QuizID = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158")
                }
                ) ;
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = Guid.Parse("b3844c42-71a6-4d2a-a847-1b32598479c8"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "what is the other dimension called in the tv show : stranger things?",
                    
                }
                );
            modelBuilder.Entity<Answer>().HasData(
                    new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = " The Upside Down",
                        QuestionID = Guid.Parse("b3844c42-71a6-4d2a-a847-1b32598479c8")
                    }
                ) ;
            
        }
    }
}
