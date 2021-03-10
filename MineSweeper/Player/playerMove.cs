namespace MineSweeper_v01.Player
{
    public class playerMove
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public playerMove(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}