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
            var outputGrid = string.Empty;
            var demonstration = true;
            
            for (var row = 0; row < initialGameGrid.Size; row++)
            {
                for (var column = 0; column < initialGameGrid.Size; column++)
                {
                    outputGrid += initialGameGrid.GeneratedGameCell[row, column].DisplayStatus switch //ToDo: switch/case statement?
                    {
                        CellDisplayStatus.NotRevealed when initialGameGrid.GeneratedGameCell[row, column].IsMine =>
                            demonstration ? "+ " : ". ",
                        CellDisplayStatus.Revealed when !initialGameGrid.GeneratedGameCell[row, column].IsMine =>
                            initialGameGrid.GeneratedGameCell[row, column].AdjacentMinesTotal + " ",
                        CellDisplayStatus.Revealed when initialGameGrid.GeneratedGameCell[row, column].IsMine => "* ",
                        _ => ". "
                    };
                }
                outputGrid += Environment.NewLine;
            }
            return outputGrid;
        }

        public string GameOverDisplay(IGameGrid initialGameGrid)
        {
            var outputGrid = "";
            var mineUpdater = MineFactory.NewMineChecker();

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
                        var userInputMove = new PlayerMove(row, column);
                        initialGameGrid.GeneratedGameCell[userInputMove.Row, userInputMove.Column].AdjacentMinesTotal = 
                            mineUpdater.CalculateAdjacentMineTotal(initialGameGrid, userInputMove);
                        outputGrid += initialGameGrid.GeneratedGameCell[row, column].AdjacentMinesTotal + " ";
                    }
                }
                outputGrid += Environment.NewLine;
            }

            return outputGrid;
        }
    }
}
