using Microsoft.EntityFrameworkCore;
using QuizApplication.Data;
using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Repositories
{
    public class QuizRepo : IQuizRepo
    {
        private readonly ApplicationDbContext context;

        public QuizRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Quiz>> GetQuizzesAsync()
        {
            try
            {
                return await context.Quizzes.OrderBy(n => n.QuizName).ToListAsync();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        public async Task<Quiz> GetQuizByDifficultyAsync(int difficulty)
        {
            try
            {
                return await context.Quizzes.FirstOrDefaultAsync(q => q.Difficulty == difficulty);
            }

            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }

        }

    }
}
