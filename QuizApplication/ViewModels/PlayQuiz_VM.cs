using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.WebApp.ViewModels
{
    public class PlayQuiz_VM
    {

        public string QuizId { get; set; }
        public string QuizName { get; set; }
        public ICollection<QuestionVM> Questions { get; set; }
        public ICollection<QuizAnswersVM> UserAnswers { get; set; }
    }
    public class QuestionVM
    {
        public string QuestionId { get; set; }
        public string Question { get; set; }
        public ICollection<Choice> Choices { get; set; }
    }
    public class QuizAnswersVM
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerQ { get; set; }
        public bool IsCorrect { get; set; }

    }


}
