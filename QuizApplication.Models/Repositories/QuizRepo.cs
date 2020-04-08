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

        public Task<Quiz> GetQuizByIdAsync(Guid Id)
        {
            try
            {
                return context.Quizzes.FirstOrDefaultAsync<Quiz>(e => e.QuizID == Id) ;
            }

            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        public async Task<Quiz> AddQuiz(Quiz quiz)
        {
            try
            {
                var result = context.Quizzes.AddAsync(quiz);//ChangeTracking
                await context.SaveChangesAsync();
                return quiz; //heeft nu een id (autoidentity)
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }
    }
}
