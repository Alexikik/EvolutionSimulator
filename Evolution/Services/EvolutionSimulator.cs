using Evolution.DTOs;
using Evolution.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Timers;

namespace Evolution.Services
{
    public class EvolutionSimulator
    {
        private int _tick;

        public int Tick { get => _tick; set => _tick = value; }
        public bool Done { get; set; } = false;
        private List<Cell> CellList { get; set; }
        private List<Cell> DeadCellList { get; set; }
        private Timer timer { get; set; }
        public World World { get; set; }


        public EvolutionSimulator()
        {
            Initialize();
        }

        private void Initialize()
        {
            CellList = new List<Cell>();
            DeadCellList = new List<Cell>();
            World = new World(100, 50);

            for (int i = 0; i < 100; i++)
            {
                CellList.Add(new Cell());
            }
        }

        public async Task<TickResultDTO> Start()
        {
            TickResultDTO tickResultDTO = new TickResultDTO();
            timer = new System.Timers.Timer(5);

            timer.Elapsed += DoTick;

            timer.Start();

            return tickResultDTO;
        }

        private async void DoTick(Object source, ElapsedEventArgs e)
        {
            // Pre tick
            Tick++;

            if (Tick >= 10000
                || Done)
            {
                Stop();
            }
            else
            {
                if (CellList.Where(c => c.Alive == false).Any())
                {
                    List<Cell> newDeadCells = CellList.Where(c => c.Alive == false).ToList();

                    DeadCellList.AddRange(newDeadCells);

                    foreach (Cell cell in newDeadCells)
                        CellList.Remove(cell);
                }

            }

            // Action
            //CellList.ForEach(async c => await c.DoTick(1));
            foreach (var item in CellList)
            {
                int foodTaken = 0;

                try
                {
                    if (World.FoodList.Count > 0)
                    {
                        World.FoodList.RemoveAt(World.FoodList.Count());

                        foodTaken = 1;
                    }
                }
                catch (Exception)
                { }


                //await item.DoTick(foodTaken);
                await item.DoTick(0);
            }

            // Post tick
        }

        private void Stop()
        {
            timer.Stop();

            Console.WriteLine($"Cells left: {CellList.Count}");
            Done = true;
        }

        //private async void CellDeath(Object source, ElapsedEventArgs e)
        //{

        //}
    }
}
