using MealRoulette.DataStructures;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Extensions;
using MealRoulette.WebApi.Models.Meal;
using System;
using System.Collections.Generic;
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

        public IPage<Meal> Get(int pageIndex, int pageSize)
        {
            return mealService.Get(pageIndex, pageSize);
        }

        public IEnumerable<Meal> Get()
        {
            return mealService.Get();
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
