using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic
    {
        public void UpdateCellWithMineStatus(IEnumerable<Cell> mineLocations, IGameGrid gameGrid)
        {
            var inputMineLocations = mineLocations.ToList();

            for (var row = 0; row < gameGrid.Size; row++)
            {
                for (var column = 0; column < gameGrid.Size; column++)
                {
                    if (inputMineLocations.Contains(gameGrid.GeneratedGameCell[row,column]))
                    {
                        gameGrid.GeneratedGameCell[row, column].IsAMine = true;
                    }
                }
            }
        }

        public int CalculateAdjacentMineTotal(IGameGrid gameGrid, string playerMove) // ToDo: Need to take into account max and min size of board, ie: >= 0, <= grid.Size
        {
            var inputMove = playerMove.Split(',');
            var adjacentMinesOutput = 0;
            int.TryParse(inputMove[0], out var row);
            int.TryParse(inputMove[1], out var column);

            if (row - 1 >= 0 && column - 1 >= 0 && row - 1 < gameGrid.Size && column - 1 < gameGrid.Size && gameGrid.GeneratedGameCell[row - 1, column - 1].IsAMine)
            { 
                adjacentMinesOutput += 1;
            } 
            // ToDo: name -1 as previous, +1 as next
            // ToDo: Nested foreach loops?? variable to list of int.
            // ToDo: Possibly calculate each position and add to 2d array, check out of bounds and IsAMine.
            // ToDo: after integrating adjacent mine logic start writing user input process
            
            if (row - 1 >= 0 && column >= 0 && row - 1 < gameGrid.Size && column < gameGrid.Size && gameGrid.GeneratedGameCell[row - 1, column].IsAMine)
            {
                adjacentMinesOutput += 1;
            }
            if (row - 1 >= 0 && column + 1 >= 0 && row - 1 < gameGrid.Size && column + 1 < gameGrid.Size && gameGrid.GeneratedGameCell[row - 1, column + 1].IsAMine)
            {
                adjacentMinesOutput += 1;
            }
            if (row >= 0 && column - 1 >= 0 && row < gameGrid.Size && column - 1 < gameGrid.Size && gameGrid.GeneratedGameCell[row, column - 1].IsAMine)
            {
                adjacentMinesOutput += 1;
            }
            if (row >= 0 && column + 1 >= 0 && row < gameGrid.Size && column + 1 < gameGrid.Size &&  gameGrid.GeneratedGameCell[row, column + 1].IsAMine)
            {
                adjacentMinesOutput += 1;
            }
            if (row + 1 >= 0 && column - 1 >= 0 && row + 1 < gameGrid.Size && column - 1 < gameGrid.Size &&  gameGrid.GeneratedGameCell[row + 1, column - 1].IsAMine)
            {
                adjacentMinesOutput += 1;
            }
            if (row + 1 >= 0 && column >= 0 && row + 1 < gameGrid.Size && column < gameGrid.Size &&  gameGrid.GeneratedGameCell[row + 1, column].IsAMine)
            {
                adjacentMinesOutput += 1;
            }
            if (row + 1 >= 0 && column + 1 >= 0 && row + 1 < gameGrid.Size && column + 1 < gameGrid.Size &&  gameGrid.GeneratedGameCell[row + 1, column + 1].IsAMine)
            {
                adjacentMinesOutput += 1;
            }
            
            return adjacentMinesOutput;
        }
    }
}

/*Possible method to use to calculate if input between two values. hardcode in 0, input gridSize.
    
public static bool Between(this int num, int lower, int upper, bool inclusive = false)
{
    return inclusive
        ? lower <= num && num <= upper
        : lower < num && num < upper;
}*/
