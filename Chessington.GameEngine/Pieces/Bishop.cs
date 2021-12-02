using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentPos = board.FindPiece(this);

            int minNum = currentPos.Row > currentPos.Col ? currentPos.Col : currentPos.Row;
            int maxNum = currentPos.Row < currentPos.Col ? currentPos.Col : currentPos.Row;

            for (int i = 0; i <= minNum; i++)
            {
                Square newPos = Square.At(currentPos.Row - i, currentPos.Col - i);
                AddNewPositionToList(moves, newPos, currentPos);
            }

            for (int i = 0; i < maxNum; i++)
            {
                Square newPos = Square.At(currentPos.Row + i, currentPos.Col + i);
                AddNewPositionToList(moves, newPos, currentPos);
                Square newPos2 = Square.At(currentPos.Row + i, currentPos.Col - i);
                AddNewPositionToList(moves, newPos2, currentPos);
            }

            for (int i = 0; i < minNum; i++)
            {
                Square newPos = Square.At(currentPos.Row - i, currentPos.Col + i);
                AddNewPositionToList(moves, newPos, currentPos);
            }

            return moves;
        }
    }
}