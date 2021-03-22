using System.Collections.Generic;
using MineSweeper.Factories;
using MineSweeper.Grid;
using MineSweeper.Interfaces;
using MineSweeper.Mines;
using MineSweeper.Player;
using Xunit;

namespace MineSweeperConsoleUnitTests
{
    public class MineUnitTestsShould
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
        public void UpdateTheStatusOfACellToRecordAMineAsTrue()
        {
            //Arrange
            var gridSize = 2;
            var newGameGrid = GridFactory.NewGameGrid(gridSize);
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(newGameGrid.Size), newGameGrid);

            //Assert
            Assert.True(newGameGrid.GeneratedGameCell[0,0].IsMine);
        }
        
        [Fact]
        public void UpdateTheStatusOfACellToRecordAMineAsFalse()
        {
            //Arrange
            var gridSize = 2;
            var newGame = GridFactory.NewGameGrid(gridSize);
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForMineLocationZeroZero();

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(newGame.Size), newGame);

            //Assert
            Assert.False(newGame.GeneratedGameCell[1,1].IsMine);
        }

        [Fact]
        public void ReturnTwoAdjacentMinesOnASizeThreeGridAfterAPlayerMove()
        {
            //Arrange
            var newGameGrid = GridFactory.NewGameGrid(3);
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForTwoMineLocations();
            var userInputMove = new PlayerMove(1, 1);

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(newGameGrid.Size), newGameGrid);
            var result = updateMineStatus.CalculateAdjacentMineTotal(newGameGrid, userInputMove);

            //Assert
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void ReturnTwoAdjacentMinesOnASizeTwoGridAfterAPlayerMove()
        {
            //Arrange
            var newGameGrid = GridFactory.NewGameGrid(2);
            var updateMineStatus = new MineLogic();
            var mineStub = new StubForTwoMineLocations();
            var userInputMove = new PlayerMove(1, 1);

            //Act
            updateMineStatus.UpdateCellWithMineStatus(mineStub.MineLocations(newGameGrid.Size), newGameGrid);
            var result = updateMineStatus.CalculateAdjacentMineTotal(newGameGrid, userInputMove);

            //Assert
            Assert.Equal(2, result);
        }
    }
}