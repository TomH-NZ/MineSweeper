using System;
using System.Collections.Generic;
using MineSweeper_v01.GridClass;
using MineSweeper_v01.Interfaces;

namespace MineSweeper_v01.MinesClass //ToDo: Complete this so that it generates a random mine cell. Save cell to List<cell>
{
    public class Mine : IMine
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        

        public Mine(int row, int column)
        {
            RowNumber = row;
            ColumnNumber = column;
        }

        public Cell MineCellGeneration(int size)
        {
            var randomMineRow = new Random().Next(0, size);
            var randomMineColumn = new Random().Next(0, size);
            
            var mine = new Cell(randomMineRow, randomMineColumn);

            return mine;
        }
        public List<Cell> MineLocations = new List<Cell>();
        _mineLocations.Add
    }
}