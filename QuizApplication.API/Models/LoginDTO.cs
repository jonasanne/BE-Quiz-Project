using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.API.Models
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "username is verplicht")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is verplicht")]
        public string Password { get; set; }


        [Required]
        public DateTime BirthDate { get; set; }
    }
}
