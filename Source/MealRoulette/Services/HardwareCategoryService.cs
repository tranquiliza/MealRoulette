using MealRoulette.DataStructures;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Services
{
    public class HardwareCategoryService : IHardwareCategoryService
    {
        private readonly IUnitOfWork _UnitOfWork;

        private readonly IHardwareCategoryRepository _HardwareCategoryRepository;

        public HardwareCategoryService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            _HardwareCategoryRepository = unitOfWork.HardwareRepository;
        }

        void IBaseService<HardwareCategory>.Delete(int id)
        {
            _HardwareCategoryRepository.Delete(id);
            _UnitOfWork.SaveChanges();
        }

        HardwareCategory IHardwareCategoryService.Get(string name)
        {
            return _HardwareCategoryRepository.Get(name);
        }

        HardwareCategory IBaseService<HardwareCategory>.Get(int id)
        {
            return _HardwareCategoryRepository.Get(id);
        }

        IEnumerable<HardwareCategory> IBaseService<HardwareCategory>.Get()
        {
            return _HardwareCategoryRepository.Get();
        }

        IPage<HardwareCategory> IBaseService<HardwareCategory>.Get(int pageIndex, int pageSize)
        {
            return _HardwareCategoryRepository.Get(pageIndex, pageSize);
        }
    }
}
