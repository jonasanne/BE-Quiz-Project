using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class Choice
    {
        [Key]
        public Guid ChoiceID { get; set; } = Guid.NewGuid();
        
        public string ChoiceText { get; set; }
        public Guid QuestionID { get; set; }

        //Navigation property

        public Question Question { get; set; }
    }
}
