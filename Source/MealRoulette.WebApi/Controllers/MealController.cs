using MealRoulette.Domain.DomainServices.Abstractions;
using MealRoulette.Domain.Models;
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
        
        public void Post([FromBody]MealCreateApiModel meal)
        {
            mealService.CreateMeal(meal.Name, meal.CategoryId);
        }
    }
}
