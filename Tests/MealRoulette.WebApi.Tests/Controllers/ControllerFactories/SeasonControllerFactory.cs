using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Controllers;

namespace MealRoulette.WebApi.Tests.Controllers.ControllerFactories
{
    internal class SeasonControllerFactory
    {
        private ISeasonService seasonService;

        internal SeasonControllerFactory()
        {
            seasonService = null;
        }
                
        internal SeasonControllerFactory WithSeasonService(ISeasonService service)
        {
            seasonService = service;
            return this;
        }

        internal SeasonController Build()
        {
            var controller = new SeasonController(seasonService);
            return controller;
        }
    }
}
