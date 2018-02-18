using AutoMapper;
using MealRoulette.DataContracts;
using MealRoulette.Models;
using MealRoulette.WebApi.Models.Country;
using MealRoulette.WebApi.Models.HardwareCategory;
using MealRoulette.WebApi.Models.Ingredient;
using MealRoulette.WebApi.Models.Meal;
using MealRoulette.WebApi.Models.MealCategory;
using MealRoulette.WebApi.Models.MealIngredient;

namespace MealRoulette.WebApi.App_Start
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
                cfg.CreateMap<Country, CountryApiModel>();
                cfg.CreateMap<HardwareCategory, HardwareCategoryApiModel>();

                cfg.CreateMap<Meal, MealApiModel>()
                .ForMember(d => d.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(d => d.CountryOfOrigin, opts => opts.MapFrom(src => src.CountryOfOrigin))
                .ForMember(d => d.IsFastFood, opts => opts.MapFrom(src => src.IsFastFood))
                .ForMember(d => d.IsVegetarianFriendly, opts => opts.MapFrom(src => src.IsVegetarianFriendly))
                .ForMember(d => d.HardwareCategory, opts => opts.MapFrom(src => src.HardwareCategory))
                .ForMember(d => d.Holiday, opts => opts.MapFrom(src => src.Holiday))
                .ForMember(d => d.Recipe, opts => opts.MapFrom(src => src.Recipe))
                .ForMember(d => d.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(d => d.MealCategory, opts => opts.MapFrom(src => src.MealCategory))
                .ForMember(d => d.MealIngredients, opts => opts.MapFrom(src => src.MealIngredients));
            });
        }
    }
}