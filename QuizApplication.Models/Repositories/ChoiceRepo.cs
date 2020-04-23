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

        public async Task<Choice> AddChoice(Choice choice)
        {
            try
            {
                choice.ChoiceID = Guid.NewGuid();
                var result = context.Choices.AddAsync(choice);
                await context.SaveChangesAsync();
                return choice;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task DeleteChoice(Guid Id)
        {
            try
            {
                Choice choice = await GetChoiceByIdAsync(Id);

                if (choice == null)
                {
                    return;
                }
                var result = context.Choices.Remove(choice);

                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }

        public async Task<Choice> GetChoiceByIdAsync(Guid ChoiceId)
        {
            try
            {
                return await context.Choices.FirstOrDefaultAsync(c => c.ChoiceID == ChoiceId);
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        public async Task<IEnumerable<Choice>> GetChoicesAsync(Guid QuestionId) { 
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

        public async Task<Choice> Update(Choice choice)
        {
            try
            {
                context.Choices.Update(choice);
                await context.SaveChangesAsync();
                return choice;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw null;

            }
        }
    }
}
