using System;
using MineSweeper_v01.Interfaces;

namespace MineSweeper_v01.GridClass
{
    public class DisplayGrid : IDisplayGrid
    {
        public DisplayGrid(IGrid gameGrid)
        {
            for (var row = 0; row < gameGrid.Size; row++)
            {
                for (var column = 0; column < gameGrid.Size; column++)
                {
                    var gameCell = gameGrid.GeneratedGame[row, column];
                    
                    Console.Write(!gameCell.IsOccupiedByMine ? ". " : "+ ");
                }

                Console.WriteLine();
            }
        }
    }
}
