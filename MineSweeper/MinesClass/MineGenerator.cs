using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineGenerator : IMineGenerator // ToDo: look into writing test for this class.
    {
        public List<string> MineLocations(int gridSize)
        {
            var internalMineList = new List<string>();

            for (var index = 0; index < gridSize; index++) //ToDo: add validation so mines don't repeat on same square
            {
                var randomMineRow = new Random().Next(0, gridSize);
                var randomMineColumn = new Random().Next(0, gridSize);

                var mine = randomMineRow + "," + randomMineColumn; // ToDo: Change to 2d array??
                internalMineList.Add(mine);
            }
            
            return internalMineList;
        }
    }
}