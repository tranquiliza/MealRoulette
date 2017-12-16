using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.WebApi.Models.Ingredient;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers
{
    public class IngredientController : ApiController
    {
        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        public IEnumerable<Ingredient> Get()
        {
            return ingredientService.Get();
        }

        public IPage<Ingredient> Get(int pageIndex, int pageSize)
        {
            return ingredientService.Get(pageIndex, pageSize);
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
