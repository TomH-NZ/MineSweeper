using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineGenerator : IMineGenerator
    {
        public List<Cell> MineLocations(int gridSize)
        {
            var generatedMineList = new List<Cell>();
            var gameGrid = GridFactory.NewGameGrid(gridSize);
            gameGrid.GenerateGrid(gridSize);

            for (var row = 0; row < gridSize; row++)
            {
                for (var column = 0; column < gridSize; column++)
                {
                    generatedMineList.Add(gameGrid.GeneratedGameCell[row, column]);
                }
            }
            var convertedMineList = generatedMineList.OrderBy(x => Guid.NewGuid()).ToList().Take(gridSize);
            
            return generatedMineList;
        }
    }
}
