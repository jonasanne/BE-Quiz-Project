﻿using Microsoft.EntityFrameworkCore;
using QuizApplication.Data;
using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Repositories
{
    public class AnswerRepo : IAnswerRepo
    {
		private readonly ApplicationDbContext context;

		public AnswerRepo(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<Answer> AddAnswer(Answer answer)
		{
			try
			{
				answer.AnswerID = Guid.NewGuid();
				var result = context.Answers.AddAsync(answer);
				await context.SaveChangesAsync();
				return answer;
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.InnerException.Message);
				return null;
			}
		}

		public async Task DeleteAnswer(Guid Id)
		{
			try
			{
				Answer answer = await GetAnswerByIdAsync(Id);

				if (answer == null)
				{
					return;
				}
				var result = context.Answers.Remove(answer);

				await context.SaveChangesAsync();
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
			}
			return;
		}

		public async Task<Answer> GetAnswerByIdAsync(Guid Id)
		{
			try
			{
				return await context.Answers.FirstOrDefaultAsync(c => c.AnswerID == Id);
			}

			catch (Exception ex)
			{
				Debug.WriteLine(ex.InnerException.Message);
				throw null;
			}
		}

		public async Task<Answer> GetAnswerByQuestionAsync(Guid id)
        {
			try
			{
				return await context.Answers.FirstOrDefaultAsync(a => a.QuestionID == id);
			}
			catch (Exception ex )
			{
				Debug.WriteLine(ex.InnerException.Message);
				throw null;
			}

        }

		public async Task<Answer> Update(Answer answer)
		{
			try
			{
				context.Answers.Update(answer);
				await context.SaveChangesAsync();
				return answer;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.InnerException.Message);
				throw null;

			}
		}


	}
}
