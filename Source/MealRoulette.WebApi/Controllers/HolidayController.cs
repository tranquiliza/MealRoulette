using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.WebApi.Models.Holiday;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers
{
    public class HolidayController : ApiController
    {
        private readonly IHolidayService holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            this.holidayService = holidayService;
        }

        [HttpGet]
        public IEnumerable<Holiday> Get()
        {
            var result = holidayService.Get();
            return result;
        }

        [HttpGet]
        public Holiday Get(int id)
        {
            var result = holidayService.Get(id);
            return result;
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]CreateHolidayApiRequest createHolidayRequest)
        {
            try
            {
                holidayService.Create(createHolidayRequest.Name);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
