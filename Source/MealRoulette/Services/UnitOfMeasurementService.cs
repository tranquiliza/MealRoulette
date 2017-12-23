using MealRoulette.DataStructures;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services.Abstractions;
using System.Collections.Generic;

namespace MealRoulette.Services
{
    public class UnitOfMeasurementService : IUnitOfMeasurementService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IUnitOfMeasurementRepository UnitOfMeasurementRepository;

        public UnitOfMeasurementService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            UnitOfMeasurementRepository = unitOfWork.UnitOfMeasurementRepository;
        }

        void IBaseService<UnitOfMeasurement>.Delete(int id)
        {
            UnitOfMeasurementRepository.Delete(id);
        }

        UnitOfMeasurement IBaseService<UnitOfMeasurement>.Get(int id)
        {
            return UnitOfMeasurementRepository.Get(id);
        }

        IEnumerable<UnitOfMeasurement> IBaseService<UnitOfMeasurement>.Get()
        {
            return UnitOfMeasurementRepository.Get();
        }

        IPage<UnitOfMeasurement> IBaseService<UnitOfMeasurement>.Get(int pageIndex, int pageSize)
        {
            return UnitOfMeasurementRepository.Get(pageIndex, pageSize);
        }
    }
}
