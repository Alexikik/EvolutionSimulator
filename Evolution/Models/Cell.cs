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
        public int Healph { get; set; }

        public Cell()
        {
            Food = 100;
            Healph = 100;
        }

        public async Task DoTick(int foodGotten)
        {
            await CheckHeaph();
            
            Food += foodGotten - 1;

            if (Food < 25)
            {
                Healph--;
            }
        }

        private async Task CheckHeaph()
        {
            if (Healph <= 0)
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
