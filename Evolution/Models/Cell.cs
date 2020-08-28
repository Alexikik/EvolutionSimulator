using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolution.Models
{
    public class Cell
    {
        public bool Alive { get; set; } = true;

        public int Food { get; set; }
        public int Health { get; set; }

        public Cell()
        {
            Food = 100;
            Health = 100;
        }

        public async Task DoTick(int foodGotten)
        {
            await CheckHealth();
            
            Food += foodGotten - 1;

            if (Food < 25)
            {
                Health--;
            }
        }

        private async Task CheckHealth()
        {
            if (Health <= 0)
            {
                await Die();
            }
        }

        private async Task Die()
        {
            Alive = false;
        }
    }
}
