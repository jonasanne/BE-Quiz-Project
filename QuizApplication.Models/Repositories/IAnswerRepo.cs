using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Repositories
{
    public interface IAnswerRepo
    {

        Task<Answer> GetAnswerByQuestionAsync(Guid id);
        Task<Answer> AddAnswer(Answer answer);
        Task<Answer> Update(Answer answer);
        Task<Answer> GetAnswerByIdAsync(Guid Id);
        Task DeleteAnswer(Guid Id);


    }
}
