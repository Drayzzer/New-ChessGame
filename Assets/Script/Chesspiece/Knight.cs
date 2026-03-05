using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public class Knight : Piece
    {
        public override int Value => 3;

        public Knight(ColorPiece color) : base(color) {}
        
        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            
            //Right puis Top
            if (Pos.x + 1 < board.GetLength(0) && Pos.y + 2 < board.GetLength(1))
            {
                if (!TryAddPosition(board, moves, new Vector2Int(1,2)));
            }
            
            //Left puis Top
            if (Pos.x - 1 >= 0 && Pos.y + 2 < board.GetLength(1))
            {
                if (!TryAddPosition(board, moves, new Vector2Int(-1,2)));
            }
            
            //Right puis Bottom
            if (Pos.x + 1 < board.GetLength(0) && Pos.y - 2 >= 0)
            {
                if (!TryAddPosition(board, moves, new Vector2Int(1, -2))) ;
            }
            
            //Left puis Bottom
            if (Pos.x - 1 >= 0 && Pos.y - 2 >= 0)
            {
                if (!TryAddPosition(board, moves, new Vector2Int(-1,-2)));
            }
            
            //Top puis Right
            if (Pos.x + 2 < board.GetLength(0) && Pos.y + 1 < board.GetLength(1))
            {
                if (!TryAddPosition(board, moves, new Vector2Int(1,-2)));
            }
            
            //Left puis Top
            if (Pos.x - 2 >= 0 && Pos.y + 1 < board.GetLength(1))
            {
                if (!TryAddPosition(board, moves, new Vector2Int(-2,1)));
            }
            
            //Right puis Bottom
            if (Pos.x + 2 < board.GetLength(0) && Pos.y - 1 >= 0)
            {
                if (!TryAddPosition(board, moves, new Vector2Int(2,-1)));
            }
            
            //Left puis Bottom
            if (Pos.x - 2 >= 0 && Pos.y - 1 >= 0)
            {
                if (!TryAddPosition(board, moves, new Vector2Int(-2,-1)));
            }
            return moves;
        }
    }
}