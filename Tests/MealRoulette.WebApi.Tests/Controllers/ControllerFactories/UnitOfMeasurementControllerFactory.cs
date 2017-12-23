using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Controllers.Api;

namespace MealRoulette.WebApi.Tests.Controllers.ControllerFactories
{
    internal class UnitOfMesurementControllerFactory
    {
        private IUnitOfMeasurementService unitOfMeasurementService;

        internal UnitOfMesurementControllerFactory()
        {
            unitOfMeasurementService = null;
        }
                
        internal UnitOfMesurementControllerFactory WithUnitOfMeasurementService(IUnitOfMeasurementService service)
        {
            unitOfMeasurementService = service;
            return this;
        }

        internal UnitOfMeasurementController Build()
        {
            var controller = new UnitOfMeasurementController(unitOfMeasurementService);
            return controller;
        }
    }
}
