using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuizApplication.Models
{
    public class Person : IdentityUser
    {
        [Display(Name = "Naam")]
        [MaxLength(25)]
        public string Name { get; set; }



        public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();
    }
}
