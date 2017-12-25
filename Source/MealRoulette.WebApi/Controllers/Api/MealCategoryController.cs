using MealRoulette.DataStructures;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Models.MealCategory;
using System.Collections.Generic;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers.Api
{
    public class MealCategoryController : ApiController
    {
        private readonly IMealCategoryService mealCategoryService;

        public MealCategoryController(IMealCategoryService mealCategoryService)
        {
            this.mealCategoryService = mealCategoryService;
        }

        public IHttpActionResult Get(int id)
        {
            var result = mealCategoryService.Get(id);
            return Ok(result);
        }

        public IHttpActionResult Get()
        {
            var result = mealCategoryService.Get();
            return Ok(result);
        }

        public IHttpActionResult GetPage(int index, int pageSize)
        {
            var result = mealCategoryService.Get(index, pageSize);
            return Ok(result);
        }

        public IHttpActionResult Post([FromBody]CreateMealCategoryApiRequest createMealCategoryRequest)
        {
            if (createMealCategoryRequest == null) return BadRequest();

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
