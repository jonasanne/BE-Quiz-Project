using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizApplication.Models
{
    public class Score
    {
        [Key]
        public Guid ScoreId { get; set; } =  Guid.NewGuid(); 
        [Required]
        public Guid UserId { get; set; }
        public int ScorePoints { get; set; }
        public DateTime DateOfScore { get; set; } =   DateTime.Now;
        public Guid QuizId { get; set; }


        //navgiation properties
        public Quiz Quiz { get; set; }

    }
}
