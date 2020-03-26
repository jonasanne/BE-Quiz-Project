using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public int QuestionID { get; set; }
    }
}
