using MealRoulette.DataStructures;

namespace MealRoulette.WebApi.Models.Meal
{
    public class MealPageResponse
    {
        public IPage<MealRoulette.Models.Meal> Meals { get; set; }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPageCount { get; private set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

        public MealPageResponse(IPage<MealRoulette.Models.Meal> meals)
        {
            Meals = meals;
            PageIndex = meals.PageIndex;
            PageSize = meals.PageSize;
            TotalCount = meals.TotalCount;
            TotalPageCount = meals.TotalPageCount;
            HasPreviousPage = meals.HasPreviousPage;
            HasNextPage = meals.HasNextPage;
        }
    }
}