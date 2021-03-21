using System;
using MineSweeper.Factories;
using MineSweeper.Interfaces;

namespace MineSweeper.Game
{
    public class Display : IDisplay
    {
        private readonly IValidate _userInputValidation = Factory.NewUserInputValidation();
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
    }
}