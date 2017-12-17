using MealRoulette.DataStructures;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Services
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
            var mealCategory = mealCategoryRepository.Get(name);
            if (mealCategory != null) throw new DomainException($"Mealcategory named {name} already exists");

            mealCategory = new MealCategory(name);

            mealCategoryRepository.Add(mealCategory);

            unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            mealCategoryRepository.Delete(id);

            unitOfWork.SaveChanges();
        }

        public MealCategory Get(int id)
        {
            var category = mealCategoryRepository.Get(id);
            return category;
        }

        public IEnumerable<MealCategory> Get()
        {
            var categories = mealCategoryRepository.Get();
            return categories;
        }

        public IPage<MealCategory> Get(int pageIndex, int pageSize)
        {
            var page = mealCategoryRepository.Get(pageIndex, pageSize);
            return page;
        }
    }
}
