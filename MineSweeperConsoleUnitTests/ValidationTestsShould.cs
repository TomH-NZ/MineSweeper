using System.Collections.Generic;
using MineSweeper.Factories;
using MineSweeper.Grid;
using MineSweeper.Interfaces;
using MineSweeper.Mines;
using MineSweeper.Player;
using MineSweeper.Validation;
using Xunit;

namespace MineSweeperConsoleUnitTests
{
    public class ValidationTestsShould
    {
        private class StubForMineLocationZeroZero : IMineGenerator
        {
            public List<Cell> MineLocations(int gridSize)
            {
                var output = new List<Cell> {new Cell(1,1)};
                return output;
            }
        }

        [Fact]
        public void ReturnTrueForAUserInputNumberBetweenOneAndGridSize()
        {
            //Arrange
            var validateTest = new Validate();

            //Act

            //Assert
            Assert.True(validateTest.IsUserMoveValid("1,1", 2));
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
            var size = 5;

            //Act

            //Assert
            Assert.True(validateTest.IsInitialGridSizeValid("5", out size));
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("a", 0)]
        [InlineData("9a", 0)]
        [InlineData("12", 0)]
        [InlineData("-3", 0)]
        public void ReturnFalseForUserInputGridSizeNotANumberOrOutsideZeroAndEleven(string input, int size)
        {
            //Arrange
            var validateTest = new Validate();
            var output = size;

            //Act

            //Assert
            Assert.False(validateTest.IsInitialGridSizeValid(input, out output));
        }

        [Fact]
        public void ReturnTrueIfPlayerHasSelectedAMine()
        {
            //Arrange
            var size = 2;
            var newValidation = Factory.NewUserInputValidation();
            var gameGrid = GridFactory.NewGameGrid(size);
            var userInput = new PlayerMove(1,1);
            var updateMineStatus = new MineUpdater();
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
            var size = 3;
            var newValidation = Factory.NewUserInputValidation();
            var gameGrid = GridFactory.NewGameGrid(size);
            var userInput = new PlayerMove(1,2);
            var updateMineStatus = new MineUpdater();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(gameGrid.Size), gameGrid);

            //Assert
            Assert.False(newValidation.IsGameOver(gameGrid, userInput));
        }
    }
}