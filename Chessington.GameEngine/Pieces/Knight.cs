using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentPos = board.FindPiece(this);
            List<Square> moves = new List<Square>();

            LMoves(moves, currentPos);

            return moves;
        }

        private void LMoves(List<Square> moves, Square currentPos)
        {
            moves.Add(Square.At(currentPos.Row + 2, currentPos.Col + 1));
            moves.Add(Square.At(currentPos.Row - 2, currentPos.Col - 1));
            moves.Add(Square.At(currentPos.Row - 2, currentPos.Col + 1));
            moves.Add(Square.At(currentPos.Row + 2, currentPos.Col - 1));
            moves.Add(Square.At(currentPos.Row + 1, currentPos.Col + 2));
            moves.Add(Square.At(currentPos.Row - 1, currentPos.Col - 2));
            moves.Add(Square.At(currentPos.Row - 1, currentPos.Col + 2));
            moves.Add(Square.At(currentPos.Row + 1, currentPos.Col - 2));

            foreach (Square move in moves)
            {
                if(currentPos.Row < 0 || currentPos.Col < 0 || currentPos.Row > 7 || currentPos.Col > 7)
                {
                    moves.Remove(move);
                }
            }
        }
    }
}