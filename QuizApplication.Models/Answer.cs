using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class Answer
    {
        [Key]
        public Guid AnswerID { get; set; } = Guid.NewGuid();
        
        public string AnswerText { get; set; }
        [Required]
        public Guid QuestionID { get; set; }


        //Navigation property
        public Question Question { get; set; }

    }
}
