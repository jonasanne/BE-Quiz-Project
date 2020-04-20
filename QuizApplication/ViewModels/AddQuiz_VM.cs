using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.WebApp.ViewModels
{
    public class AddQuiz_VM
    {
        public Guid QuizID { get; set; }

        public string QuizName { get; set; }

        public int Difficulty { get; set; }

        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public List<Subject> Subjects { get; set; }
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }

    }
}
