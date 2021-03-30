using System;
using System.Collections.Generic;
using MineSweeper.Factories;
using MineSweeper.Grid;
using MineSweeper.Interfaces;
using MineSweeper.Player;
using Xunit;

namespace MineSweeperConsoleUnitTests 
{
    public class GameDisplayTestsShould
    {
        private class StubForTwoMineLocations : IMineGenerator
        {
            public List<Cell> MineLocations(int gridSize)
            {
                var output = new List<Cell> {new Cell(1, 1), new Cell(2, 1)};

                return output;
            }
        }
        
        [Fact]
        public void ShowTheCorrectGameLosingMessageWhenAPlayerHitsAMine()
        {
            //Arrange
            var gridSize = 2;
            var newMessageDisplay = Factory.NewMessageDisplay();
            var gameGrid = GridFactory.NewGameGrid(gridSize);
            var mineUpdater = MineFactory.NewMineChecker();
            var mineStub = new StubForTwoMineLocations();
            var userMove = new PlayerMove(1, 1);
            var expected =
                $"0 1 2 {Environment.NewLine}1 * 2 {Environment.NewLine}2 * 2 {Environment.NewLine}Sorry, you have lost.{Environment.NewLine}Game over!";

            //Act
            mineUpdater.UpdateCellWithMineStatus(mineStub.MineLocations(gridSize), gameGrid);
            var result = newMessageDisplay.EndGameMessage(gameGrid, userMove);

            //Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void ShowTheCorrectGameWinningMessageWhenAPlayerCompletesAGridWithoutHittingAMine()
        {
            //Arrange
            var gridSize = 2;
            var newMessageDisplay = Factory.NewMessageDisplay();
            var gameGrid = GridFactory.NewGameGrid(gridSize);
            var mineUpdater = MineFactory.NewMineChecker();
            var mineStub = new StubForTwoMineLocations();
            var userMove = new PlayerMove(1, 2);
            var expected =
                $"0 1 2 {Environment.NewLine}1 * 2 {Environment.NewLine}2 * 2 {Environment.NewLine}Congrats!{Environment.NewLine}You have won!";

            //Act
            mineUpdater.UpdateCellWithMineStatus(mineStub.MineLocations(gridSize), gameGrid);
            var result = newMessageDisplay.EndGameMessage(gameGrid, userMove);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}