using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.WebApp.ViewModels
{
    public class ScoreVM
    {
        public int score { get; set; }
        public int countCorrectAnswers { get; set; }
        public string QuizName { get; set; }
    }
}
