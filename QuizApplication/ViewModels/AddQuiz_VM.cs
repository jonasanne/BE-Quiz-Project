using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static QuizApplication.Models.Quiz;

namespace QuizApplication.WebApp.ViewModels
{
    public class AddQuiz_VM
    {
        public Guid QuizID { get; set; }

        public string QuizName { get; set; }

        public DifficultyType Difficulty { get; set; }

        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public List<Subject> Subjects { get; set; }
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }

    }
}
