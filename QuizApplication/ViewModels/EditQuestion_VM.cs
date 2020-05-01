using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.WebApp.ViewModels
{
    public class EditQuestion_VM
    {
            public Guid QuizId { get; set; }
            public Guid QuestionId { get; set; }

            [Required(ErrorMessage = "{0} is verplicht")]
            [MaxLength(300)]
            [Display(Name = "Question")]
            public string QuestionText { get; set; }
            public string QuestionAnswerId { get; set; }

            [Required(ErrorMessage = "{0} is verplicht")]
            [MaxLength(300)]
            [Display(Name = "Answer")]
            public string QuestionAnswer { get; set; }
            public string ChoiceAId { get; set; }

            [Required(ErrorMessage = "{0} is verplicht")]
            [MaxLength(300)]
            [Display(Name = "Choice A")]
            public string QuestionChoiceA { get; set; }
            public string ChoiceBId { get; set; }

            [Required(ErrorMessage = "{0} is verplicht")]
            [MaxLength(300)]
            [Display(Name = "Choice B")]
            public string QuestionChoiceB { get; set; }

            public string ChoiceCId { get; set; }

            [Required(ErrorMessage = "{0} is verplicht")]
            [MaxLength(300)]
            [Display(Name = "Choice C")]
            public string QuestionChoiceC { get; set; }
    }
}
