using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class Choice
    {
        public int ChoiceID { get; set; }
        public string ChoiceText { get; set; }
        public int QuestionID { get; set; }
    }
}
