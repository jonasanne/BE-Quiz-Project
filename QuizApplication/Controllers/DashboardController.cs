using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;
using QuizApplication.Models.Repositories;
using QuizApplication.Repositories;
using QuizApplication.WebApp.ViewModels;

namespace QuizApplication.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IQuestionRepo questionRepo;
        private readonly IQuizRepo quizRepo;
        private readonly IAnswerRepo answerRepo;
        private readonly IChoiceRepo choiceRepo;
        private readonly ISubjectRepo subjectRepo;

        //constructor
        public DashboardController(IQuestionRepo questionRepo, IQuizRepo quizRepo, IAnswerRepo answerRepo, IChoiceRepo choiceRepo, ISubjectRepo subjectRepo)
        {
            this.questionRepo = questionRepo;
            this.quizRepo = quizRepo;
            this.answerRepo = answerRepo;
            this.choiceRepo = choiceRepo;
            this.subjectRepo = subjectRepo;
        }

        // GET: Index
        public async Task<ActionResult> Index()
        {
            return RedirectToAction(nameof(Subjects));
        }

        ////            SUBJECTS          ////

        // GET: subjects
        public async Task<ActionResult> Subjects()
        {
            var subjects = await subjectRepo.GetSubjectsAsync();
            return View(subjects);
        }

        // GET: edit
        public async Task<ActionResult> EditSubjectAsync(Guid Id)
        {
            if (Id == null)
                return Redirect("/Error/400");

            var Subject = await subjectRepo.GetsubjectById(Id);
            if (Subject == null)
            {
                ModelState.AddModelError(String.Empty, "Not Found.");
            }
            return View(Subject);
        }
        // POST: edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditsubjectAsync(Guid Id, IFormCollection collection, Subject subject)
        {
            try
            {
                // TODO: Add update logic here
                if (Id == null)
                    return BadRequest();

                var result = await subjectRepo.Update(subject);
                if (result == null)
                    return Redirect("/Error/400");


                return RedirectToAction(nameof(Subjects));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"update error. {ex.Message}" );
                ModelState.AddModelError("", "Update actie mislukt." + ex.InnerException.Message);
                return View(subject);
            }
        }


        //GET : delete
        public async Task<ActionResult> DeleteSubjectAsync(Guid Id)
        {

            if (Id == null)
                return Redirect("/Error/400");

            var Subject = await subjectRepo.GetsubjectById(Id);
            if (Subject == null)
            {
                ModelState.AddModelError(String.Empty, "Not Found.");
            }
            return View(Subject);
        }
        // POST: delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteSubjectAsync(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (id == null)
                    throw new Exception("Bad Delete Request");
                await subjectRepo.DeleteSubject(id);
                return RedirectToAction(nameof(Subjects));
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Delete error. {ex.Message}");
                ModelState.AddModelError(String.Empty, "Delete failed");
                return View();
            }
        }

        //GET : create
        public ActionResult CreateSubject()
        {
            return View();
        }
        // POST: Quiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateSubject(IFormCollection collection, Subject subject)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Validation Error");
                }
                Subject result = await subjectRepo.AddSubject(subject);

                if (result == null)
                {
                    throw new Exception("Invalid Entry");
                }
                return RedirectToAction(nameof(Subjects));

            }
            catch (Exception ex)
            {

                Debug.WriteLine("unable to create" + ex.Message);
                ModelState.AddModelError("", "Create mislukt." + ex.Message);
                return View(subject);
            }
        }

        ////            QUIZZES          ////
        // GET: Quizzes
        public async Task<ActionResult> Quizzes()
        {
            var quizzes = await quizRepo.GetQuizzesAsync();
            return View(quizzes);
        }
        // GET: edit
        public async Task<ActionResult> EditQuizAsync(Guid Id)
        {
            try
            {
                if(Id == null)
                    return Redirect("/Error/400");

                Quiz quiz = await quizRepo.GetQuizByIdAsync(Id);
                var subjects = await subjectRepo.GetSubjectsAsync();
                AddQuiz_VM vm = new AddQuiz_VM()
                {
                    ImgUrl = quiz.ImgUrl,
                    QuizID = quiz.QuizID,
                    Description = quiz.Description,
                    Difficulty = quiz.Difficulty,
                    QuizName = quiz.QuizName,
                    SubjectId = quiz.SubjectId,
                    Subjects = new List<Subject>(),

                };
                foreach (var item in subjects)
                {
                    vm.Subjects.Add(item);
                }
            return View(vm);
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"update error. {ex.Message}");
                ModelState.AddModelError("", "Update actie mislukt." + ex.InnerException.Message);
                return RedirectToAction(nameof(Quizzes));


            }
        }
        // POST: edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditQuizAsync(Guid Id, IFormCollection collection, AddQuiz_VM vm)
        {
            try
            {
                // TODO: Add update logic here
                if (Id == null)
                    return BadRequest();

                Quiz quiz = new Quiz()
                {
                    SubjectId = vm.SubjectId,
                    Description = vm.Description,
                    Difficulty = vm.Difficulty,
                    ImgUrl = vm.ImgUrl,
                    QuizID = vm.QuizID,
                    QuizName = vm.QuizName
                };

                var result = await quizRepo.Update(quiz);
                if (result == null)
                    return Redirect("/Error/400");


                return RedirectToAction(nameof(Quizzes));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"update error. {ex.Message}");
                ModelState.AddModelError("", "Update actie mislukt." + ex.InnerException.Message);
                return View(vm);
            }
        }

        public async Task<ActionResult> DetailQuizAsync(Guid id)
        {
            var quiz = await quizRepo.GetQuizByIdAsync(id);
            var subject = await subjectRepo.GetsubjectById(quiz.SubjectId);
            AddQuiz_VM vm = new AddQuiz_VM()
            {
                QuizID = quiz.QuizID,
                Description = quiz.Description,
                Difficulty = quiz.Difficulty,
                ImgUrl = quiz.ImgUrl,
                QuizName = quiz.QuizName,
                SubjectName = subject.SubjectName
            };
            return View(vm);
        }

        //GET : create
        public async Task<ActionResult> CreateQuizAsync()
        {
            try
            {
                AddQuiz_VM addQuiz = new AddQuiz_VM()
                {
                    Subjects = new List<Subject>()


                };
                var subjects = await subjectRepo.GetSubjectsAsync();
                foreach (var item in subjects)
                {
                    addQuiz.Subjects.Add(item);
                }


                return View(addQuiz);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
        // POST: Quiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateQuiz(IFormCollection collection, AddQuiz_VM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Validation Error");
                }

                Quiz quiz = new Quiz()
                {
                    SubjectId = vm.SubjectId,
                    QuizName = vm.QuizName,
                    QuizID = Guid.NewGuid(),
                    ImgUrl = vm.ImgUrl,
                    Difficulty = vm.Difficulty,
                    Description = vm.Description
                };
                Quiz result = await quizRepo.AddQuiz(quiz);
                if (result == null)
                {
                    throw new Exception("Invalid Entry");
                }


                return RedirectToAction(nameof(Quizzes));

            }
            catch (Exception ex)
            {

                Debug.WriteLine("unable to create" + ex.Message);
                ModelState.AddModelError("", "Create mislukt." + ex.Message);
                return View(vm);
            }
        }

        ////            Questions          ////




        // GET: Dashboard/Questions/id
        public async Task<ActionResult> Questions(Guid Id)
        {
            if (Id == null)
                return Redirect("/Error/400");
            var questions = await questionRepo.GetQuestionsByQuizAsync(Id);
            return View(questions);
        }



        //GET /dashboard/Question/Create
        public async Task<ActionResult> CreateQuestionAsync(Guid Id)
        {
            try
            {
                if (Id == null)
                    return Redirect("/Error/400");

                Quiz quiz = await quizRepo.GetQuizByIdAsync(Id);
                ViewBag.Quiz = quiz;
                AddQuestion_VM vm = new AddQuestion_VM();
                vm.QuizId = quiz.QuizID;
                return View(vm);
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                return Redirect("/Error/400");
            }

        }
        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuestionAsync(IFormCollection collection, AddQuestion_VM vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Validation Error");
                }
                //add question
                Question question = new Question()
                {
                    QuizId = vm.QuizId,
                    QuestionId = Guid.NewGuid(),
                    QuestionText = vm.QuestionText
                };

                var result = questionRepo.AddQuestion(question);
                if (result == null)
                {
                    return Redirect("/Error/400");
                }

                //add answer
                Answer answer = new Answer()
                {
                    AnswerID = Guid.NewGuid(),
                    AnswerText = vm.QuestionAnswer,
                    QuestionID = question.QuestionId
                };
                var resultAnswer = answerRepo.AddAnswer(answer);
                if (resultAnswer == null)
                    return Redirect("/Error/400");


                //add choice 1
                Choice choiceA = new Choice()
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = vm.QuestionChoiceA,
                    QuestionID = question.QuestionId
                };
                var resultChoiceA = choiceRepo.AddChoice(choiceA);
                if (resultChoiceA == null)
                    return Redirect("/Error/400");
                //add choice 2
                Choice choiceB = new Choice()
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = vm.QuestionChoiceB,
                    QuestionID = question.QuestionId
                };
                var resultChoiceB = choiceRepo.AddChoice(choiceB);
                if (resultChoiceB == null)
                    return Redirect("/Error/400");
                //add choice 2
                Choice choiceC = new Choice()
                {
                    ChoiceID = Guid.NewGuid(),
                    ChoiceText = vm.QuestionChoiceC,
                    QuestionID = question.QuestionId
                };
                var resultChoiceC = choiceRepo.AddChoice(choiceC);
                if (resultChoiceC == null)
                    return Redirect("/Error/400");
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {

                Debug.WriteLine("unable to create" + ex.Message);
                ModelState.AddModelError("", "Create mislukt." + ex.Message);
                return View(vm);
            }
        }










    }
}