using MineSweeper.Interfaces;

namespace MineSweeper.Grid
{
    public class GameGrid : IGameGrid
    {
        //For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.
        
        public int Size { get; set; }
        public Cell[,] GeneratedGameCell { get; set; }

        public GameGrid(int size)
        {
            Size = size + 1;
            GeneratedGameCell = GenerateGrid();
        }

        private Cell[,] GenerateGrid()
        {
            var outputCell = new Cell[Size, Size];
            
            for (var row = 0; row < Size; row++)
            {
                for (var column = 0; column < Size; column++)
                {
                    outputCell[row, column] = new Cell(row, column);
                }
            }

            return outputCell;
        }
    }
}
