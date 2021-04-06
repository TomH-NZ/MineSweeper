using System;
using MineSweeper.Enums;
using MineSweeper.Interfaces;

namespace MineSweeper.Grid
{
    public class DisplayGrid : IDisplayGrid 
    {
        //For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.
        //Player move is always entered as Row then Column.

        private readonly string _unrevealedCell = ". ";
        private readonly string _blankSpace = " ";

        public string GenerateGameDisplay(IGameGrid initialGameGrid)
        {
            var outputGrid = string.Empty;
            var demonstrationStatus = true;
            var demonstrationMine = "+ ";
            
            for (var row = 0; row < initialGameGrid.Size; row++)
            {
                for (var column = 0; column < initialGameGrid.Size; column++)
                {
                    outputGrid += initialGameGrid.GeneratedGameCell[row, column].DisplayStatus switch
                    {
                        CellDisplayStatus.NotRevealed when initialGameGrid.GeneratedGameCell[row, column].IsMine =>
                            demonstrationStatus ? demonstrationMine : _unrevealedCell,
                        CellDisplayStatus.Revealed when !initialGameGrid.GeneratedGameCell[row, column].IsMine =>
                            initialGameGrid.GeneratedGameCell[row, column].AdjacentMinesTotal + _blankSpace,
                        _ => _unrevealedCell
                    };
                }
                outputGrid += Environment.NewLine;
            }
            return outputGrid;
        }

        public string GameOverGridDisplay(IGameGrid initialGameGrid)
        {
            var outputGrid = "";
            var revealedMine = "* ";

            for (var row = 0; row < initialGameGrid.Size; row++)
            {
                for (var column = 0; column < initialGameGrid.Size; column++)
                {
                    outputGrid += initialGameGrid.GeneratedGameCell[row,column].IsMine 
                        ? revealedMine 
                        : initialGameGrid.GeneratedGameCell[row, column].AdjacentMinesTotal + _blankSpace;
                }
                outputGrid += Environment.NewLine;
            }

            return outputGrid;
        }
    }
}
