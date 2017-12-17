using System;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Controllers;

namespace MealRoulette.WebApi.Tests.Controllers.ControllerFactories
{
    internal class HolidayControllerFactory
    {
        private IHolidayService holidayService;

        internal HolidayControllerFactory()
        {
            holidayService = null;
        }
                
        internal HolidayControllerFactory WithHolidayService(IHolidayService service)
        {
            holidayService = service;
            return this;
        }

        internal HolidayController Build()
        {
            var controller = new HolidayController(holidayService);
            return controller;
        }
    }
}
