using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.WebApp.ViewModels
{
    public class EditQuestion_VM
    {
            public Guid QuizId { get; set; }
            public Guid QuestionId { get; set; }
            public string QuestionText { get; set; }

            public Guid QuestionAnswerId { get; set; }
            public string QuestionAnswer { get; set; }

            public Guid ChoiceAId { get; set; }
            public string QuestionChoiceA { get; set; }

            public Guid ChoiceBId { get; set; }
            public string QuestionChoiceB { get; set; }
        
            public Guid ChoiceCId { get; set; }
            public string QuestionChoiceC { get; set; }
    }
}
