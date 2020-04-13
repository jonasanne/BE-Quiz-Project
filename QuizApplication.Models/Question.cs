using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; } = Guid.NewGuid();

        [Required]
        public string QuestionText { get; set; }

        //[Required]
        //public int QuestionType { get; set; }
        
        [Required]
        public Guid QuizId { get; set; }


        //navigation property
        public Quiz Quiz { get; set; }
        
    }
}
