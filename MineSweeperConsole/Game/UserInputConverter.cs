using MineSweeper.Player;

namespace MineSweeper.Game
{
    public class UserInputConverter : IUserInputConverter
    {
        public PlayerMove ConvertInputToUserMove(string move)
        {
            var moveSplit = move.Split(',');
            int.TryParse(moveSplit[0], out var row);
            int.TryParse(moveSplit[1], out var column);

            return new PlayerMove(row, column);
        }
    }
}