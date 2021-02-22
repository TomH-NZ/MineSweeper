using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineGenerator : IMineGenerator
    {
        public List<string> MineLocations(int gridSize)
        {
            var internalMineList = new List<string>();

            for (var index = 0; index < gridSize; index++)
            {
                var randomMineRow = new Random().Next(0, gridSize);
                var randomMineColumn = new Random().Next(0, gridSize);

                var mine = randomMineRow.ToString() + "," + randomMineColumn.ToString();
                internalMineList.Add(mine);
            }
            
            return internalMineList;
        }
    }
}