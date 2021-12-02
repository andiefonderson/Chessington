using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> moves = new List<Square>();
            Square currentPos = board.FindPiece(this);

            for (int i = 0; i < 8; i++)
            {
                Square newPos = Square.At(currentPos.Row, i);
                if(newPos != currentPos)
                {
                    moves.Add(newPos);
                }                
            }

            for (int i = 0; i < 8; i++)
            {
                Square newPos = Square.At(i, currentPos.Row);
                if(newPos != currentPos)
                {
                    moves.Add(newPos);
                }
            }

            return moves;
        }


    }
}