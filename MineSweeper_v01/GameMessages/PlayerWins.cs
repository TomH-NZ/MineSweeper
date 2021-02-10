namespace MineSweeper_v01.GameMessages
{
    public class PlayerWins
    {
        public string GameOverMessage(bool hasPlayerLost)
        {
            return "You've cleared the minefield and won!";
        }
    }
}