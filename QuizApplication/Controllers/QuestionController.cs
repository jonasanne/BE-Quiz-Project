using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;
using QuizApplication.Repositories;

namespace QuizApplication.WebApp.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepo questionRepo;

        public QuestionController(IQuestionRepo questionRepo)
        {
            this.questionRepo = questionRepo;
        }
        // GET: Question
        public async Task<ActionResult> IndexAsync()
        {
            var questions = await questionRepo.GetQuestionsAsync();
            return View(questions);
        }

        // GET: Question/Details/5
        public async Task<ActionResult> DetailsAsync(Guid id)
        {
            var question = await questionRepo.GetQuestionByIdAsync(id);
            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IFormCollection collection, Question question)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Validation Error");
                }
                Question result = await questionRepo.AddQuestion(question);

                if (result == null)
                {
                    throw new Exception("Invalid Entry");
                }
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {

                Debug.WriteLine("unable to create" + ex.Message);
                ModelState.AddModelError("", "Create mislukt." + ex.Message);
                return View(question);
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