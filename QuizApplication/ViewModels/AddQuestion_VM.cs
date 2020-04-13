using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.WebApp.ViewModels
{
    public class AddQuestion_VM
    {
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionAnswer { get; set; }
        public string QuestionChoiceA { get; set; }
        public string QuestionChoiceB { get; set; }
        public string QuestionChoiceC { get; set; }
    }
}
