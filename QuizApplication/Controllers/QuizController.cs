using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;
using QuizApplication.Repositories;

namespace QuizApplication.WebApp.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizRepo quizRepo;

        public QuizController(IQuizRepo quizRepo)
        {
            this.quizRepo = quizRepo;
        }
        // GET: Quiz
        public async Task<ActionResult> IndexAsync()
        {
            var quizzes = await quizRepo.GetQuizzesAsync();
            return View(quizzes);
        }
        // GET: Quiz/Details/5
        public async Task<ActionResult> DetailsAsync(Guid id)
        {
            var quiz = await quizRepo.GetQuizByIdAsync(id);
            return View(quiz);
        }
        // GET: Quiz/Create
        [Authorize(Roles = "Admin")]

        public ActionResult Create()
        {
            return View();
        }
        // POST: Quiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateAsync(IFormCollection collection, Quiz quiz)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Validation Error");
                }
                Quiz result = await quizRepo.AddQuiz(quiz);

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
                return View(quiz);
            }
        }
        // GET: Quiz/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditAsync(Guid id)
        {
            if (id == null)
                return Redirect("/Error/400");

            var quiz = await quizRepo.GetQuizByIdAsync(id);
            if (quiz == null){
                ModelState.AddModelError(String.Empty, "Not Found.");
            }
            return View(quiz);
        }
        // POST: Quiz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> EditAsync(Guid id, IFormCollection collection, Quiz quiz)
        {
            try
            {
                // TODO: Add update logic here
                if (id == null)
                    return BadRequest();

                var result = await quizRepo.Update(quiz);
                if (result == null)
                    return Redirect("/Error/400");
                
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Update actie mislukt." + ex.InnerException.Message);
                return View(quiz);
            }
        }

        // GET: Quiz/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var quiz = await quizRepo.GetQuizByIdAsync(id);
            if (quiz == null) {
                return NotFound();
            }
            return View(quiz);
        }
        // POST: Quiz/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (id == null)
                    throw new Exception("Bad Delete Request");
                await quizRepo.DeleteQuiz(id);
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