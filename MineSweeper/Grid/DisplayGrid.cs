using System;
using MineSweeper_v01.Enums;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class DisplayGrid : IDisplayGrid 
    {
        //For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.
        //Player move is always entered as Row then Column.

        public string GenerateGameDisplay(IGameGrid initialGameGrid)
        {
            var outputGrid = "";
            
            for (var row = 0; row < initialGameGrid.Size; row++)
            {
                for (var column = 0; column < initialGameGrid.Size; column++)
                {
                    if (initialGameGrid.GeneratedGameCell[row,column].DisplayStatus == CellDisplayStatus.NotRevealed 
                        && initialGameGrid.GeneratedGameCell[row,column].IsMine) // ToDo: Use for display testing in game process.
                    {
                        outputGrid += "+ ";
                    }
                    else if (initialGameGrid.GeneratedGameCell[row,column].DisplayStatus == CellDisplayStatus.Revealed 
                             && !initialGameGrid.GeneratedGameCell[row,column].IsMine)
                    {
                        outputGrid += initialGameGrid.GeneratedGameCell[row, column].AdjacentMinesTotal + " ";
                    }
                    else if (initialGameGrid.GeneratedGameCell[row,column].DisplayStatus == CellDisplayStatus.Revealed 
                             && initialGameGrid.GeneratedGameCell[row,column].IsMine)
                    {
                        outputGrid += "* ";
                    }
                    else
                    {
                        outputGrid += ". ";
                    }
                    // ToDo: Write standard display methods to use for full implementation.
                }
                outputGrid += Environment.NewLine;
            }
            return outputGrid;
        }

        public string GameOverDisplay(IGameGrid initialGameGrid)
        {
            var outputGrid = "";

            for (var row = 0; row < initialGameGrid.Size; row++)
            {
                for (var column = 0; column < initialGameGrid.Size; column++)
                {
                    if (initialGameGrid.GeneratedGameCell[row,column].IsMine)
                    {
                        outputGrid += "* ";
                    }
                    else
                    {
                        outputGrid += initialGameGrid.GeneratedGameCell[row, column].AdjacentMinesTotal + " ";
                    }
                }
                outputGrid += Environment.NewLine;
            }

            return outputGrid;
        }
    }
}
