namespace MineSweeper_v01.GridClass
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        public Cell(int row, int column)
        {
            RowNumber = row;
            ColumnNumber = column;
        }
    }
}