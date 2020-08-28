using Evolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolution.DTOs
{
    public class TickResultDTO
    {
        public List<Cell> NewDeadCells { get; set; }

        public TickResultDTO(List<Cell> newDeadCells = null)
        {
            if (newDeadCells == null)
            {
                newDeadCells = new List<Cell>();
            }
            NewDeadCells = newDeadCells;


        }
    }
}
