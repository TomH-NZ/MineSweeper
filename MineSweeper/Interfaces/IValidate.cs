namespace MineSweeper_v01
{
    public interface IValidate
    {
        bool UserGridMove(string userMove);
        bool InitialGridSize(string userInput);
    }
}