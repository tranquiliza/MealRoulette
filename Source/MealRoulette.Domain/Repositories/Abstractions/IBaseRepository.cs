using MealRoulette.Domain.DataStructures;
using System.Collections.Generic;

namespace MealRoulette.Domain.Repositories.Abstractions
{
    public interface IBaseRepository<T>
    {
        T Get(string name);

        T Get(int id);

        void Add(T entity);

        IEnumerable<T> GetAll();

        IPage<T> GetPage(int pageIndex, int pageSize);

        void Delete(int id);
    }
}
