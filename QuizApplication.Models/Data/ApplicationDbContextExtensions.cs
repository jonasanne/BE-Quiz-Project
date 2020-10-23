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
                ///STRANGER THINGS QUIZ
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

                },
                //question 6
                new Question 
                {
                    QuestionId = Guid.Parse("33e4a91f-8f9f-4b6f-8c1f-d4dec1905574"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "Who lost by the Demogorgon in DnD in the first episode?",
                },
                //question 7
                new Question 
                {
                    QuestionId = Guid.Parse("0ba805cd-bf9e-4705-9882-3189984a6b88"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "What song do Suzie and Dustin sing together?",
                },
                //question 8
                new Question 
                {
                    QuestionId = Guid.Parse("3b95f28b-01cc-422d-9a63-0f3e8cd868bc"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "How does Mike describe Troy to El when they are walking through the woods?",
                },
                //question 9
                new Question 
                {
                    QuestionId = Guid.Parse("5c407ec1-d022-4b79-95c1-e83d9845a0ec"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "What animal rug does Kline have at the entrance of his home?",
                },
                //question 10
                new Question 
                {
                    QuestionId = Guid.Parse("adc85329-c687-4160-aea7-c047b1e9f9c2"),
                    QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                    QuestionText = "What is Erica a fan of that makes her a nerd?",
                },



                ///HALLOWEEN QUIZ
                //question 1
                new Question
                {
                    QuestionId = Guid.Parse("3b8a5e00-98ca-4006-87db-28c77b20cbfd"),
                    QuizId = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                    QuestionText = "The film Hocus Pocus is about 3 witches resurrected in Salem and stars Sarah Jessica Parker, Kathy Najimy and which other actress known as much for her singing as acting?"

                },
                //question 2
                new Question
                {
                    QuestionId = Guid.Parse("fa8a7d3c-c4e5-4704-a4c3-e21da9a3d7fb"),
                    QuizId = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                    QuestionText = "Who directed the film Halloween from 1978?"

                },
                //question 3
                new Question
                {
                    QuestionId = Guid.Parse("6a9015fb-7bfc-44d1-8e2a-5539d086efef"),
                    QuizId = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                    QuestionText = "Which film has as its main characters, Morticia and Gomez?"

                },
                //question 4
                new Question
                {
                    QuestionId = Guid.Parse("b0e2cc41-6392-487e-9117-e9866472c5f6"),
                    QuizId = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                    QuestionText = "In the film Beetlejuice, which actor played Betelgeuse, known for his comedy and 'dark' roles?"
                },
                //question 5
                new Question
                {
                    QuestionId = Guid.Parse("cafc3286-709b-4ace-ac62-987131f7e258"),
                    QuizId = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                    QuestionText = "In the film of the same name, who is Casper?"
                },
                //question 6
                new Question
                {
                    QuestionId = Guid.Parse("a32cfca6-2e86-4372-a4ce-da28b4119e15"),
                    QuizId = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                    QuestionText = "Also in Casper, was a not very active Monty Python actor, name him."
                },
                //question 7
                new Question
                {
                    QuestionId = Guid.Parse("feced267-3533-408d-ab36-ec21733a93ae"),
                    QuizId = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                    QuestionText = "Who starred as Donnie Darko in the film of the same name?"
                },
                //question 8
                new Question
                {
                    QuestionId = Guid.Parse("14d3f72e-339b-4e6f-b73e-ecdda00dcd4d"),
                    QuizId = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                    QuestionText = "In which film would you find the character Ichabod Crane played by Johnny Depp?"
                },
                //question 9
                new Question
                {
                    QuestionId = Guid.Parse("ee97aa45-3f34-4bcd-a50c-617e9d303888"),
                    QuizId = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                    QuestionText = "In the short film, Michael Jackson: Thriller, who was the narrator, himself the star of many a scary film?"
                },
                //question 10
                new Question
                {
                    QuestionId = Guid.Parse("3f97662e-d27d-495c-aadd-f51d0697f420"),
                    QuizId = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                    QuestionText = "When a teenage girl is possessed by a mysterious entity, two priests are tasked with saving her. What is the film title?"
                },




        };
        private static List<Answer> _Answers = new List<Answer>
        { 
                ///STRANGER THINGS QUIZ
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
                //question 5
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Millie Bobby Brown",
                        QuestionID = Guid.Parse("6569a191-6630-4c46-b490-d352a52b4e80"),
                },
                //question 6
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Will Byers",
                        QuestionID = Guid.Parse("33e4a91f-8f9f-4b6f-8c1f-d4dec1905574"),
                },
                //question 7
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "The Never Ending Story",
                        QuestionID = Guid.Parse("0ba805cd-bf9e-4705-9882-3189984a6b88"),
                },
                //question 8
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Mouth-breather",
                        QuestionID = Guid.Parse("3b95f28b-01cc-422d-9a63-0f3e8cd868bc"),
                },
                //question 9
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Zebra",
                        QuestionID = Guid.Parse("5c407ec1-d022-4b79-95c1-e83d9845a0ec"),
                },
                //question 10
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "My Little Pony",
                        QuestionID = Guid.Parse("adc85329-c687-4160-aea7-c047b1e9f9c2"),
                },



                ///HALLOWEEN QUIZ
                //question 1               
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Bette Midler",
                        QuestionID = Guid.Parse("3b8a5e00-98ca-4006-87db-28c77b20cbfd")
                    },  
                //question 2               
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "John Carpenter",
                        QuestionID = Guid.Parse("fa8a7d3c-c4e5-4704-a4c3-e21da9a3d7fb"),
                    },
                //question 3             
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "The Addams Family",
                        QuestionID = Guid.Parse("6a9015fb-7bfc-44d1-8e2a-5539d086efef"),
                    },
                //question 4            
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Michael Keaton",
                        QuestionID = Guid.Parse("b0e2cc41-6392-487e-9117-e9866472c5f6"),
                    },
                //question 5            
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "The 'Friendly' ghost",
                        QuestionID = Guid.Parse("cafc3286-709b-4ace-ac62-987131f7e258"),
                    },
                //question 6            
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Eric Idle",
                        QuestionID = Guid.Parse("a32cfca6-2e86-4372-a4ce-da28b4119e15"),
                    },
                //question 7           
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Jake Gyllenhaal",
                        QuestionID = Guid.Parse("feced267-3533-408d-ab36-ec21733a93ae"),
                    },
                //question 8           
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Sleepy Hollow",
                        QuestionID = Guid.Parse("14d3f72e-339b-4e6f-b73e-ecdda00dcd4d"),
                    },
                //question 9          
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "Vincent Price",
                        QuestionID = Guid.Parse("ee97aa45-3f34-4bcd-a50c-617e9d303888"),
                    },
                //question 10           
                new Answer
                    {
                        AnswerID = Guid.NewGuid(),
                        AnswerText = "The Exorcist",
                        QuestionID = Guid.Parse("3f97662e-d27d-495c-aadd-f51d0697f420"),
                    }
        };
        private static List<Choice> _Choices = new List<Choice> { 
                ///STRANGER THINGS
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

                },
                //question 6
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Jonathan Byers",
                    QuestionID = Guid.Parse("33e4a91f-8f9f-4b6f-8c1f-d4dec1905574"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Mike Wheeler",
                    QuestionID = Guid.Parse("33e4a91f-8f9f-4b6f-8c1f-d4dec1905574"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Lucas Sinclair",
                    QuestionID = Guid.Parse("33e4a91f-8f9f-4b6f-8c1f-d4dec1905574"),

                },
                //question 7
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Lost in Your Eyes",
                    QuestionID = Guid.Parse("0ba805cd-bf9e-4705-9882-3189984a6b88"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "I wanna Dance With Someone",
                    QuestionID = Guid.Parse("0ba805cd-bf9e-4705-9882-3189984a6b88"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Never Gonna Give You Up",
                    QuestionID = Guid.Parse("0ba805cd-bf9e-4705-9882-3189984a6b88"),

                },
                //question 8
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Der-brain",
                    QuestionID = Guid.Parse("3b95f28b-01cc-422d-9a63-0f3e8cd868bc"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Dirtbag",
                    QuestionID = Guid.Parse("3b95f28b-01cc-422d-9a63-0f3e8cd868bc"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Doofus",
                    QuestionID = Guid.Parse("3b95f28b-01cc-422d-9a63-0f3e8cd868bc"),

                },
                //question 9
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Lion",
                    QuestionID = Guid.Parse("5c407ec1-d022-4b79-95c1-e83d9845a0ec"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Wolf",
                    QuestionID = Guid.Parse("5c407ec1-d022-4b79-95c1-e83d9845a0ec"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Tiger",
                    QuestionID = Guid.Parse("5c407ec1-d022-4b79-95c1-e83d9845a0ec"),
                },
                //question 10
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Rainbow Brite",
                    QuestionID = Guid.Parse("adc85329-c687-4160-aea7-c047b1e9f9c2"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The Care Bears",
                    QuestionID = Guid.Parse("adc85329-c687-4160-aea7-c047b1e9f9c2"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "MoonDreamers",
                    QuestionID = Guid.Parse("adc85329-c687-4160-aea7-c047b1e9f9c2"),
                },

                ///HALLOWEEN 
                //question 1
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Scarlett Johansson",
                    QuestionID = Guid.Parse("3b8a5e00-98ca-4006-87db-28c77b20cbfd"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Jennifer Lawrence",
                    QuestionID = Guid.Parse("3b8a5e00-98ca-4006-87db-28c77b20cbfd"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Meryl Streep",
                    QuestionID = Guid.Parse("3b8a5e00-98ca-4006-87db-28c77b20cbfd"),
                },

                //question 2
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Jim Abrahams",
                    QuestionID = Guid.Parse("fa8a7d3c-c4e5-4704-a4c3-e21da9a3d7fb"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Ivan Abramson",
                    QuestionID = Guid.Parse("fa8a7d3c-c4e5-4704-a4c3-e21da9a3d7fb"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Maren Ade",
                    QuestionID = Guid.Parse("fa8a7d3c-c4e5-4704-a4c3-e21da9a3d7fb"),
                },

                //question 3
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Beetlejuice",
                    QuestionID = Guid.Parse("6a9015fb-7bfc-44d1-8e2a-5539d086efef"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Ghostbusters",
                    QuestionID = Guid.Parse("6a9015fb-7bfc-44d1-8e2a-5539d086efef"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The Monster Squad",
                    QuestionID = Guid.Parse("6a9015fb-7bfc-44d1-8e2a-5539d086efef"),
                },

                //question 4
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Leonardo DiCaprio",
                    QuestionID = Guid.Parse("b0e2cc41-6392-487e-9117-e9866472c5f6"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Johnny Depp",
                    QuestionID = Guid.Parse("b0e2cc41-6392-487e-9117-e9866472c5f6"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Christian Bale",
                    QuestionID = Guid.Parse("b0e2cc41-6392-487e-9117-e9866472c5f6"),
                },

                //question 5
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The angry ghost",
                    QuestionID = Guid.Parse("cafc3286-709b-4ace-ac62-987131f7e258"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The Dog",
                    QuestionID = Guid.Parse("cafc3286-709b-4ace-ac62-987131f7e258"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The Turtle",
                    QuestionID = Guid.Parse("cafc3286-709b-4ace-ac62-987131f7e258"),
                },

                //question 6
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Graham Chapman",
                    QuestionID = Guid.Parse("a32cfca6-2e86-4372-a4ce-da28b4119e15"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Terry Jones",
                    QuestionID = Guid.Parse("a32cfca6-2e86-4372-a4ce-da28b4119e15"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "John Cleese",
                    QuestionID = Guid.Parse("a32cfca6-2e86-4372-a4ce-da28b4119e15"),
                },

                //question 7
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Zac Efron",
                    QuestionID = Guid.Parse("feced267-3533-408d-ab36-ec21733a93ae"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Taylor Lautner",
                    QuestionID = Guid.Parse("feced267-3533-408d-ab36-ec21733a93ae"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Asher Monroe",
                    QuestionID = Guid.Parse("feced267-3533-408d-ab36-ec21733a93ae"),
                },

                //question 8
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Edwar Scissorhands",
                    QuestionID = Guid.Parse("14d3f72e-339b-4e6f-b73e-ecdda00dcd4d"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Sweeney Todd",
                    QuestionID = Guid.Parse("14d3f72e-339b-4e6f-b73e-ecdda00dcd4d"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The Lone Ranger",
                    QuestionID = Guid.Parse("14d3f72e-339b-4e6f-b73e-ecdda00dcd4d"),
                },

                //question 9
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Huck Finn",
                    QuestionID = Guid.Parse("ee97aa45-3f34-4bcd-a50c-617e9d303888"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Holden Caulfield",
                    QuestionID = Guid.Parse("ee97aa45-3f34-4bcd-a50c-617e9d303888"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Denis Johnson",
                    QuestionID = Guid.Parse("ee97aa45-3f34-4bcd-a50c-617e9d303888"),
                },

                //question 10
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The Rite",
                    QuestionID = Guid.Parse("3f97662e-d27d-495c-aadd-f51d0697f420"),
                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "The Devil Inside",
                    QuestionID = Guid.Parse("3f97662e-d27d-495c-aadd-f51d0697f420"),

                },
                new Choice
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = "Deliver us from Evil",
                    QuestionID = Guid.Parse("3f97662e-d27d-495c-aadd-f51d0697f420"),
                },

        };
        private static List<Score> _Scores = new List<Score>
        {
            new Score()
            {
                DateOfScore = DateTime.Now,
                ScoreId = Guid.NewGuid(),
                ScorePoints = 70,
                UserId = Guid.Parse("284243cb-2c97-43dc-bb41-ea429ba69c58"),
                QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158")
            },
            new Score()
            {
                DateOfScore = DateTime.Now,
                ScoreId = Guid.NewGuid(),
                ScorePoints = 45,
                UserId = Guid.Parse("284243cb-2c97-43dc-bb41-ea429ba69c58"),
                QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158")


            },
            new Score()
            {
                DateOfScore = DateTime.Now,
                ScoreId = Guid.NewGuid(),
                ScorePoints = 15,
                UserId = Guid.Parse("284243cb-2c97-43dc-bb41-ea429ba69c58"),
                QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158")


            },
            new Score()
            {
                DateOfScore = DateTime.Now,
                ScoreId = Guid.NewGuid(),
                ScorePoints = 85,
                UserId = Guid.Parse("284243cb-2c97-43dc-bb41-ea429ba69c58"),
                QuizId = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158")


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
                        Id = "284243cb-2c97-43dc-bb41-ea429ba69c58",
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

                    Quiz quizStrangerThings = new Quiz
                    {
                        QuizName = "Stranger things",
                        Difficulty = (Quiz.DifficultyType)(1) ,
                        QuizID = Guid.Parse("c8f37618-6863-4a79-92bd-4d03dde35158"),
                        SubjectId = Guid.Parse("51a21b7f-557c-4948-9a81-e60de94adad0"),
                        ImgUrl= "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/Stranger_Things_logo.png/266px-Stranger_Things_logo.png",
                        Description = "Ready to see if you are a real stranger things fan?"
                    };
                    Quiz quizHalloween = new Quiz
                    {
                        QuizName = "Halloween",
                        Difficulty = (Quiz.DifficultyType)(2),
                        QuizID = Guid.Parse("6ddc2897-71f0-47f6-a94a-b473c675f131"),
                        SubjectId = Guid.Parse("51a21b7f-557c-4948-9a81-e60de94adad0"),
                        ImgUrl= "https://www.leukvoorkids.nl/wp-content/uploads/wallpaper-halloween-tafereel.jpg",
                        Description = "Ready to see if you are a real Halloween fan?"
                    };
                    await context.Quizzes.AddAsync(quizStrangerThings);
                    await context.Quizzes.AddAsync(quizHalloween);
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
                

                //add scores
                if (!context.Scores.Any())
                {
                    foreach (Score a in _Scores)
                    {
                        if (!context.Scores.Any(s => s.ScoreId == a.ScoreId))
                        {
                            await context.Scores.AddAsync(a);
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

        

