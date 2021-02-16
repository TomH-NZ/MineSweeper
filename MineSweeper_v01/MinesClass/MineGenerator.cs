using System;
using System.Collections.Generic;
using MineSweeper_v01.GridClass;

namespace MineSweeper_v01.MinesClass 
{
    public class MineGenerator : IMineGenerator
    {
        public List<Cell> ObjectLocations(int gridSize)
        {
            var internalMineList = new List<Cell>();

            for (var index = 0; index < gridSize; index++)
            {
                var randomMineRow = new Random().Next(0, gridSize);
                var randomMineColumn = new Random().Next(0, gridSize);

                var mine = new Cell(randomMineRow, randomMineColumn) {OccupiedByMine = true};
                internalMineList.Add(mine);
            }
            
            return internalMineList;
        }
    }
}