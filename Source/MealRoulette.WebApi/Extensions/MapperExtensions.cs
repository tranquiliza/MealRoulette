using AutoMapper;
using MealRoulette.DataContracts;
using MealRoulette.DataStructures;
using MealRoulette.Models;
using MealRoulette.WebApi.Models.Meal;
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

        internal static MealApiModel Map(this Meal meal)
        {
            return Mapper.Map<MealApiModel>(meal);
        }

        internal static IPage<MealApiModel> Map(this IPage<Meal> source)
        {
            var mappedList = new List<MealApiModel>();
            foreach (var meal in source)
            {
                mappedList.Add(meal.Map());
            }

            var newList = new Page<MealApiModel>(mappedList, source.PageIndex, source.PageSize, source.TotalCount);
            return newList;
        }
    }
}