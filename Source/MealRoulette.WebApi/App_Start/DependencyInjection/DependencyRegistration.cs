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
            container.Register<IUnitOfWork, TestUnitOfWork>();
            container.Register<IIngredientRepository, TestIngredientRespository>();
            container.Register<IMealRepository, TestMealRepository>();
            container.Register<IMealCategoryRepository, TestMealCategoryRepository>();
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

        public TestUnitOfWork(IIngredientRepository ingredientRepository, IMealRepository mealRepository, IMealCategoryRepository mealCategoryRepository)
        {
            this.ingredientRepository = ingredientRepository;
            this.mealRepository = mealRepository;
            this.mealCategoryRepository = mealCategoryRepository;
        }

        public IIngredientRepository IngredientRepository => ingredientRepository;

        public IMealRepository MealRepository => mealRepository;

        public IMealCategoryRepository MealCategoryRepository => mealCategoryRepository;

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

        public IEnumerable<MealCategory> GetAll()
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

        public IEnumerable<Meal> GetAll()
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

        public IEnumerable<Ingredient> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IPage<Ingredient> GetPage(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }
    #endregion
}