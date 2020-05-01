using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizApplication.Models
{
    public class Subject
    {
        public Guid SubjectId { get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        [Display(Name = "Name")]
        public string SubjectName { get; set; }

        public string Description { get; set; }
    }
}
