using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Repositories
{
    public interface IChoiceRepo
    {
        Task<IEnumerable<Choice>> GetChoicesAsync(Guid QuestionId);
        Task<Choice> GetChoiceByIdAsync(Guid ChoiceId);
        Task<Choice> AddChoice(Choice choice);
        Task<Choice> Update(Choice choice);
        Task DeleteChoice(Guid Id);



    }
}
