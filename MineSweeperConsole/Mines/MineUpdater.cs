using System.Collections.Generic;
using MineSweeper.Grid;
using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Mines
{
    public class MineUpdater : IMineUpdater
    {
        public void UpdateCellWithMineStatus(List<Cell> mineLocations, IGameGrid gameGrid)
        {
            for (var row = 0; row < gameGrid.Size; row++)
            {
                for (var column = 0; column < gameGrid.Size; column++)
                {
                    if (mineLocations.Contains(gameGrid.GeneratedGameCell[row,column]))
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
            return row >= 0 && column >= 0;
        }

        private bool LesserThanUpperGridBoundary(int row, int column, IGameGrid gameGrid)
        {
            return row < gameGrid.Size && column < gameGrid.Size;
        }
    }
}
