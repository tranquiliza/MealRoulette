using MealRoulette.DataStructures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealRoulette.Repositories.Abstractions
{
    public interface IBaseRepository<T>
    {
        T Get(int id);

        IEnumerable<T> Get();

        Task<IEnumerable<T>> GetAsync();

        void Add(T entity);
        
        IPage<T> Get(int pageIndex, int pageSize);

        void Delete(int id);
    }
}
