using System;

namespace MineSweeper_v01
{
    public class GameCreation : IGameCreation
    {
        public void NewMineSweeperGame()
        {
            Console.WriteLine("Please enter a difficulty level (2 - 10):");
            int.TryParse(Console.ReadLine(), out var selectedDifficulty);
            
            var newGame = Factory.NewGameGrid(selectedDifficulty);
        }
    }
}