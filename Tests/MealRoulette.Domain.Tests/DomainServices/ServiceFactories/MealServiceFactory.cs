using MealRoulette.Domain.DomainServices;
using MealRoulette.Domain.Repositories;

namespace MealRoulette.Domain.Tests.DomainServices.ServiceFactories
{
    public class MealServiceFactory
    {
        private IIngredientRepository _ingredientRepository;
        private IMealCategoryRepository _mealCategoryRepository;
        private IMealRepository _mealRepository;


        public MealServiceFactory Create()
        {
            _ingredientRepository = null;
            _mealCategoryRepository = null;
            _mealRepository = null;
            return this;
        }

        public MealServiceFactory WithIngredientRepo(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
            return this;
        }

        public MealServiceFactory WithMealCategoryRepo(IMealCategoryRepository mealCategoryRepository)
        {
            _mealCategoryRepository = mealCategoryRepository;
            return this;
        }

        public MealServiceFactory WithMealRepo(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
            return this;
        }

        public MealService Build()
        {
            var mealService = new MealService(_mealRepository, _mealCategoryRepository, _ingredientRepository);
            return mealService;
        }
    }
}
