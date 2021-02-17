using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01// check names in namespace, look at removing 'class' from the name/directory structure.
{
    public class MineGenerator : IMineGenerator
    {
        public List<Cell> MineLocations(int gridSize)
        {
            var internalMineList = new List<Cell>();

            for (var index = 0; index < gridSize; index++)
            {
                var randomMineRow = new Random().Next(0, gridSize);
                var randomMineColumn = new Random().Next(0, gridSize);

                var mine = new Cell(randomMineRow, randomMineColumn, CellStatus.OccupiedByMine);
                internalMineList.Add(mine);
            }
            
            return internalMineList;
        }
    }
}