using MealRoulette.DataStructures;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _UnitOfWork;

        private readonly ICountryRepository _CountryRepository;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            _CountryRepository = unitOfWork.CountryRepository;
        }

        void IBaseService<Country>.Delete(int id)
        {
            _CountryRepository.Delete(id);

            _UnitOfWork.SaveChanges();
        }

        Country ICountryService.Get(string name)
        {
            return _CountryRepository.Get(name);
        }

        Country IBaseService<Country>.Get(int id)
        {
            return _CountryRepository.Get(id);
        }

        IEnumerable<Country> IBaseService<Country>.Get()
        {
            return _CountryRepository.Get();
        }

        IPage<Country> IBaseService<Country>.Get(int pageIndex, int pageSize)
        {
            return _CountryRepository.Get(pageIndex, pageSize);
        }
    }
}
