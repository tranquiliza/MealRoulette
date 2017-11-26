using MealRoulette.Domain.DataStructures;
using System.Collections.Generic;

namespace MealRoulette.Domain.Services.Abstractions
{
    public interface IBaseService<T>
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        IPage<T> GetPage(int pageIndex, int pageSize);

        void Delete(int id);
    }
}
