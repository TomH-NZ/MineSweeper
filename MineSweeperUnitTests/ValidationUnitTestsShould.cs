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

        [Fact]
        public void ReturnTrueForAUserInputNumberBetweenZeroAndNine()
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.True(validateTest.IsUserMoveValid("0,0", 2));
        }

        [Theory]
        [InlineData(",", 3)]
        [InlineData("0,", 3)]
        [InlineData("a,", 4)]
        [InlineData("a,1", 4)]
        [InlineData("9a,0", 3)]
        [InlineData("9a,9a", 3)]
        [InlineData("10,10", 5)]
        [InlineData("10,-1", 5)]
        [InlineData("-1,-1", 2)]
        [InlineData("0,0,0", 2)]
        [InlineData("0.0.0", 2)]
        public void ReturnFalseForUserInputNotANumberOrOutsideTheGridBoundaries(string input, int gridSize)
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.False(validateTest.IsUserMoveValid(input, gridSize));
        }

        [Fact]
        public void ReturnTrueForAUserInputGridSizeBetweenTwoAndTen()
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.True(validateTest.IsInitialGridSizeValid("5"));
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
            Assert.False(validateTest.IsInitialGridSizeValid(input));
        }

        [Fact]
        public void ReturnTrueIfPlayerHasSelectedAMine()
        {
            //Arrange
            var size = 2;
            var newValidation = Factory.NewUserInputValidation();
            var gameGrid = GridFactory.NewGameGrid(size);
            var userInput = new PlayerMove(0,0);
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(gameGrid.Size), gameGrid);

            //Assert
            Assert.True(newValidation.IsGameOver(gameGrid, userInput));
        }
        
        [Fact]
        public void ReturnFalseIfPlayerHasNotSelectedAMine()
        {
            //Arrange
            var size = 2;
            var newValidation = Factory.NewUserInputValidation();
            var gameGrid = GridFactory.NewGameGrid(size);
            var userInput = new PlayerMove(0,1);
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(gameGrid.Size), gameGrid);

            //Assert
            Assert.False(newValidation.IsGameOver(gameGrid, userInput));
        }
    }
}