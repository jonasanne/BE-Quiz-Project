using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.API.Models;
using QuizApplication.Models;
using QuizApplication.Models.Repositories;
using QuizApplication.Repositories;

namespace QuizApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepo quizRepo;
        private readonly ISubjectRepo subjectRepo;

        public QuizController(IQuizRepo quizRepo , ISubjectRepo subjectRepo)
        {
            this.quizRepo = quizRepo;
            this.subjectRepo = subjectRepo;
        }

        // GET: api/Quizzes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzes()
        {
            //1. enititeiten ophaln
            var model = await quizRepo.GetQuizzesAsync();


            //2. Mapping naar DTO
            List<Quiz_DTO> dTOs = new List<Quiz_DTO>();
            foreach (Quiz item in model)
            {
                var result = new Quiz_DTO();
                dTOs.Add(Mapper.ConvertTo_DTOAsync(item, ref result, subjectRepo));
            }
            return Ok(dTOs);
        }

        // GET: api/Quiz/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Quiz
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Quiz/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
