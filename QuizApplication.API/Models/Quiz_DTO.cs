using Newtonsoft.Json;
using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static QuizApplication.Models.Quiz;

namespace QuizApplication.API.Models
{
    public class Quiz_DTO
    {


        [Display(Name = "Naam")]
        [MaxLength(150)]
        [Required]
        public string QuizName { get; set; }


        [Display(Name = "Moeilijkheidsgraad")]
        [Required]
        public string Difficulty { get; set; } // 1 , 2, 3


        [Display(Name = "Beschrijving")]
        [MaxLength(200)]
        public string Description { get; set; }


        [Display(Name = "ImageUrl")]
        public string ImgUrl { get; set; }


        [Display(Name = "Subject")]
        public string SubjectName { get; set; }


        //navgiation properties
        [JsonProperty("Subjects", NullValueHandling = NullValueHandling.Ignore)]
        public Subject Subject { get; set; }
    }
}
