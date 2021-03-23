using System;
using MineSweeper.Enums;
using MineSweeper.Factories;
using MineSweeper.Interfaces;
using MineSweeper.Player;

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
            var demonstrationStatus = false;
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

        public string GameOverDisplay(IGameGrid initialGameGrid)
        {
            var outputGrid = "";
            var revealedMine = "* ";
            var mineUpdater = MineFactory.NewMineChecker();

            for (var row = 0; row < initialGameGrid.Size; row++)
            {
                for (var column = 0; column < initialGameGrid.Size; column++)
                {
                    if (initialGameGrid.GeneratedGameCell[row,column].IsMine)
                    {
                        outputGrid += revealedMine;
                    }
                    else
                    {
                        var userInputMove = new PlayerMove(row, column);
                        initialGameGrid.GeneratedGameCell[userInputMove.Row, userInputMove.Column].AdjacentMinesTotal = 
                            mineUpdater.CalculateAdjacentMineTotal(initialGameGrid, userInputMove);
                        outputGrid += initialGameGrid.GeneratedGameCell[row, column].AdjacentMinesTotal + _blankSpace;
                    }
                }
                outputGrid += Environment.NewLine;
            }

            return outputGrid;
        }
    }
}
