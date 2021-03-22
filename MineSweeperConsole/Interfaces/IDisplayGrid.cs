namespace MineSweeper.Interfaces
{
    public interface IDisplayGrid
    {
        string GenerateGameDisplay(IGameGrid initialGameGrid);
        string GameOverDisplay(IGameGrid initialGameGrid);
    }
}