using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPos = board.FindPiece(this);
            List<Square> moves = new List<Square>();
            int posOrMinMove = Player == Player.White ? -1 : 1;
            int rowNum = Player == Player.White ? 6 : 1;

            if (currentPos.Row == rowNum)
            {
                for (int i = 1; i <= 2; i++)
                {
                    moves.Add(Square.At(currentPos.Row + (i * posOrMinMove), currentPos.Col));
                }
            }
            else
            {
                moves.Add(Square.At(currentPos.Row + (1 * posOrMinMove), currentPos.Col));
            }

            return moves;
        }
    }
}