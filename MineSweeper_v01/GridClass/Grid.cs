namespace MineSweeper_v01.GridClass
{
    public class Grid : IGrid
    {
        public int Size { get; set; }
        public Cell[,] TheGrid { get; set; }

        public Grid(int difficulty)
        {
            Size = difficulty;
            TheGrid = new Cell[Size, Size];

            for (var row = 0; row < Size; row++)
            {
                for (var column = 0; column < Size; column++)
                {
                    TheGrid[row, column] = new Cell(row, column);
                }
            }
        }
    }
}