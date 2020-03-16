using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class Quiz
    {
        public int QuizID { get; set; }
        public string QuizName { get; set; }
        public int Difficulty { get; set; }
    }
}
