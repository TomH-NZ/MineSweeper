// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class PlayerMove // ToDo: have Cell inherit from PlayerMove, taking in row/column, use inheritance rather than interface.
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public PlayerMove(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}