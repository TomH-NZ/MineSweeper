namespace MineSweeper_v01.GridClass
{
    public class Cell
    {
        public int RowLocationValue { get; }
        public int ColumnLocationValue { get; }
        public bool IsOccupiedByMine { get; set; }

        public Cell(int row, int column)
        {
            RowLocationValue = row;
            ColumnLocationValue = column;
            IsOccupiedByMine = false;
        }
    }
}