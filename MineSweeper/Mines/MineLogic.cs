using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class MineLogic : IMineLogic // ToDo: Better name??
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
                        gameGrid.GeneratedGameCell[row, column].IsMine = true;
                    }
                }
            }
        }

        public int CalculateAdjacentMineTotal(IGameGrid gameGrid, PlayerMove playerMove)
        {
            var adjacentMinesOutput = 0;

            var coordinateVariables = new List<int> {-1, 0, 1};

            foreach (var rowVariable in coordinateVariables)
            {
                foreach (var columnVariable in coordinateVariables)
                {
                    var row = playerMove.Row + rowVariable;
                    var column = playerMove.Column + columnVariable;
                    
                    if (GreaterThanLowerGridBoundary(row, column) && LesserThanUpperGridBoundary(row, column, gameGrid) 
                        && gameGrid.GeneratedGameCell[row, column].IsMine)
                    {
                        adjacentMinesOutput += 1;
                    }
                }
            }
            
            return adjacentMinesOutput;
        }

        private bool GreaterThanLowerGridBoundary(int row, int column)
        {
            var lowerBoundaryOutput = row >= 0 && column >= 0;

            return lowerBoundaryOutput;
        }

        private bool LesserThanUpperGridBoundary(int row, int column, IGameGrid gameGrid)
        {
            var upperBoundaryOutput = row < gameGrid.Size && column < gameGrid.Size;

            return upperBoundaryOutput;
        }
    }
}
