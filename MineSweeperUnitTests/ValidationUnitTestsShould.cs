using System.Collections.Generic;
using MineSweeper_v01;
using Xunit;

namespace MineSweeperUnitTests
{
    public class ValidationUnitTestsShould
    {
        private class StubForMineLocationZeroZero : IMineGenerator
        {
            public List<Cell> MineLocations(int gridSize)
            {
                var output = new List<Cell> {new Cell(0,0)};
                return output;
            }
        }
        
        private class StubForTwoMineLocations : IMineGenerator
        {
            public List<Cell> MineLocations(int gridSize)
            {
                var output = new List<Cell> {new Cell(0, 1), new Cell(1, 0)};

                return output;
            }
        }
        
        [Fact]
        public void ReturnTrueForAUserInputNumberBetweenZeroAndNine()
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.True(validateTest.IsValidUserMove("1"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("9a")]
        [InlineData("10")]
        [InlineData("-2")]
        public void ReturnFalseForUserInputNotANumberOrGreaterThanNine(string input)
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.False(validateTest.IsValidUserMove(input));
        }

        [Fact]
        public void ReturnTrueForAUserInputGridSizeBetweenTwoAndTen()
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.True(validateTest.IsCorrectInitialGridSize("5"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("9a")]
        [InlineData("11")]
        [InlineData("-3")]
        public void ReturnFalseForUserInputGridSizeNotANumberOrOutsideZeroAndTen(string input)
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.False(validateTest.IsCorrectInitialGridSize(input));
        }

        [Fact]
        public void ReturnTrueIfPlayerHasSelectedAMine()
        {
            //Arrange
            var size = 2;
            var newValidation = Factory.NewUserInputValidation();
            var gameDisplay = GridFactory.NewGameGrid(size);
            gameDisplay.GenerateGrid(gameDisplay.Size);
            var userInput = "0,0";
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(gameDisplay.Size), gameDisplay);

            //Assert
            Assert.True(newValidation.IsPlayerDead(gameDisplay, userInput));
        }
        
        [Fact]
        public void ReturnFalseIfPlayerHasNotSelectedAMine()
        {
            //Arrange
            var size = 2;
            var newValidation = Factory.NewUserInputValidation();
            var gameDisplay = GridFactory.NewGameGrid(size);
            gameDisplay.GenerateGrid(gameDisplay.Size);
            var userInput = "0,1";
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(gameDisplay.Size), gameDisplay);

            //Assert
            Assert.False(newValidation.IsPlayerDead(gameDisplay, userInput));
        }
    }
}