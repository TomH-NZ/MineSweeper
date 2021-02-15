using MineSweeper_v01.Factories;
using MineSweeper_v01.Interfaces;

namespace MineSweeper_v01
{
    public class GameCreation
    {
        public static int difficulty = 2; //ToDo: Change to take in player input for difficulty level.
        
        public IGrid newGameGrid = Factory.NewGameGrid(difficulty);
    }
}