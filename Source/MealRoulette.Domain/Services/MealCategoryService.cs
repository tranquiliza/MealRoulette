using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Domain.Services
{
    public class MealCategoryService : IMealCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMealCategoryRepository mealCategoryRepository;

        public MealCategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            mealCategoryRepository = unitOfWork.MealCategoryRepository;
        }

        public void Create(string name)
        {
            var mealCategory = mealCategoryRepository.Find(name);
            if (mealCategory != null) throw new DomainException($"Mealcategory named {name} already exists");

            mealCategory = new MealCategory(name);

            mealCategoryRepository.Add(mealCategory);
        }

        public void Delete(int id)
        {
            mealCategoryRepository.Delete(id);
        }

        public MealCategory Get(int id)
        {
            var category = mealCategoryRepository.Get(id);
            return category;
        }

        public IEnumerable<MealCategory> GetAll()
        {
            var categories = mealCategoryRepository.GetAll();
            return categories;
        }

        public IPage<MealCategory> GetPage(int pageIndex, int pageSize)
        {
            var page = mealCategoryRepository.GetPage(pageIndex, pageSize);
            return page;
        }
    }
}
