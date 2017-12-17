using MealRoulette.DataStructures;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Services
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

            unitOfWork.SaveChanges();
        }

        private bool SeasonAlreadyExists(string name)
        {
            return holidayRepository.Get(name) != null;
        }

        void IBaseService<Holiday>.Delete(int id)
        {
            holidayRepository.Delete(id);

            unitOfWork.SaveChanges();
        }

        Holiday IBaseService<Holiday>.Get(int id)
        {
            return holidayRepository.Get(id);
        }

        IEnumerable<Holiday> IBaseService<Holiday>.Get()
        {
            return holidayRepository.Get();
        }

        IPage<Holiday> IBaseService<Holiday>.Get(int pageIndex, int pageSize)
        {
            return holidayRepository.Get(pageIndex, pageSize);
        }
    }
}
