using MealRoulette.Exceptions;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Models.Holiday;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers.Api
{
    public class HolidayController : ApiController
    {
        private readonly IHolidayService holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            this.holidayService = holidayService;
        }
        
        public IHttpActionResult Get()
        {
            var result = holidayService.Get();
            return Ok(result);
        }
        
        public IHttpActionResult Get(int id)
        {
            var result = holidayService.Get(id);
            return Ok(result);
        }
        
        public IHttpActionResult Create([FromBody]CreateHolidayApiRequest createHolidayRequest)
        {
            if (createHolidayRequest == null) return BadRequest();

            try
            {
                holidayService.Create(createHolidayRequest.Name);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
