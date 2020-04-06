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

        public async Task<IEnumerable<Question>> GetQuestionsAsync()
        {
            try
            {
                return await context.Questions.OrderBy(q => q.QuizId).ToListAsync();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        //public async Task<IEnumerable<Question>> GetQuestionsByIdAsync(int id)
        //{
        //    try
        //    {
        //        return await context.Questions.Where(q => q.QuizID == id).ToListAsync();
        //    }

        //    catch (Exception ex)
        //    {

        //        Debug.WriteLine(ex.InnerException.Message);
        //        throw null;
        //    }
        //}
    }
}
