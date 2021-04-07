using System;
using MineSweeper.Factories;
using MineSweeper.Interfaces;
using MineSweeper.Player;

namespace MineSweeper.Game
{
    public class MessageDisplay : IMessageDisplay
    {
        public string ShowUserInputMessage(int gridSize)
        {
            string inputMove;
            var userInputValidation = Factory.NewUserInputValidation();
            var maxUsableGridSize = gridSize - 1;

            do
            {
                Console.WriteLine(
                    $"Please enter grid coordinates (row,column) between 0 - {maxUsableGridSize}: ");
                inputMove = Console.ReadLine();
            } while (!userInputValidation.IsUserMoveValid(inputMove, gridSize));

            return inputMove;
        }
        
        public string EndGameMessage(IGameGrid currentGameGrid, PlayerMove userInputMove)
        { 
            var gameGridDisplay = GridFactory.NewDisplayGrid();
            var revealedGameGrid =gameGridDisplay.GameOverGridDisplay(currentGameGrid);
            
            var message = currentGameGrid.GeneratedGameCell[userInputMove.Row, userInputMove.Column]
                    .IsMine
                    ? $"Sorry, you have lost.{Environment.NewLine}Game over!"
                    : $"Congrats!{Environment.NewLine}You have won!";

            return revealedGameGrid + message;
        }
    }
}