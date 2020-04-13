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
    public class QuestionRepo : IQuestionRepo
    {
        private readonly ApplicationDbContext context;

        public QuestionRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Question>> GetQuestionsByQuizAsync(Guid Id)
        {
            try
            {
                return await context.Questions.Where(q => q.QuizId == Id).ToListAsync();
                //return await context.Questions.OrderBy(q => q.QuizId).ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }
        public  Task<Question> GetQuestionByIdAsync(Guid id)
        {
            try
            {
                return context.Questions.FirstOrDefaultAsync<Question>(q => q.QuestionId == id);
            }

            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }
        public async Task<Question> AddQuestion(Question question)
        {
            try
            {
                question.QuestionId = Guid.NewGuid();
                var result = context.Questions.AddAsync(question);
                await context.SaveChangesAsync();
                return question;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }
        public async Task DeleteQuestion(Guid Id)
        {
            try
            {
                Question question = await GetQuestionByIdAsync(Id);

                if (question == null)
                {
                    return;
                }
                var result = context.Questions.Remove(question);
                ////doe hier een archivering van education ipv delete -> veiliger
                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }
        public async Task<Question> Update(Question question)
        {
            try
            {
                context.Questions.Update(question);
                await context.SaveChangesAsync();
                return question;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw null;

            }
        }
    }
}
