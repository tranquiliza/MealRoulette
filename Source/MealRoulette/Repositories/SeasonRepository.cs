using MealRoulette.DataAccess;
using MealRoulette.DataStructures;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRoulette.Repositories
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly IMealRouletteContext mealRouletteContext;
        private readonly DbSet<Season> seasons;

        public SeasonRepository(IMealRouletteContext mealRouletteContext)
        {
            this.mealRouletteContext = mealRouletteContext ?? throw new ArgumentNullException(nameof(mealRouletteContext));
            seasons = mealRouletteContext.Seasons;
        }

        void IBaseRepository<Season>.Add(Season entity)
        {
            seasons.Add(entity);
        }

        void IBaseRepository<Season>.Delete(int id)
        {
            var seasonToDelete = seasons.First(x => x.Id == id);
            seasons.Remove(seasonToDelete);
        }

        Season ISeasonRepository.Get(string name)
        {
            return seasons.FirstOrDefault(x => x.Name == name);
        }

        Season IBaseRepository<Season>.Get(int id)
        {
            return seasons.First(x => x.Id == id);
        }

        IEnumerable<Season> IBaseRepository<Season>.Get()
        {
            return seasons.ToList();
        }

        IPage<Season> IBaseRepository<Season>.Get(int pageIndex, int pageSize)
        {
            var totalCount = seasons.Count();
            var page = seasons.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new Page<Season>(page, pageIndex, pageSize, totalCount);
        }
    }
}
