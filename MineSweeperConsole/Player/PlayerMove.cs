
namespace MineSweeper.Player
{
    public class PlayerMove
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