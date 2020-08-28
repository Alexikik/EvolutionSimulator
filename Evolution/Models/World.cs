using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolution.Models
{
    public class World
    {
        public  List<Food> FoodList { get; set; }
        private int _startFoodAmount { get; set; }
        private int _foodPerTick { get; set; }

        public World(int startFoodAmout, int foodPerTick)
        {
            _startFoodAmount = startFoodAmout;
            _foodPerTick = foodPerTick;

            Initialize();
        }

        private async Task Initialize()
        {
            FoodList = new List<Food>();
            for (int i = 0; i < 100; i++)
            {
                FoodList.Add(new Food());
            }
        }

        public async Task DoTick()
        {
            FoodList.Clear();

            for (int i = 0; i < 50; i++)
            {
                FoodList.Add(new Food());
            }
        }
    }
}
