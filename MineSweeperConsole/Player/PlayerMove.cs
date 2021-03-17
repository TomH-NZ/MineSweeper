
namespace MineSweeper.Player
{
    public class PlayerMove // ToDo: have Cell inherit from PlayerMove, taking in row/column, use inheritance rather than interface.
    {
        public int Row { get; protected set; }
        public int Column { get; protected set; }

        public PlayerMove(int row, int column)
        {
            Row = row;
            Column = column;
        }

        protected PlayerMove()
        {
            
        }
    }
}