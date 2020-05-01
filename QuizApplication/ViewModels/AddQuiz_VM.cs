using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static QuizApplication.Models.Quiz;

namespace QuizApplication.WebApp.ViewModels
{
    public class AddQuiz_VM
    {
        public Guid QuizID { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [MaxLength(150)]
        [Display(Name = "Quiz name")]
        public string QuizName { get; set; }

        public DifficultyType Difficulty { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [MaxLength(1024)]

        public string Description { get; set; }

        [MaxLength(1024)]
        public string ImgUrl { get; set; } 
        public List<Subject> Subjects { get; set; }
        public Guid SubjectId { get; set; }

        [Display(Name = "Subject")]
        public string SubjectName { get; set; }
    }
}
