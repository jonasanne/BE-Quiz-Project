using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Repositories
{
    public interface IQuestionRepo
    {
        Task<IEnumerable<Question>> GetQuestionsByQuizAsync(Guid Id);
        Task<Question> GetQuestionByIdAsync(Guid id);
        Task<Question> AddQuestion(Question question);
        Task DeleteQuestion(Guid Id);
        Task<Question> Update(Question question);


    }
}
