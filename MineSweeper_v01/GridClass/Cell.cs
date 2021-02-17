
// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class Cell
    {
        public int RowLocationValue { get; }
        public int ColumnLocationValue { get; }
        private CellStatus _cellStatus;
        

        public Cell(int row, int column, CellStatus cellStatus)
        {
            RowLocationValue = row;
            ColumnLocationValue = column;
            _cellStatus = cellStatus;
        }
    }
}