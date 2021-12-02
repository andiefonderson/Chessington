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

            for (int i = 1; i < 8; i++)
            {
                Square newPos = Square.At(i, i);
                if(newPos != currentPos)
                {
                    moves.Add(Square.At(i, i));
                }                
            }

            for (int i = 1; i < 8; i++)
            {
                Square newPos = Square.At(i, 8 - i);
                if(newPos != currentPos)
                {
                    moves.Add(newPos);
                }                
            }

            return moves;
        }
    }
}