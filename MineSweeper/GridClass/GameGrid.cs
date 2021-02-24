// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class GameGrid : IGameGrid
    {
        /*For the game, [0,0] is located in the top left corner, with the largest row/column being bottom right.*/
        
        public int Size { get; set; }
        public Cell[,] GeneratedGameCell { get; set; }
        
        public GameGrid(int size)
        {
            Size = size;
            GeneratedGameCell = new Cell[Size, Size];
        }

        public void GenerateGrid(int size)
        {
            for (var row = 0; row < Size; row++)
            {
                for (var column = 0; column < Size; column++)
                {
                    UpdateGameCellStatusWithMine(size, row, column);
                }
            }
        }

        public void UpdateGameCellStatusWithMine(int size, int row, int column)
        {
            var newMineLocations = Factory.NewMineLocations();

            foreach (var entry in newMineLocations.MineLocations(size))
            {
                var mines = entry.Split(',');
                int.TryParse(mines[0].Trim(), out var mineRow);
                int.TryParse(mines[1].Trim(), out var mineColumn);

                if (mineRow == row && mineColumn == column)
                {
                    GeneratedGameCell[row, column] = new Cell(row, column, CellStatus.OccupiedByMine);
                }
                else
                {
                    GeneratedGameCell[row, column] = new Cell(row, column, CellStatus.NotOccupiedByMine);
                }
            }
        }
    }
}