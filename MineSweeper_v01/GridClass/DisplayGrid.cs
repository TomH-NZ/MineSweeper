using System;

namespace MineSweeper_v01.GridClass
{
    public class DisplayGrid
    {
        public DisplayGrid(IGrid gameGrid)
        {
            for (var row = 0; row < gameGrid.Size; row++)
            {
                for (var column = 0; column < gameGrid.Size; column++)
                {
                    var gameCell = gameGrid.TheGameGrid[row, column];
                    
                    Console.Write(!gameCell.OccupiedByMine ? "." : "+");
                }

                Console.WriteLine();
            }
        }
    }
}
