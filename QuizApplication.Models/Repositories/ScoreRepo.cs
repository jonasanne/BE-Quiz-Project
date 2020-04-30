using QuizApplication.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuizApplication.Models.Repositories
{
    public class ScoreRepo : IScoreRepo
    {
        private readonly ApplicationDbContext context;

        public ScoreRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        //done
        public async Task<Score> AddScore(Score score)
        {
            try
            {
                score.ScoreId = Guid.NewGuid();
                var result = context.Scores.AddAsync(score);//ChangeTracking
                await context.SaveChangesAsync();
                return score; //heeft nu een id (autoidentity)
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        //done
        public async Task DeleteScore(Guid Id)
        {
            try
            {
                Score score = await GetScoreById(Id);

                if (score == null)
                {
                    return;
                }

                var result = context.Scores.Remove(score);
                ////doe hier een archivering van education ipv delete -> veiliger
                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }

        //done
        public Task<Score> GetScoreById(Guid Id)
        {
            try
            {
                return context.Scores.FirstOrDefaultAsync<Score>(e => e.ScoreId == Id);
            }

            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        //done
        public Task<Score> GetScoreByUserId(Guid Id)
        {
            try
            {
                return context.Scores.FirstOrDefaultAsync<Score>(e => e.UserId == Id);
            }

            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        //done, order by on score high > low
        public async Task<IEnumerable<Score>> GetScoresAsync()
        {
            try
            {
                return await context.Scores.OrderByDescending(n => n.ScorePoints).ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        //done, potentieel
        public async Task<Score> Update(Score score)
        {
            try
            {
                context.Scores.Update(score);
                await context.SaveChangesAsync();
                return score;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw null;

            }
        }
    }
}