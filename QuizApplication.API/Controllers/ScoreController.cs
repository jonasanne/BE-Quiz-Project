using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.API.Models;
using QuizApplication.Models;
using QuizApplication.Models.Repositories;

namespace QuizApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {

        private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme + ","+ JwtBearerDefaults.AuthenticationScheme;
        private readonly IScoreRepo scoreRepo;
        public ScoreController(IScoreRepo scoreRepo)
        {
            this.scoreRepo = scoreRepo;
        }

        // GET: api/Scores
        [HttpGet]
        [Authorize(AuthenticationSchemes = AuthSchemes)]
        public async Task<ActionResult<IEnumerable<Score>>> GetScoresAsync()
        {
            try
            {
            var scores = await scoreRepo.GetScoresAsync();

            //mapping naar dto
            List<Score_DTO> dTOs = new List<Score_DTO>();
            foreach (Score item in scores)
            {
                var result = new Score_DTO();
                dTOs.Add(ScoreMapper.ConvertTo_DTOAsync(item, ref result));
            }
            return Ok(dTOs);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw;
            }
        }



        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromForm] Score_DTO dTO)
        {
            var confirmedModel = new Score();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                //entity (model) via mapper ophalen
                var model = new Score() { };

                ScoreMapper.ConvertTo_Entity(model, ref dTO);
                //entity (model) toevoegen via repo
                confirmedModel = await scoreRepo.AddScore(model);
                if (confirmedModel == null)
                    return NotFound(model.ScorePoints + "Werd NIET bewaard.");
            }
            catch (Exception ex )
            {
                Debug.WriteLine(ex.InnerException.Message);
                return BadRequest("Toevoegen mislukt.");
            }
            return CreatedAtAction("Post", new { id = confirmedModel.ScoreId }, confirmedModel);
               

        }
    }
}
