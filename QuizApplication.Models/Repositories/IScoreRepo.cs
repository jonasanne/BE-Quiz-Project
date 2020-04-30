using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models.Repositories
{
    public interface IScoreRepo
    {
            Task<IEnumerable<Score>> GetScoresAsync();
            Task<Score> GetScoreByUserId(Guid Id);
            Task<Score> GetScoreById(Guid Id);
            Task<Score> AddScore(Score  score);
            Task DeleteScore(Guid id);

            //potentieel
            Task<Score> Update(Score score);

    }
}
