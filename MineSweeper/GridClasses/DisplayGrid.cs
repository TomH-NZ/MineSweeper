using System;
using MineSweeper_v01.Enums;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class DisplayGrid : IDisplayGrid 
    {
        //For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.
        //Player move is always entered as Row then Column.

        public string GenerateGameDisplay(IGameGrid initialGameGrid) // ToDo: Singleton pattern??
        {
            var outputGrid = "";
            initialGameGrid.GenerateGrid(initialGameGrid.Size); // ToDo: Move grid generation outside method so it can be called repeatedly without creating a new grid each time.

            for (var row = 0; row < initialGameGrid.Size; row++)
            {
                for (var column = 0; column < initialGameGrid.Size; column++)
                {
                    if (initialGameGrid.GeneratedGameCell[row,column].DisplayStatus == CellDisplayStatus.NotRevealed)
                    {
                        outputGrid += ". ";
                        
                    }

                    if (initialGameGrid.GeneratedGameCell[row,column].IsAMine )
                    {
                        outputGrid += "+ ";
                    }

                    if (initialGameGrid.GeneratedGameCell[row,column].DisplayStatus == CellDisplayStatus.Revealed)
                    {
                        outputGrid += initialGameGrid.GeneratedGameCell[row, column].NumberOfAdjacentMines + " ";
                    }
                    // ToDo: Add in Else command to run adjacent mine logic.
                }
                outputGrid += Environment.NewLine;
            }
            return outputGrid;
        }
    }
}
