using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using System;
using System.Collections.Generic;
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

        public IEnumerable<UnitOfMeasurement> Get()
        {
            return unitOfMeasurementService.Get();
        }
    }
}
