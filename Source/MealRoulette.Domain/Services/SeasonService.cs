using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Domain.Services
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
        }

        private bool SeasonAlreadyExists(string name)
        {
            return seasonRepository.Get(name) != null;
        }

        void IBaseService<Season>.Delete(int id)
        {
            seasonRepository.Delete(id);
        }

        Season IBaseService<Season>.Get(int id)
        {
            return seasonRepository.Get(id);
        }

        IEnumerable<Season> IBaseService<Season>.Get()
        {
            return seasonRepository.Get();
        }

        IPage<Season> IBaseService<Season>.GetPage(int pageIndex, int pageSize)
        {
            return seasonRepository.GetPage(pageIndex, pageSize);
        }
    }
}
