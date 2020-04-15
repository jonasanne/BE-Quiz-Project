using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApplication.Models
{
    public class Subject
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
    }
}
