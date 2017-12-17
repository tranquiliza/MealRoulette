using MealRoulette.Events.Abstractions;
using MealRoulette.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRoulette.Events
{
    public class DomainEventHandler : IDomainEventHandler
    {
        private readonly IMealRouletteService mealRouletteService;

        public DomainEventHandler(IMealRouletteService mealRouletteService)
        {
            this.mealRouletteService = mealRouletteService;
            this.mealRouletteService.MealSelectedEvent += MealRouletteService_RaiseMealSelectedEvent;
        }

        private void MealRouletteService_RaiseMealSelectedEvent(object sender, DomainEventArgs e)
        {
        }
    }
}
