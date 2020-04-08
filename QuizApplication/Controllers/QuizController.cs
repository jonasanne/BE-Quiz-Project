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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                return RedirectToAction(nameof(IndexAsync));

            }
            catch (Exception ex)
            {

                Debug.WriteLine("unable to create" + ex.Message);
                ModelState.AddModelError("", "Create mislukt." + ex.Message);
                return View(quiz);
            }
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Delete/5
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var teacher = await quizRepo.GetQuizByIdAsync(id);
            if (teacher == null) {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Quiz/Delete/5
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