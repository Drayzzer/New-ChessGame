using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public class Pawn : Piece
    {
        public override int Value => 1;
        public override void MovePiece(Piece[,] board,Vector2Int movement)
        {
            board[movement.x, movement.y] = this;
            board[Pos.x, Pos.y] = null;
            Pos = movement;
        }
        public Pawn(ColorPiece color) : base(color) {}

        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            
            // Top
            if (Pos.y + 1 < board.GetLength(1))
            {
                if (board[Pos.x , 1] == null || board[Pos.x, 1].Color != Color) 
                { 
                    moves.Add(new Vector2Int(Pos.x, 1)); 
                } 
                moves.Add(new Vector2Int(Pos.x, 1));
            }
            
            // Bottom
            if (Pos.y - 1 > 0)
            {
                if (board[Pos.x, -1] == null || board[Pos.x, -1].Color != Color) 
                { 
                    moves.Add(new Vector2Int(Pos.x, -1)); 
                } 
                moves.Add(new Vector2Int(Pos.x, -1));
            }
            return moves;
        }
    }
}
