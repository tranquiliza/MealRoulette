using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRoulette.DataAccess.Repository
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly MealRouletteContext mealRouletteContext;
        private readonly DbSet<Season> season;

        public SeasonRepository(MealRouletteContext mealRouletteContext)
        {
            this.mealRouletteContext = mealRouletteContext ?? throw new ArgumentNullException(nameof(mealRouletteContext));
            season = mealRouletteContext.Seasons;
        }

        void IBaseRepository<Season>.Add(Season entity)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<Season>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Season ISeasonRepository.Get(string name)
        {
            throw new NotImplementedException();
        }

        Season IBaseRepository<Season>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Season> IBaseRepository<Season>.Get()
        {
            throw new NotImplementedException();
        }

        IPage<Season> IBaseRepository<Season>.GetPage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
