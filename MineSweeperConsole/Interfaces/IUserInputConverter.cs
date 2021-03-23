using MineSweeper.Player;

namespace MineSweeper.Game
{
    public interface IUserInputConverter
    {
        PlayerMove ConvertInputToUserMove(string move);
    }
}