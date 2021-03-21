using MineSweeper.Player;

namespace MineSweeper.Game
{
    public interface IConvertUserInput
    {
        PlayerMove ConvertUserInputToUserMove(string move);
    }
}