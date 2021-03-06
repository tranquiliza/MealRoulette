﻿using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.App_Start;
using MealRoulette.WebApi.Controllers.Api;

namespace MealRoulette.WebApi.Tests.Controllers.ControllerFactories
{
    internal class MealControllerFactory
    {
        private IMealService mealService;

        internal MealControllerFactory()
        {
            mealService = null;
        }
                
        internal MealControllerFactory WithMealService(IMealService service)
        {
            mealService = service;
            return this;
        }

        internal MealController Build()
        {
            var controller = new MealController(mealService);
            return controller;
        }
    }
}
