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
    public class ChoiceRepo : IChoiceRepo
    {
        private readonly ApplicationDbContext context;

        public ChoiceRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Choice>> GetChoicesAsync(int QuestionId) { 
            try
            {
                return await context.Choices.Where(c => c.QuestionID == QuestionId).ToListAsync();
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }
    }
}
