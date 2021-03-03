using System;
using MineSweeper_v01.Enums;

// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class DisplayGrid : IDisplayGrid 
    {
        /*For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.*/
        
        public int Size { get; set; }
        
        public DisplayGrid(int size)
        {
            Size = size;
        }

        public string GenerateGameDisplay(int size)
        {
            var outputGrid = "";
            var initialGameGrid = GridFactory.NewGameGrid(size);
            initialGameGrid.GenerateGrid(size);

            for (var row = 0; row < size; row++)
            {
                for (var column = 0; column < size; column++)
                {
                    if (initialGameGrid.GeneratedGameCell[row,column].DisplayStatus == CellDisplayStatus.NotRevealed)
                    {
                        outputGrid += ". ";
                        
                    }
                    // ToDo: Add in Else command to run adjacent mine logic.
                    
                }
                outputGrid += Environment.NewLine;
            }
            return outputGrid;
        }
    }
}
