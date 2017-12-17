using AutoMapper;
using MealRoulette.DataContracts;
using MealRoulette.WebApi.Models.MealCategory;
using MealRoulette.WebApi.Models.MealIngredient;
using System.Collections.Generic;

namespace MealRoulette.WebApi.Extensions
{
    internal static class MapperExtensions
    {
        internal static MealCategoryDto Map(this MealCategoryApiModel model)
        {
            return Mapper.Map<MealCategoryDto>(model);
        }

        internal static MealIngredientDto Map(this MealIngredientApiModel model)
        {
            return Mapper.Map<MealIngredientDto>(model);
        }

        internal static IEnumerable<MealIngredientDto> Map(this IEnumerable<MealIngredientApiModel> models)
        {
            var result = new List<MealIngredientDto>();

            foreach (var model in models)
            {
                result.Add(model.Map());
            }

            return result;
        }
    }
}