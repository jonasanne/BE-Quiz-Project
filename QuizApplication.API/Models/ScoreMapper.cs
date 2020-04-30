using QuizApplication.Models;
using QuizApplication.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.API.Models
{
    public class ScoreMapper
    {
        public static Score_DTO ConvertTo_DTOAsync(Score score, ref Score_DTO score_DTO)
        {
            try
            {
                //controleer objecten op null
                score_DTO.UserId = score.UserId;
                score_DTO.Score = score.ScorePoints;
                score_DTO.dateOfScore = score.DateOfScore;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
            }
            return score_DTO;
        }

        public static Score ConvertTo_Entity(Score score, ref Score_DTO score_DTO)
        {
            try
            {
                //controleer objecten op null
                score.ScoreId = Guid.NewGuid();
                score.DateOfScore = DateTime.Now;
                score.ScorePoints = score_DTO.Score;
                score.UserId = score_DTO.UserId;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
            }
            return score;
        }


    }
}
