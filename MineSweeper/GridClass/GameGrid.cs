// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class GameGrid : IGameGrid
    {
        /*For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.*/
        
        public int Size { get; set; }
        public Cell[,] GeneratedGameCell { get; set; }
        
        public GameGrid(int size) //ToDo: Move logic outside of constructor
        {
            Size = size;
            GeneratedGameCell = new Cell[Size, Size];

            for (var row = 0; row < Size; row++) // move logic outside constructor
            {
                for (var column = 0; column < Size; column++)
                {
                    GeneratedGameCell[row, column] = new Cell(row, column, CellStatus.NotOccupiedByMine);
                }
            }
        }
    }
}