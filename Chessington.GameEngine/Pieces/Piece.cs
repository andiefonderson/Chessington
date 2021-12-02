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
                Square newPos = Square.At(i, currentPos.Row);
                AddNewPositionToList(moves,newPos,currentPos);
            }
        }

        public void DiagonalMovement(List<Square> moves, Square currentPos)
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