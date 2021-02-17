// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class Cell
    {
        public int RowLocationValue { get; }
        public int ColumnLocationValue { get; }
        public bool IsOccupiedByMine { get; set; } // look at using enum for call status (mine, no mine, marked as mine)

        public Cell(int row, int column)
        {
            RowLocationValue = row;
            ColumnLocationValue = column;
            IsOccupiedByMine = false;
        }
    }
}