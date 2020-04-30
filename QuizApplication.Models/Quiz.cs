using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class Quiz
    {

        public enum DifficultyType
        {
            [Display(Name = "Beginner")]
            Beginner = 0,
            [Display(Name = "Medium")]
            Medium = 1,
            [Display(Name = "Hard")]
            Hard = 2
        }


        [Key]
        public Guid QuizID { get; set; } = Guid.NewGuid();

        [MaxLength(150)]
        [Required]
        public string QuizName { get; set; }


        [Required]
        [EnumDataType(typeof(DifficultyType), ErrorMessage = "{0} is geen geldige keuze.")]
        [Range(0, 2, ErrorMessage = "Wrong choice.")]
        public DifficultyType Difficulty { get; set; } // 1 , 2, 3


        [MaxLength(200)]
        public string Description { get; set; } 
        public string ImgUrl { get; set; } 
        public Guid SubjectId { get; set; }


        //navgiation properties
        public Subject Subject { get; set; }
    }
}
