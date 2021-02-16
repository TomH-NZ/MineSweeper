using System;
using System.Globalization;
using MineSweeper_v01.Factories;
using MineSweeper_v01.GridClass;

namespace MineSweeper_v01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a difficulty level (2 - 10):");
            int.TryParse(Console.ReadLine(), out var selectedDifficulty);
            
            var newGame = Factory.NewGameGrid(selectedDifficulty);
            var game = Factory.NewGridDisplay(newGame);
        }
    }
}