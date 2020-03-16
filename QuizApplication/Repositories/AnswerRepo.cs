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



        public async Task<Answer> GetAnswerByQuestionAsync(int id)
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
    }
}