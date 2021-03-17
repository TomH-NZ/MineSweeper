using MineSweeper.Enums;

namespace MineSweeper.Interfaces
{
    public interface ICell
    {
        bool IsMine { get; set; }
        int AdjacentMinesTotal { get; set; }
        CellDisplayStatus DisplayStatus { get; set; }
    }
}