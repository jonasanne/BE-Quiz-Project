using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;
using QuizApplication.Repositories;
using QuizApplication.WebApp.ViewModels;

namespace QuizApplication.WebApp.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepo questionRepo;
        private readonly IQuizRepo quizRepo;
        private readonly IAnswerRepo answerRepo;
        private readonly IChoiceRepo choiceRepo;

        public QuestionController(IQuestionRepo questionRepo, IQuizRepo quizRepo, IAnswerRepo answerRepo, IChoiceRepo choiceRepo)
        {
            this.questionRepo = questionRepo;
            this.quizRepo = quizRepo;
            this.answerRepo = answerRepo;
            this.choiceRepo = choiceRepo;
        }
        // GET: Question
        public async Task<ActionResult> IndexAsync( Guid Id)
        {
            var questions = await questionRepo.GetQuestionsByQuizAsync(Id);
            return View(questions);
        }

        // GET: Question/Details/5
        public async Task<ActionResult> DetailsAsync(Guid id)
        {
            var question = await questionRepo.GetQuestionByIdAsync(id);
            return View(question);
        }

        // GET: Question/Create
        public async Task<ActionResult> Create(Guid Id)
        {
            Quiz quiz = await quizRepo.GetQuizByIdAsync(Id);
            ViewBag.Quiz = quiz;
            AddQuestion_VM vm = new AddQuestion_VM();
            vm.QuizId = quiz.QuizID;
            return View(vm);
        }

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> CreateAsync(IFormCollection collection, AddQuestion_VM vm )
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

        // GET: Question/Edit/5
        public async Task<ActionResult> EditAsync(Guid id)
        {
            if (id == null)
                return Redirect("/Error/400");

            var question = await questionRepo.GetQuestionByIdAsync(id);
            if (question == null)
            {
                ModelState.AddModelError(String.Empty, "Not Found.");
            }
            return View(question);
        }

        // POST: Question/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Guid id, IFormCollection collection, Question question)
        {
            try
            {
                // TODO: Add update logic here
                if (id == null)
                    return BadRequest();

                var result = await questionRepo.Update(question);
                if (result == null)
                    return Redirect("/Error/400");


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Update actie mislukt." + ex.InnerException.Message);
                return View(question);
            }
        }

        // GET: Question/Delete/5
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var question = await questionRepo.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (id == null)
                    throw new Exception("Bad Delete Request");
                await questionRepo.DeleteQuestion(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Delete error. " + ex.Message);
                ModelState.AddModelError(String.Empty, "Delete failed");
                return View();
            }
        }
    }
}