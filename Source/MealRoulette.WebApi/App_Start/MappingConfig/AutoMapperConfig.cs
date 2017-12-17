using AutoMapper;
using MealRoulette.DataContracts;
using MealRoulette.Models;
using MealRoulette.WebApi.Models.Ingredient;
using MealRoulette.WebApi.Models.MealCategory;
using MealRoulette.WebApi.Models.MealIngredient;

namespace MealRoulette.WebApi.App_Start.MappingConfig
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IngredientApiModel, IngredientDto>();
                cfg.CreateMap<MealIngredientApiModel, MealIngredientDto>();
                cfg.CreateMap<MealCategoryApiModel, MealCategoryDto>();
                cfg.CreateMap<MealIngredientDto, MealIngredient>();
            });

        }
    }
}