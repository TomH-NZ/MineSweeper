// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class PlayerMove
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public PlayerMove(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int this[int index]
        {
            get { throw new System.NotImplementedException(); }
        }
    }
    // ToDo: Add playerMove to Validate - IsPlayerDead , MineLogic - CalculateAdjacentMines, GameConsole, UnitTests
}