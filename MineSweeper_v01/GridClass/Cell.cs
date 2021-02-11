namespace MineSweeper_v01.GridClass
{
    public class Cell
    {
        public int RowNumber { get; }
        public int ColumnNumber { get; }
        public bool OccupiedByMine { get; set; }

        public Cell(int row, int column)
        {
            RowNumber = row;
            ColumnNumber = column;
        }
    }
}