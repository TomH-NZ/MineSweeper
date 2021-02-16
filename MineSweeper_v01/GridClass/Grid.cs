
using MineSweeper_v01.Interfaces;

namespace MineSweeper_v01.GridClass
{
    public class Grid : IGrid
    {
        //For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.
        
        public int Size { get; set; }
        public Cell[,] GeneratedGame { get; set; }
        
        public Grid(int size)
        {
            Size = size;
            GeneratedGame = new Cell[Size, Size];

            for (var row = 0; row < Size; row++)
            {
                for (var column = 0; column < Size; column++)
                {
                    GeneratedGame[row, column] = new Cell(row, column);
                }
            }
        }
    }
}