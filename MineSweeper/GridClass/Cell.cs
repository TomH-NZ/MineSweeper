
// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class Cell
    {
        public int RowLocationValue { get; }
        public int ColumnLocationValue { get; }// TODO: DELETE ENUM
        // ToDo: Add int field for adjacent mines. Add to constructor
        // ToDo: Add bool field IsOccupiedByMine??
        

        public Cell(int row, int column)
        {
            RowLocationValue = row;
            ColumnLocationValue = column;
        }
    }
}

