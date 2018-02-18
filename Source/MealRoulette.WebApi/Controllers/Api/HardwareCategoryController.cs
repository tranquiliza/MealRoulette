using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Extensions;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers
{
    public class HardwareCategoryController : ApiController
    {
        private readonly IHardwareCategoryService _HardwareCategoryService;

        public HardwareCategoryController(IHardwareCategoryService hardwareCategoryService)
        {
            _HardwareCategoryService = hardwareCategoryService;
        }

        public IHttpActionResult Get()
        {
            var result = _HardwareCategoryService.Get();
            return Ok(result.Map());
        }

        public IHttpActionResult Get(int id)
        {
            var result = _HardwareCategoryService.Get(id);
            return Ok(result.Map());
        }
    }
}
