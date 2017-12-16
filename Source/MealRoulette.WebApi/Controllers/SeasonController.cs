using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.WebApi.Models.Season;
using System.Collections.Generic;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers
{
    public class SeasonController : ApiController
    {
        private readonly ISeasonService seasonService;

        public SeasonController(ISeasonService seasonService)
        {
            this.seasonService = seasonService;
        }

        public IEnumerable<Season> Get()
        {
            return seasonService.Get();
        }

        public IHttpActionResult Post([FromBody]CreateSeasonApiRequest createSeasonApiRequest)
        {
            if (createSeasonApiRequest == null) return BadRequest();

            try
            {
                seasonService.Create(createSeasonApiRequest.Name);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
