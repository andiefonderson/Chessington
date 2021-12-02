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
            LateralMovement(moves, currentPos);
            DiagonalMovement(moves, currentPos);

            return moves;
        }

        private static void LateralMovement(List<Square> moves, Square currentPos)
        {
            for (int i = 0; i < 8; i++)
            {
                Square newPos = Square.At(currentPos.Row, i);
                if (newPos != currentPos)
                {
                    moves.Add(newPos);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                Square newPos = Square.At(i, currentPos.Row);
                if (newPos != currentPos)
                {
                    moves.Add(newPos);
                }
            }
        }

        private void DiagonalMovement(List<Square> moves, Square currentPos)
        {
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
        }

    }
}