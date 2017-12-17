using MealRoulette.DataStructures;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISeasonRepository seasonRepository;

        public SeasonService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            seasonRepository = unitOfWork.SeasonRepository;
        }

        void ISeasonService.Create(string name)
        {
            if (SeasonAlreadyExists(name)) throw new DomainException($"Season {name}, already exists");

            var season = new Season(name);

            seasonRepository.Add(season);

            unitOfWork.SaveChanges();
        }

        private bool SeasonAlreadyExists(string name)
        {
            return seasonRepository.Get(name) != null;
        }

        void IBaseService<Season>.Delete(int id)
        {
            seasonRepository.Delete(id);

            unitOfWork.SaveChanges();
        }

        Season IBaseService<Season>.Get(int id)
        {
            return seasonRepository.Get(id);
        }

        IEnumerable<Season> IBaseService<Season>.Get()
        {
            return seasonRepository.Get();
        }

        IPage<Season> IBaseService<Season>.Get(int pageIndex, int pageSize)
        {
            return seasonRepository.Get(pageIndex, pageSize);
        }
    }
}
