using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public class Knight : Piece
    {
        public override int Value => 3;
        public override void MovePiece(Piece[,] board,Vector2Int movement)
        {
            board[Pos.x + movement.x, Pos.y + movement.y] = this;
            board[Pos.x, Pos.y] = null;
            Pos = movement;
        }
        public Knight(ColorPiece color) : base(color) {}
        
        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            
            //Right puis Top
            if (Pos.x + 1 < board.GetLength(0) && Pos.y + 2 < board.GetLength(1))
            {
                if (board[Pos.x + 1, Pos.y + 2] == null || board [Pos.x + 1, Pos.y + 2].Color != Color)
                { 
                    moves.Add(new Vector2Int(1, 2)); 
                } 
                else if (board[Pos.x + 1, Pos.y + 2].Color == Color) {}
            }
            
            //Left puis Top
            if (Pos.x - 1 > 0 && Pos.y + 2 < board.GetLength(1))
            {
                if (board[Pos.x - 1, Pos.y + 2] == null || board [Pos.x - 1, Pos.y + 2].Color != Color) 
                { 
                    moves.Add(new Vector2Int(-1, 2)); 
                }
                else if (board [Pos.x - 1, Pos.y + 2].Color == Color) {}
            }
            
            //Right puis Bottom
            if (Pos.x + 1 < board.GetLength(0) && Pos.y - 2 > 0)
            {
                if (board[Pos.x + 1, Pos.y - 2] == null || board [Pos.x + 1, Pos.y - 2].Color != Color) 
                {
                    moves.Add(new Vector2Int(1, -2)); 
                } 
                else if (board [Pos.x + 1, Pos.y - 2].Color == Color) {}
            }
            
            //Left puis Bottom
            if (Pos.x - 1 > 0 && Pos.y - 2 > 0)
            {
                if (board[Pos.x - 1, Pos.y - 2] == null || board [Pos.x - 1, Pos.y - 2].Color != Color) 
                { 
                    moves.Add(new Vector2Int(-1, -2)); 
                }
                moves.Add(new Vector2Int(-1, -2));
            }
            
            //Top puis Right
            if (Pos.x + 2 < board.GetLength(0) && Pos.y + 1 < board.GetLength(1))
            {
                if (board[Pos.x + 2, Pos.y + 1] == null || board [Pos.x + 2, Pos.y + 1].Color != Color) 
                { 
                    moves.Add(new Vector2Int(2, 1)); 
                } 
                else if (board [Pos.x - 1, Pos.y - 2].Color == Color) {}
            }
            
            //Left puis Top
            if (Pos.x - 2 > 0 && Pos.y + 1 < board.GetLength(1))
            {
                if (board[Pos.x - 2, Pos.y + 1] == null || board [Pos.x - 2, Pos.y + 1].Color != Color) 
                { 
                    moves.Add(new Vector2Int(-2, 1)); 
                } 
                else if (board [Pos.x - 2, Pos.y + 1].Color == Color) {}
            }
            
            //Right puis Bottom
            if (Pos.x + 2 < board.GetLength(0) && Pos.y - 1 > 0)
            {
                if (board[Pos.x + 2, Pos.y - 1] == null || board [Pos.x + 2, Pos.y - 1].Color != Color) 
                { 
                    moves.Add(new Vector2Int(2, -1)); 
                } 
                else if (board [Pos.x + 2, Pos.y - 1].Color == Color) {}
            }
            
            //Left puis Bottom
            if (Pos.x - 2 > 0 && Pos.y - 1 > 0)
            {
                if (board[Pos.x - 2, Pos.y - 1] == null || board [Pos.x - 2, Pos.y - 1].Color != Color) 
                { 
                    moves.Add(new Vector2Int(-2, -1)); 
                } 
                else if (board [Pos.x - 2, Pos.y - 1].Color == Color) {}
            }
            return moves;
        }
    }
}