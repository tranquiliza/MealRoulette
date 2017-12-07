using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.WebApi.Extensions;
using MealRoulette.WebApi.Models.Meal;
using System;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers
{
    public class MealController : ApiController
    {
        private readonly IMealService mealService;

        public MealController(IMealService mealService)
        {
            this.mealService = mealService ?? throw new ArgumentNullException(nameof(mealService));
        }

        public Meal Get(int id)
        {
            return mealService.Get(id);
        }

        public IHttpActionResult Post([FromBody]CreateMealApiRequest meal)
        {
            try
            {
                mealService.CreateMeal(meal.Name, meal.MealCategory.Map(), meal.Ingredients.Map());
            }
            catch (DomainException error)
            {
                return BadRequest(error.Message);
            }

            return Ok();
        }
    }
}
