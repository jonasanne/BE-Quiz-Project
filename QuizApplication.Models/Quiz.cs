using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class Quiz
    {
        [Key]
        public Guid QuizID { get; set; } = Guid.NewGuid();

        [MaxLength(150)]
        [Required]
        public string QuizName { get; set; }

        [Required]
        public int Difficulty { get; set; } // 1 , 2, 3
        [MaxLength(200)]
        public string Description { get; set; } 
        public string ImgUrl { get; set; } 
        public Guid SubjectId { get; set; }


        //navgiation properties
        public Subject Subject { get; set; }
    }
}
