using Microsoft.AspNetCore.Identity;
using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.WebApp.ViewModels
{
    public class RolesForUser_VM
    {
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public IList<string> AssignedRoles { get; set; }
        public IList<string> UnAssignedRoles { get; set; }
    }
}
