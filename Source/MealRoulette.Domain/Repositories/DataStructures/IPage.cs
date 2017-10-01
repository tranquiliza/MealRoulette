using System.Collections.Generic;

namespace MealRoulette.Domain.Repositories.DataStructures
{
    public interface IPage<T> : IList<T>
    {
        bool HasNextPage { get; }
        bool HasPreviousPage { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPageCount { get; }
    }
}
