using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineGenerator : IMineGenerator
    {
        public IEnumerable<Cell> MineLocations(int gridSize)
        {
            var internalMineList = new List<Cell>();

            var newGameGrid = GridFactory.NewGameGrid(gridSize);
            newGameGrid.GenerateGrid(gridSize);

            for (var row = 0; row < gridSize; row++)
            {
                for (var column = 0; column < gridSize; column++)
                {
                    internalMineList.Add(newGameGrid.GeneratedGameCell[row, column]);
                }
            }

            IEnumerable<Cell> shuffledMineList = internalMineList.OrderBy(x => Guid.NewGuid()).ToList();
            
            return shuffledMineList;
        }
    }
}
// ToDo: when grid generated, output cells to list.
// ToDo: import list into mine logic, shuffle list then choose first [size] in list as mine location.