using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Domain.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository holidayRepository;

        private readonly IUnitOfWork unitOfWork;

        public HolidayService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            holidayRepository = unitOfWork.HolidayRepository;
        }

        void IHolidayService.Create(string name)
        {
            if(SeasonAlreadyExists(name)) throw new DomainException($"Holiday with {name}, already exists");

            var holiday = new Holiday(name);

            holidayRepository.Add(holiday);
        }

        private bool SeasonAlreadyExists(string name)
        {
            return holidayRepository.Get(name) != null;
        }

        void IBaseService<Holiday>.Delete(int id)
        {
            holidayRepository.Delete(id);
        }

        Holiday IBaseService<Holiday>.Get(int id)
        {
            return holidayRepository.Get(id);
        }

        IEnumerable<Holiday> IBaseService<Holiday>.Get()
        {
            return holidayRepository.Get();
        }

        IPage<Holiday> IBaseService<Holiday>.GetPage(int pageIndex, int pageSize)
        {
            return holidayRepository.GetPage(pageIndex, pageSize);
        }
    }
}
