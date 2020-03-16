using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Repositories
{
    public interface IAnswerRepo
    {

        Task<Answer> GetAnswerByQuestionAsync(int id);
    }
}
