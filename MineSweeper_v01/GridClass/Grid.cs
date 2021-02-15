
namespace MineSweeper_v01.GridClass
{
    public class Grid : IGrid
    {
        public int Size { get; set; }
        public Cell[,] TheGameGrid { get; set; }
        
        public Grid(int difficulty)
        {
            Size = difficulty;
            TheGameGrid = new Cell[Size, Size];

            for (var row = 0; row < Size; row++)
            {
                for (var column = 0; column < Size; column++)
                {
                    TheGameGrid[row, column] = new Cell(row, column);
                }
            }
        }
    }
}