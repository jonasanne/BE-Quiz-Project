using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.API.Models
{
    public class Score_DTO
    {
        
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int Score { get; set; } 

        public DateTime dateOfScore { get; set; }

    }
}
