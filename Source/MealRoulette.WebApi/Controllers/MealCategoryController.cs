using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.WebApi.Models.MealCategory;
using System.Collections.Generic;
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

        public MealCategory Get(int id)
        {
            return mealCategoryService.Get(id);
        }

        public IEnumerable<MealCategory> Get()
        {
            return mealCategoryService.Get();
        }

        public IPage<MealCategory> GetPage(int index, int pageSize)
        {
            return mealCategoryService.GetPage(index, pageSize);
        }

        public IHttpActionResult Post([FromBody]CreateMealCategoryApiRequest createMealCategoryRequest)
        {
            try
            {
                mealCategoryService.Create(createMealCategoryRequest.Name);
            }
            catch (DomainException error)
            {
                return BadRequest(error.Message);
            }
            
            return Ok();
        }
    }
}
