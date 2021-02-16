namespace MineSweeper_v01.GridClass
{
    public class Cell
    {
        public int RowValue { get; }
        public int ColumnValue { get; }
        public bool OccupiedByMine { get; set; }

        public Cell(int row, int column)
        {
            RowValue = row;
            ColumnValue = column;
            OccupiedByMine = false;
        }
    }
}