using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.WebApi.Models.MealCategory;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers
{
    public class MealCategoryController : ApiController
    {
        private readonly IMealCategoryService mealCategoryService;

        public MealCategoryController(IMealCategoryService mealCategoryService)
        {
            this.mealCategoryService = mealCategoryService;
        }

        public void Put([FromBody]CreateMealCategoryApiModel createMealCategoryRequest)
        {
            mealCategoryService.Create(createMealCategoryRequest.Name);
        }
    }
}
