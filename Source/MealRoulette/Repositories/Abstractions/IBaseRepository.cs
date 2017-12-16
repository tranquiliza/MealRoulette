using MealRoulette.Domain.DataStructures;
using System.Collections.Generic;

namespace MealRoulette.Domain.Repositories.Abstractions
{
    public interface IBaseRepository<T>
    {
        T Get(int id);

        IEnumerable<T> Get();

        void Add(T entity);
        
        IPage<T> Get(int pageIndex, int pageSize);

        void Delete(int id);
    }
}
