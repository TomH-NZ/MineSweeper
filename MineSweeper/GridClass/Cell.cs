
// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class Cell // TODO: DELETE ENUM
    {
        public int RowLocationValue { get; }
        public int ColumnLocationValue { get; }
        public bool IsAMine { get; set; }
        public int NumberOfAdjacentMines { get; set; }
        

        public Cell(int row, int column)
        {
            RowLocationValue = row;
            ColumnLocationValue = column;
        }
    }
}

