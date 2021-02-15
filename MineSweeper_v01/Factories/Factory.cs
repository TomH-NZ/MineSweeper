using System.Collections.Generic;
using MineSweeper_v01.GridClass;
using MineSweeper_v01.Interfaces;

namespace MineSweeper_v01.Factories
{
    public class Factory
    {
        public static IGrid NewGameGrid(int difficulty)
        {
            return new Grid(difficulty);
        }
        
        public static IDisplayGrid DisplayGrid(IGrid newGame)
        {
            return new DisplayGrid(NewGameGrid(difficulty));
        }
        
    }
}