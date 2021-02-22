using System;

namespace MineSweeper_v01
{
    public class GameCreation : IGameCreation
    {
        public void NewMineSweeperGame()
        {
            //new game grid variable
            //new mine generator variable
            //user input for difficulty
            //user input for selected cell (row, column)
            Console.WriteLine("Please enter a difficulty level (2 - 10):");
            int.TryParse(Console.ReadLine(), out var selectedSize);
            
            var newGame = Factory.NewGameGrid(selectedSize);
        }
    }
}