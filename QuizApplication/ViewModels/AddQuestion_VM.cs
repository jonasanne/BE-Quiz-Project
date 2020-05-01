using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.WebApp.ViewModels
{
    public class AddQuestion_VM
    {
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [MaxLength(300)]
        [Display(Name = "Question")]
        public string QuestionText { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [MaxLength(300)]
        [Display(Name = "Answer")]
        public string QuestionAnswer { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [MaxLength(300)]
        [Display(Name = "Choice A")]
        public string QuestionChoiceA { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [MaxLength(300)]
        [Display(Name = "Choice B")]
        public string QuestionChoiceB { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [MaxLength(300)]
        [Display(Name = "Choice C")]
        public string QuestionChoiceC { get; set; }
    }
}
