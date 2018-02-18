using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Extensions;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers
{
    public class CountryController : ApiController
    {
        private readonly ICountryService _CountryService;

        public CountryController(ICountryService countryService)
        {
            _CountryService = countryService;
        }

        public IHttpActionResult Get()
        {
            var countries = _CountryService.Get();
            return Ok(countries.Map());
        }

        public IHttpActionResult Get(int id)
        {
            var result = _CountryService.Get(id);
            return Ok(result.Map());
        }
    }
}
