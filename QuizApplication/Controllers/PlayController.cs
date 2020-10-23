using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Data;
using QuizApplication.Models;
using QuizApplication.Repositories;
using QuizApplication.WebApp.ViewModels;

namespace QuizApplication.WebApp.Controllers
{
    public class PlayController : Controller
    {
        private readonly IQuizRepo quizRepo;
        private readonly ApplicationDbContext context;
        private readonly IQuestionRepo questionRepo;
        private readonly IAnswerRepo answerRepo;
        private readonly IChoiceRepo choiceRepo;

        public PlayController(IQuizRepo quizRepo , ApplicationDbContext context, IQuestionRepo questionRepo, IAnswerRepo answerRepo, IChoiceRepo choiceRepo)
        {
            this.quizRepo = quizRepo;
            this.context = context;
            this.questionRepo = questionRepo;
            this.answerRepo = answerRepo;
            this.choiceRepo = choiceRepo;
        }

        // GET: Play
        public async Task<ActionResult> IndexAsync(string Id)
        {
            if (Id == null)
                return RedirectToAction("Index");
            try
            {
                ////get quiz
                var quiz = await quizRepo.GetQuizByIdAsync(Guid.Parse(Id));

                var EvalVm = new EvaluationVM();
                EvalVm.QuizId = quiz.QuizID.ToString();
                EvalVm.QuizName = quiz.QuizName;

                ////vragen ophalen
                var questions = await questionRepo.GetQuestionsByQuizAsync(quiz.QuizID);
                foreach (var question in questions)
                {
                    //antwoord ophalen
                    Answer answer = await answerRepo.GetAnswerByQuestionAsync(question.QuestionId);
                    var q = new QuestionVM()
                    {
                        QuestionID = question.QuestionId.ToString(),
                        QuestionText = question.QuestionText,
                    };
                    q.Answers.Add(answer);

                    //choices toevoegen 
                    IEnumerable<Choice> choices = await choiceRepo.GetChoicesAsync(question.QuestionId);
                    List<Choice> ListChoices = choices.ToList();
                    //overlopen choices
                    foreach (var c in ListChoices)
                    {
                        Answer choice = new Answer()
                        {
                            AnswerID = c.ChoiceID,
                            AnswerText = c.ChoiceText,
                            QuestionID = c.QuestionID
                        };
                        q.Answers.Add(choice);
                        q.Answers = q.Answers.OrderBy(m => m.AnswerText).ToList();
                    }
                    EvalVm.Questions.Add(q);
                }
                return View(EvalVm);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //// POST: Play
        [HttpPost]
        public async Task<ActionResult> IndexAsync(string Id, IFormCollection collection, EvaluationVM vm)
        {
            if (Id == null)
                return RedirectToAction("index");

            try
            {
                ScoreVM scoreVM = new ScoreVM();
                int score = 0; //correct answer = +10
                int correctAnsweredQ = 0; // 0/10

                foreach (var question in vm.Questions) 
                {
                    //get correct answer
                    Answer answer = await answerRepo.GetAnswerByQuestionAsync(Guid.Parse(question.QuestionID));

                    //check if selectedanswer is correct
                    if (question.SelectedAnswer == answer.AnswerID.ToString()) 
                    {
                        //correct! +10 
                        //counter correct answers +1
                        score = score + 10;
                        correctAnsweredQ++;
                    }
                }
                scoreVM.score = score;
                scoreVM.countCorrectAnswers = correctAnsweredQ;
                scoreVM.QuizName = vm.QuizName;
                return RedirectToAction("EndQuiz", scoreVM);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"update error. {ex.InnerException.Message}");
                ModelState.AddModelError("", "Update actie mislukt." + ex.InnerException.Message);
                return View(vm);
            }

        }


        // GET: Play
        public async Task<ActionResult> EndQuiz(ScoreVM vm)
        {
            if (vm.QuizName == null)
                return RedirectToAction("Index");


            return View(vm);
        }


    }
}

