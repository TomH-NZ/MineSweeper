using System;
using MineSweeper_v01.Enums;

// ReSharper disable once CheckNamespace

namespace MineSweeper_v01
{
    public class Cell : ICell 
    {
        public int RowLocationValue { get; }
        public int ColumnLocationValue { get; }
        public bool IsAMine { get; set; }
        public int NumberOfAdjacentMines { get; set; }
        public CellDisplayStatus DisplayStatus { get; set; } 

        public Cell(int row, int column)
        {
            RowLocationValue = row;
            ColumnLocationValue = column;
            IsAMine = false;
            DisplayStatus = CellDisplayStatus.NotRevealed;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Cell))
                return false;

            var other = (Cell) obj;

            if (RowLocationValue != other.RowLocationValue || ColumnLocationValue != other.ColumnLocationValue)
            {
                return false;
            }
            
            return true;
        }

        protected bool Equals(Cell other)
        {
            return RowLocationValue == other.RowLocationValue && ColumnLocationValue == other.ColumnLocationValue;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RowLocationValue, ColumnLocationValue);
        }

        public static bool operator ==(Cell row, Cell column)
        {
            return row.Equals(column);
        }

        public static bool operator !=(Cell row, Cell column)
        {
            return !(row == column);
        }
    }
}

