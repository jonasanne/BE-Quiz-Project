using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.WebApp.ViewModels
{
    public class QuestionVM
    {
        public string QuestionID { set; get; }
        public string QuestionText { set; get; }
        public List<Answer> Answers { set; get; }

        [Display(Name = "antwoord")]
        [Required(ErrorMessage ="{0} is verplicht")]
        public string SelectedAnswer { set; get; }
        public QuestionVM()
        {
            Answers = new List<Answer>();
        }
    }
    public class EvaluationVM
    {
        public string QuizName { get; set; }
        public string QuizId { get; set; }
        public List<QuestionVM> Questions { set; get; }
        public EvaluationVM()
        {
            Questions = new List<QuestionVM>();
        }
    }
}
