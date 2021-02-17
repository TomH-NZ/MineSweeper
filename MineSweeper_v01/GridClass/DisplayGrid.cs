using System;
using MineSweeper_v01.Interfaces;

namespace MineSweeper_v01.GridClass
{
    public class DisplayGrid : IDisplayGrid
    {
        public DisplayGrid(IGameGrid gameGrid)
        {
            for (var row = 0; row < gameGrid.Size; row++)
            {
                for (var column = 0; column < gameGrid.Size; column++)
                {
                    var gameCell = gameGrid.GeneratedGameCell[row, column];
                    
                    Console.Write(!gameCell.IsOccupiedByMine ? ". " : "+ ");
                }

                Console.WriteLine();
            }
        }
    }
}
