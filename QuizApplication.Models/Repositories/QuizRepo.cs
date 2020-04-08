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
                quiz.QuizID = Guid.NewGuid();
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

        public async Task DeleteQuiz(Guid Id)
        {
            try
            {
                Quiz quiz = await GetQuizByIdAsync(Id);

                if (quiz == null)
                {
                    return;
                }

                var result = context.Quizzes.Remove(quiz);
                ////doe hier een archivering van education ipv delete -> veiliger
                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }

        public async Task<Quiz> Update(Quiz quiz)
        {
            try
            {
                context.Quizzes.Update(quiz);
                await context.SaveChangesAsync();
                return quiz;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw null;

            }
        }
    }
}
