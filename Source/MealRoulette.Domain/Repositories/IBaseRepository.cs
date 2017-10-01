using MealRoulette.Domain.Repositories.DataStructures;
using System.Collections.Generic;

namespace MealRoulette.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        T Get(string name);
        T Get(int id);
        void Add(T entity);
        IEnumerable<T> GetAll();
        IPage<T> GetPage(int index, int size);
        void Delete(T entity);
    }
}
