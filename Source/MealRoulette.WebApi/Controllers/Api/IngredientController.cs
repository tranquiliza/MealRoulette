using MealRoulette.DataStructures;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Models.Ingredient;
using System.Collections.Generic;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers.Api
{
    public class IngredientController : ApiController
    {
        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        public IHttpActionResult Get()
        {
            var result = ingredientService.Get();
            return Ok(result);
        }

        public IHttpActionResult Get(int pageIndex, int pageSize)
        {
            var result = ingredientService.Get(pageIndex, pageSize);
            return Ok(result);
        }

        public IHttpActionResult Post([FromBody]CreateIngredientApiRequest createIngredientApiRequest)
        {
            if (createIngredientApiRequest == null) return BadRequest();

            try
            {
                ingredientService.Create(createIngredientApiRequest.Name);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
