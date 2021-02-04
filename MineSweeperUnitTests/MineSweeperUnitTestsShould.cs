using System;
using MineSweeper_v01.GameMessages;
using Xunit;

namespace MineSweeperUnitTests
{
    public class MineSweeperUnitTestsShould
    {
        [Fact]
        public void ReturnGameOverMessageWhenPlayerLoses()
        {
            //Arrange
            var gameOver = new PlayerLost();

            //Act
            var result = gameOver.GameOverMessage(true);

            //Assert
            Assert.Equal("Game Over, man.  Game Over.", result);
        }

        [Fact]
        public void ReturnGameOverMessageWhenPlayerWins()
        {
            //Arrange
            var gameOver = new PlayerWins();

            //Act
            var result = gameOver.GameOverMessage(true);

            //Assert
            Assert.Equal("You've cleared the minefield and won!", result);
        }
    }
}