using System;

namespace MineSweeper_v01
{
    public class GameCreation : IGameCreation
    {
        public void NewMineSweeperGame()
        {
            //ToDo: new game grid variable
            //ToDo: new mine generator variable
            //ToDo: user input for difficulty
            //ToDo: user input for selected cell (row, column)
            Console.WriteLine("Please enter a difficulty level (2 - 10):");
            int.TryParse(Console.ReadLine(), out var selectedSize);
            
            var newGame = Factory.NewGameGrid(selectedSize);
        }
    }
}