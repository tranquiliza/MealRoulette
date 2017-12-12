using System.Collections.Generic;
using AutoMapper;
using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services;
using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.WebApi.App_Start.MappingConfig;
using SimpleInjector;

namespace MealRoulette.WebApi.App_Start.DependencyInjection
{
    public static class DependencyRegistration
    {
        public static void RegisterTypesToContainer(Container container)
        {
            //Repositories
            container.Register<IUnitOfWork, TestUnitOfWork>();
            container.Register<IMealRepository, TestMealRepository>();
            container.Register<IIngredientRepository, TestIngredientRespository>();
            container.Register<IMealCategoryRepository, TestMealCategoryRepository>();
            container.Register<IHolidayRepository, TestHolidayRepository>();
            container.Register<ISeasonRepository, TestSeasonRepository>();

            //Services
            container.Register<IHolidayService, HolidayService>();
            container.Register<IMealCategoryService, MealCategoryService>();
            container.Register<IMealService, MealService>();
        }
    }

    #region .TestClassesForRunningTheAPI.
    internal class TestUnitOfWork : IUnitOfWork
    {
        private readonly IIngredientRepository ingredientRepository;
        private readonly IMealRepository mealRepository;
        private readonly IMealCategoryRepository mealCategoryRepository;
        private readonly IHolidayRepository holidayRepository;
        private readonly ISeasonRepository seasonRepository;

        public TestUnitOfWork(IIngredientRepository ingredientRepository, IMealRepository mealRepository, IMealCategoryRepository mealCategoryRepository, IHolidayRepository holidayRepository, ISeasonRepository seasonRepository)
        {
            this.ingredientRepository = ingredientRepository;
            this.mealRepository = mealRepository;
            this.mealCategoryRepository = mealCategoryRepository;
            this.holidayRepository = holidayRepository;
            this.seasonRepository = seasonRepository;
        }

        public IIngredientRepository IngredientRepository => ingredientRepository;

        public IMealRepository MealRepository => mealRepository;

        public IMealCategoryRepository MealCategoryRepository => mealCategoryRepository;

        public IHolidayRepository HolidayRepository => holidayRepository;

        public ISeasonRepository SeasonRepository => seasonRepository;

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }

    internal class TestMealCategoryRepository : IMealCategoryRepository
    {
        public void Add(MealCategory entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public MealCategory Find(string name)
        {
            throw new System.NotImplementedException();
        }

        public MealCategory Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public MealCategory Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MealCategory> Get()
        {
            throw new System.NotImplementedException();
        }

        public IPage<MealCategory> GetPage(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }

    internal class TestMealRepository : IMealRepository
    {
        public void Add(Meal entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Meal Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public Meal Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Meal> Get()
        {
            throw new System.NotImplementedException();
        }

        public IPage<Meal> GetPage(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }

    internal class TestIngredientRespository : IIngredientRepository
    {
        public void Add(Ingredient entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Ingredient Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public Ingredient Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ingredient> Get()
        {
            throw new System.NotImplementedException();
        }

        public IPage<Ingredient> GetPage(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }

    internal class TestSeasonRepository : ISeasonRepository
    {
        void IBaseRepository<Season>.Add(Season entity)
        {
            throw new System.NotImplementedException();
        }

        void IBaseRepository<Season>.Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        Season IBaseRepository<Season>.Get(string name)
        {
            throw new System.NotImplementedException();
        }

        Season IBaseRepository<Season>.Get(int id)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Season> IBaseRepository<Season>.Get()
        {
            throw new System.NotImplementedException();
        }

        IPage<Season> IBaseRepository<Season>.GetPage(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }

    internal class TestHolidayRepository : IHolidayRepository
    {
        void IBaseRepository<Holiday>.Add(Holiday entity)
        {
            throw new System.NotImplementedException();
        }

        void IBaseRepository<Holiday>.Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        Holiday IBaseRepository<Holiday>.Get(string name)
        {
            throw new System.NotImplementedException();
        }

        Holiday IBaseRepository<Holiday>.Get(int id)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Holiday> IBaseRepository<Holiday>.Get()
        {
            throw new System.NotImplementedException();
        }

        IPage<Holiday> IBaseRepository<Holiday>.GetPage(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }
    #endregion
}