using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers.Api
{
    public class MealRouletteController : ApiController
    {
        private readonly IMealRouletteService mealRouletteService;

        public MealRouletteController(IMealRouletteService mealRouletteService)
        {
            this.mealRouletteService = mealRouletteService;
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await mealRouletteService.RollMealAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
