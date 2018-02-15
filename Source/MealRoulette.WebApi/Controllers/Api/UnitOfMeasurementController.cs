using MealRoulette.Services.Abstractions;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers.Api
{
    public class UnitOfMeasurementController : ApiController
    {
        private readonly IUnitOfMeasurementService unitOfMeasurementService;

        public UnitOfMeasurementController(IUnitOfMeasurementService unitOfMeasurementService)
        {
            this.unitOfMeasurementService = unitOfMeasurementService;
        }

        public IHttpActionResult Get()
        {
            var result = unitOfMeasurementService.Get();
            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = unitOfMeasurementService.Get(id);
            return Ok(result);
        }
    }
}
