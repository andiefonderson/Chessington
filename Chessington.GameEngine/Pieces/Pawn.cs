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
            List<Square> availableMoves = new List<Square>();

            if(Player == Player.White)
            {
                if(currentPos.Row == 6)
                {
                    availableMoves.Add(Square.At(currentPos.Row - 1, currentPos.Col));
                    availableMoves.Add(Square.At(currentPos.Row - 2, currentPos.Col));
                }
                else
                {
                    availableMoves.Add(Square.At(currentPos.Row - 1, currentPos.Col));
                }
            }
            else
            {
                if(currentPos.Row == 1)
                {
                    availableMoves.Add(Square.At(currentPos.Row + 1, currentPos.Col));
                    availableMoves.Add(Square.At(currentPos.Row + 2, currentPos.Col));
                }
                else
                {
                    availableMoves.Add(Square.At(currentPos.Row + 1, currentPos.Col));
                }
            }        

            return availableMoves;
        }
    }
}