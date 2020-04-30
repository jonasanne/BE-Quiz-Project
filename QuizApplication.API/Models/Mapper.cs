using Microsoft.AspNetCore.Identity;
using QuizApplication.Models;
using QuizApplication.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.API.Models
{
    public class Mapper
    {


        public static Quiz_DTO ConvertTo_DTOAsync(Quiz quiz, ref Quiz_DTO quiz_DTO, ISubjectRepo subjectRepo)
        {
            try
            {
                Subject subject =  subjectRepo.GetsubjectById(quiz.SubjectId).Result;

                //controleer objecten op null
                quiz_DTO.QuizName = quiz.QuizName;
                quiz_DTO.Difficulty = quiz.Difficulty.ToString();
                quiz_DTO.Description = (quiz.Description is null) ? "No description is given" : quiz.Description;
                quiz_DTO.ImgUrl = quiz.ImgUrl;
                quiz_DTO.SubjectName = subject.SubjectName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                
            }
            return quiz_DTO;
        }

    }


}

