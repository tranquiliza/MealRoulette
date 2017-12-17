using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MealRoulette.WebApi.Controllers
{
    public class MealRouletteController : ApiController
    {
        private readonly IMealRouletteService mealRouletteService;

        public MealRouletteController(IMealRouletteService mealRouletteService)
        {
            this.mealRouletteService = mealRouletteService;
        }

        public Meal Get()
        {
            return mealRouletteService.RollMeal();
        }
    }
}
