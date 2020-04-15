using Microsoft.AspNetCore.Identity;
using QuizApplication.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models.Data
{
    public static class ApplicationDbContextExtensions
    {
        private static List<Question> _questions = new List<Question> {
                //question 1
                new Question
                {
                    QuestionId = Guid.Parse("b3844c42-71a6-4d2a-a847-1b32598479c8"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "What is the name for the parallel universe experienced in series 1?",

                },
                //question 2
                new Question
                {
                    QuestionId = Guid.Parse("ec5e0d4d-bb31-4f36-9cc7-d0f2a5be4ab8"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "The fauna and flora in the parallel dimension are linked together in a hive mind by who?",

                },
                //question 3
                new Question
                {
                    QuestionId = Guid.Parse("a2e0a9ee-6356-45ef-aed4-579ab639fdb8"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "Also known as the Monster, what is the name of the predatory humanoid creature that enters into and terrorises Hawkins in 1983?",

                },
                //question 4
                new Question
                {
                    QuestionId = Guid.Parse("01ba71cf-9992-4c11-b339-c8e00cb271b5"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "Which brothers created the Stranger Things series?",

                },
                //question 5
                new Question
                {
                    QuestionId = Guid.Parse("6569a191-6630-4c46-b490-d352a52b4e80"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "Who plays the part of Eleven?",

                }
        };
        private static List<Choice> _Choices = new List<Choice> { 
                //question 1
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Hell",
                    QuestionID = Guid.Parse("b3844c42-71a6-4d2a-a847-1b32598479c8")
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The left side up",
                    QuestionID = Guid.Parse("b3844c42-71a6-4d2a-a847-1b32598479c8")

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Dark side of the moon",
                    QuestionID = Guid.Parse("b3844c42-71a6-4d2a-a847-1b32598479c8")

                },
                //question 2
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The devil",
                    QuestionID = Guid.Parse("ec5e0d4d-bb31-4f36-9cc7-d0f2a5be4ab8")

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "fluffy monster",
                    QuestionID = Guid.Parse("ec5e0d4d-bb31-4f36-9cc7-d0f2a5be4ab8")

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Virago the destroyer",
                    QuestionID = Guid.Parse("ec5e0d4d-bb31-4f36-9cc7-d0f2a5be4ab8")

                },
                //question 3
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Demodoggie",
                    QuestionID = Guid.Parse("a2e0a9ee-6356-45ef-aed4-579ab639fdb8"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Orange monster",
                    QuestionID = Guid.Parse("a2e0a9ee-6356-45ef-aed4-579ab639fdb8"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The devil",
                    QuestionID = Guid.Parse("a2e0a9ee-6356-45ef-aed4-579ab639fdb8"),

                },
                //question 4
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The Marx Brothers",
                    QuestionID = Guid.Parse("01ba71cf-9992-4c11-b339-c8e00cb271b5"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The Sullivan Brothers",
                    QuestionID = Guid.Parse("01ba71cf-9992-4c11-b339-c8e00cb271b5"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The Jonas Brothers",
                    QuestionID = Guid.Parse("01ba71cf-9992-4c11-b339-c8e00cb271b5"),

                },
                //question 5
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Chloë Grace Moretz",
                    QuestionID = Guid.Parse("6569a191-6630-4c46-b490-d352a52b4e80"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Olivia Holt",
                    QuestionID = Guid.Parse("6569a191-6630-4c46-b490-d352a52b4e80"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Dakota Fanning",
                    QuestionID = Guid.Parse("6569a191-6630-4c46-b490-d352a52b4e80"),

                }


        };
        private static List<Answer> _Answers = new List<Answer>
        { 
                //question 1    
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "The Upside Down",
                        QuestionID = Guid.Parse("b3844c42-71a6-4d2a-a847-1b32598479c8")
                    },
                //question 2
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Mind Flayer",
                        QuestionID = Guid.Parse("ec5e0d4d-bb31-4f36-9cc7-d0f2a5be4ab8")
                    },
                //question 3
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Demogorgon",
                        QuestionID = Guid.Parse("a2e0a9ee-6356-45ef-aed4-579ab639fdb8"),
                },
                //question 4
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Duffer Brothers",
                        QuestionID = Guid.Parse("01ba71cf-9992-4c11-b339-c8e00cb271b5"),
                },
                //question 4
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Millie Bobby Brown",
                        QuestionID = Guid.Parse("6569a191-6630-4c46-b490-d352a52b4e80"),
                }

        };



        public async static Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
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
        public async static Task SeedUsersAsync(UserManager<IdentityUser> userManager)
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

        public async static Task SeedData(this ApplicationDbContext context)
        {
            try
            {
                //add subjects
                if (!context.Subjects.Any())
                {
                    Debug.WriteLine("Seeding Subject");
                    Subject subject = new Subject()
                    {
                        SubjectId = Guid.Parse("51a21b7f-557c-4948-9a81-e60de94adad0"),
                        SubjectName = "Movies",
                        Description = "Want to test your knowledge of movies?"
                    };
                    await context.Subjects.AddAsync(subject);
                    await context.SaveChangesAsync();
                };
                //add quizzes
                if (!context.Quizzes.Any())
                {
                    Debug.WriteLine("Seeding Quiz");

                    Quiz quiz = new Quiz
                    {
                        QuizName = "Stranger things",
                        Difficulty = 2,
                        QuizID = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                        SubjectId = Guid.Parse("51a21b7f-557c-4948-9a81-e60de94adad0"),
                        ImgUrl= "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/Stranger_Things_logo.png/266px-Stranger_Things_logo.png",
                        Description = "Ready to see if you are a real stranger things fan?"
                    };
                    await context.Quizzes.AddAsync(quiz);
                    await context.SaveChangesAsync();
                }
                //add questions
                if (!context.Questions.Any())
                {
                    foreach (Question q in _questions)
                    {
                        if (!context.Questions.Any(question => question.QuestionId == q.QuestionId))
                        {
                            await context.Questions.AddAsync(q);
                        }
                        await context.SaveChangesAsync();
                    }
                }
                //add choices
                if (!context.Choices.Any())
                {
                    foreach (Choice c in _Choices)
                    {
                        if (!context.Choices.Any(question => question.ChoiceID == c.ChoiceID))
                        {
                            await context.Choices.AddAsync(c);
                        }
                        await context.SaveChangesAsync();
                    }
                }
                //add answers
                if (!context.Answers.Any())
                {
                    foreach (Answer a in _Answers)
                    {
                        if (!context.Answers.Any(question => question.AnswerID == a.AnswerID))
                        {
                            await context.Answers.AddAsync(a);
                        }
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw new InvalidOperationException("Failed to build data");
            }


        }
    }
}

        

