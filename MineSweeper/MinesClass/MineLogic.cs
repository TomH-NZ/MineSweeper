using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic
    {
        public void UpdateCellMineStatus(IEnumerable<Cell> mineLocations, IGameGrid gameGrid, int gridSize) // ToDo: Reduce  number of parameters being passed in.
        {// ToDo: If query to compare cell in mine list to cell in generated grid??
            var internalMines = mineLocations.ToList();
            for (var row = 0; row < gridSize; row++)
            {
                for (var column = 0; column < gridSize; column++)
                {
                    if (internalMines.Contains(gameGrid.GeneratedGameCell[row, column]))
                    {
                        gameGrid.GeneratedGameCell[row, column].IsAMine = true;
                    }
                }
            }
        }
    }
}
