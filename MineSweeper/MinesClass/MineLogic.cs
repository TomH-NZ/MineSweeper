using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic
    {
        public void UpdateCellWithMineStatus(List<Cell> mineLocations, IGameGrid gameGrid)
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

        public int CalculateAdjacentMineTotal(IGameGrid gameGrid, string playerMove)
        {
            var inputMove = playerMove.Split(',');
            var adjacentMinesOutput = 0;
            int.TryParse(inputMove[0], out var row);
            int.TryParse(inputMove[1], out var column);

            var coordinateVariables = new List<int> {-1, 0, 1};

            foreach (var rowVariable in coordinateVariables)
            {
                foreach (var columnVariable in coordinateVariables)  // ToDo: rowInput = (row + rowVariable), columnInput = (column + columnVariable), pass to upper and lower methods. 
                {
                    var rowInput = row + rowVariable;
                    var columnInput = column + columnVariable;
                    
                    if (GreaterThanLowerGridBoundary(rowInput, columnInput) && LesserThanUpperGridBoundary(rowInput, columnInput, gameGrid) 
                        && gameGrid.GeneratedGameCell[rowInput, columnInput].IsAMine)
                    {
                        adjacentMinesOutput += 1;
                    }
                }
            }
            
            return adjacentMinesOutput;
        }

        private bool GreaterThanLowerGridBoundary(int row, int column) // ToDo: reduce number of input variables.  how?
        {
            var lowerBoundaryOutput = row >= 0 && column >= 0;

            return lowerBoundaryOutput;
        }

        private bool LesserThanUpperGridBoundary(int row, int column, IGameGrid gameGrid) // ToDo: reduce number of input variables.  how?
        {
            var upperBoundaryOutput = row < gameGrid.Size && column < gameGrid.Size;

            return upperBoundaryOutput;
        }
    }
}
