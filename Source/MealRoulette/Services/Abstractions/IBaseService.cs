using MealRoulette.DataStructures;
using System.Collections.Generic;

namespace MealRoulette.Services.Abstractions
{
    public interface IBaseService<T>
    {
        T Get(int id);

        IEnumerable<T> Get();

        IPage<T> Get(int pageIndex, int pageSize);

        void Delete(int id);
    }
}
