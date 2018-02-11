using MealRoulette.Exceptions;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Extensions;
using MealRoulette.WebApi.Models.Meal;
using System;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers.Api
{
    public class MealController : ApiController
    {
        private readonly IMealService mealService;

        public MealController(IMealService mealService)
        {
            this.mealService = mealService ?? throw new ArgumentNullException(nameof(mealService));
        }

        public IHttpActionResult Get(int id)
        {
            var meal = mealService.Get(id);
            var response = meal.Map();
            return Ok(response);
        }

        public IHttpActionResult Get(int pageIndex, int pageSize)
        {
            var meals = mealService.Get(pageIndex, pageSize);
            var result = new MealPageResponse(meals);
            return Ok(result);
        }

        public IHttpActionResult Get()
        {
            var result = mealService.Get();
            return Ok(result);
        }

        public IHttpActionResult Post([FromBody]CreateMealApiRequest meal)
        {
            try
            {
                var mealCategoryDto = meal.MealCategory.Map();
                var mealIngredientsDto = meal.Ingredients.Map();

                mealService.Create(meal.Name, mealCategoryDto, mealIngredientsDto);
            }
            catch (DomainException error)
            {
                return BadRequest(error.Message);
            }

            return Ok();
        }
    }
}
