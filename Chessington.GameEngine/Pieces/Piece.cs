using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
        public void AddNewPositionToList(List<Square> posList, Square newPos, Square currentPos)
        {
            if (newPos != currentPos)
            {
                posList.Add(newPos);
            }
        }

        public void LateralMovement(List<Square> moves, Square currentPos)
        {
            for (int i = 0; i < 8; i++)
            {
                Square newPos = Square.At(currentPos.Row, i);
                AddNewPositionToList(moves, newPos, currentPos);
            }

            for (int i = 0; i < 8; i++)
            {
                Square newPos = Square.At(i, currentPos.Col);
                AddNewPositionToList(moves,newPos,currentPos);
            }
        }

        public void DiagonalMovement(List<Square> moves, Square currentPos)
        {
            for (int i = 0; i < 8; i++)
            {
                Square newPos = Square.At(currentPos.Row - i, currentPos.Col - i);
                CheckIfWithinBounds(newPos, moves, currentPos);

                Square newPos1 = Square.At(currentPos.Row + i, currentPos.Col + i);
                CheckIfWithinBounds(newPos1, moves, currentPos);

                Square newPos2 = Square.At(currentPos.Row + i, currentPos.Col - i);
                CheckIfWithinBounds(newPos2, moves, currentPos);

                Square newPos3 = Square.At(currentPos.Row - i, currentPos.Col + i);
                CheckIfWithinBounds(newPos3, moves, currentPos);      
            }
        }

        private void CheckIfWithinBounds(Square pos, List<Square> moves, Square currentPos)
        {
            if(pos.Row >= 0 && pos.Row <= 7 && pos.Col >= 0 && pos.Col <= 7)
            {
                AddNewPositionToList(moves, pos, currentPos);
            }
        }
    }
}