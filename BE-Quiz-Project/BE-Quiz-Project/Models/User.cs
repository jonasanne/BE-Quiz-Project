using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Quiz_Project.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        //maybe change dataType
        public int Is_admin { get; set; }
    }
}
