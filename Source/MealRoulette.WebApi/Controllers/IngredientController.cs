using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MealRoulette.Domain.DomainServices.Abstractions;
using MealRoulette.Domain.Models;

namespace MealRoulette.WebApi.Controllers
{
    public class IngredientController : ApiController
    {
        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }


        public Ingredient Get(int id)
        {
            var result = ingredientService.Get(id);
            return result;
        }
    }
}
