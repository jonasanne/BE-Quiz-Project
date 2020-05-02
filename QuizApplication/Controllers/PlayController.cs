using System;
using System.Collections.Generic;
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
                return Redirect("/Error/400");

            ////get quiz
            var quiz = await quizRepo.GetQuizByIdAsync(Guid.Parse(Id));

            List<QuestionVM> _questions = new List<QuestionVM>();

            //niewe play VM
            PlayQuiz_VM vm = new PlayQuiz_VM();
            vm.QuizId = quiz.QuizID.ToString();
            vm.QuizName = quiz.QuizName;


            ////vragen ophalen
            var questions = await questionRepo.GetQuestionsByQuizAsync(quiz.QuizID);
            foreach (var question in questions)
            {
                Answer answer = await answerRepo.GetAnswerByQuestionAsync(question.QuestionId);

                IEnumerable<Choice> choices = await choiceRepo.GetChoicesAsync(question.QuestionId);
                List<Choice> ListChoices = choices.ToList();
                Choice answerChoice = new Choice()
                {
                    ChoiceID = answer.AnswerID,
                    ChoiceText = answer.AnswerText,
                    QuestionID = answer.QuestionID
                };

                ListChoices.Add(answerChoice);
                var _question = new QuestionVM()
                {
                    QuestionId = question.QuestionId.ToString(),
                    Question = question.QuestionText,
                    Choices = ListChoices.OrderBy(e => e.Question).ToList()
                };
                _questions.Add(_question);
            }
                return View(_questions.AsQueryable());
        }
        // POST: Play
        [HttpPost]
        public async Task<ActionResult> IndexAsync(string Id, IFormCollection collection, PlayQuiz_VM vm)
        {
            if (Id == null)
                return Redirect("/Error/400");
            return View();
        }

    }
}