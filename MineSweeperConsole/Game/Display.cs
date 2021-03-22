using System;
using MineSweeper.Factories;
using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public class Display : IDisplay
    {
        private readonly IValidate _userInputValidation = Factory.NewUserInputValidation();
        private readonly IDisplayGrid _gameGridDisplay = GridFactory.NewDisplayGrid();
        public string ShowUserInputMessage(int gridSize)
        {
            string inputMove;
            var maxUsableGridSize = gridSize - 1;

            do
            {
                Console.WriteLine(
                    $"Please enter grid coordinates (row,column) between 0 - {maxUsableGridSize}: ");
                inputMove = Console.ReadLine();
            } while (!_userInputValidation.IsUserMoveValid(inputMove, gridSize));

            return inputMove;
        }
        
        public void NewMethod(IGameGrid currentGameGrid, PlayerMove userInputMove)
        {
            Console.WriteLine(_gameGridDisplay.GameOverDisplay(currentGameGrid));

            Console.WriteLine(
                currentGameGrid.GeneratedGameCell[userInputMove.Row, userInputMove.Column]
                    .IsMine
                    ? $"Sorry, you have lost.{Environment.NewLine}Game over!"
                    : $"Congrats!{Environment.NewLine}You have won!");
        }
    }
}