using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPos = board.FindPiece(this);
            List<Square> moves = new List<Square>();

            for (int i = 0; i < 8; i++)
            {
                Square newPos = Square.At(currentPos.Row, i);
                AddNewPositionToList(moves, newPos, currentPos);
            }

            for (int i = 0; i < 8; i++)
            {
                Square newPos = Square.At(i, currentPos.Col);
                AddNewPositionToList(moves, newPos, currentPos);
            }

            return moves;
        }
    }
}