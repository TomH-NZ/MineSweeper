using System;
using MineSweeper.Enums;
using MineSweeper.Interfaces;

namespace MineSweeper.Grid
{
    public class Cell : ICell 
    {
        public int Row { get; }
        public int Column { get; }
        public bool IsMine { get; set; }
        public int AdjacentMinesTotal { get; set; }
        public CellDisplayStatus DisplayStatus { get; set; } 

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            IsMine = false;
            DisplayStatus = CellDisplayStatus.NotRevealed;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Cell))
                return false;

            var other = (Cell) obj;

            if (Row != other.Row || Column != other.Column)
            {
                return false;
            }
            
            return true;
        }

        protected bool Equals(Cell other)
        {
            return Row == other.Row && Column == other.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }

        public static bool operator ==(Cell row, Cell column)
        {
            return row is { } && row.Equals(column);
        }

        public static bool operator !=(Cell row, Cell column)
        {
            return !(row == column);
        }
    }
}

