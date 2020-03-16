using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Repositories
{
    public interface IQuizRepo
    {
        /// <summary>
        /// get all quizzes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Quiz>> GetQuizzesAsync();
        /// <summary>
        /// get quiz by difficulty
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        Task<Quiz> GetQuizByDifficultyAsync(int difficulty);





    }
}
