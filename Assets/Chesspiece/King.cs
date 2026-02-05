using System.Collections.Generic;

using UnityEngine;

namespace Chesspiece
{
    public class King : Piece
    {
        public override int Value => int.MaxValue;
        
        public override void MovePiece(Piece[,] board,Vector2Int movement)
        {
            board[movement.x, movement.y] = this;
            board[Pos.x, Pos.y] = null;
            Pos = movement;
        }
        
        public King(ColorPiece color) : base(color) {}

        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();

            // Right
            if (Pos.x + 1 < board.GetLength(0))
            {
                if (board[1, Pos.y] == null || board[1, Pos.y].Color != Color)
                { 
                    moves.Add(new Vector2Int(1, Pos.y)); 
                }
                else if (board[0, Pos.y].Color == Color){}
            }
            
            // Left
            if (Pos.x - 1 > 0 )
            {
                if (board[-1, Pos.y] == null || board[-1, Pos.y].Color != Color) 
                { 
                    moves.Add(new Vector2Int(-1, Pos.y)); 
                }
                else if (board[0, Pos.y].Color == Color){}
            }
            
            
            // Top
            if (Pos.y + 1 < board.GetLength(1))
            {
                if (board[Pos.x, 1] == null || board[Pos.x, 1].Color != Color) 
                { 
                    moves.Add(new Vector2Int(Pos.x, 1)); 
                } 
                else if (board[Pos.x, 0].Color == Color){}
            }
            
            // Bottom
            if (Pos.y - 1 > 0)
            {
                if (board[Pos.x, -1] == null || board[Pos.x, -1].Color != Color) 
                { 
                    moves.Add(new Vector2Int(Pos.x, -1)); 
                } 
                else if (board[Pos.x, 0].Color == Color){}
            }
           
            
            // Right.Top
            if (Pos.x + 1 < board.GetLength(0) && Pos.y + 1 < board.GetLength(1))
            {
                if (board[Pos.x + 1, Pos.y + 1] == null || board[Pos.x + 1, Pos.y + 1].Color != Color)
                { 
                    moves.Add(new Vector2Int(Pos.x + 1, Pos.y + 1));
                }
                else if (board[0, 0].Color == Color){}
            }
           
                
            // left.Top
            if (Pos.x - 1 > 0 && Pos.y + 1 < board.GetLength(1))
            {
                if (board[Pos.x - 1, Pos.y + 1] == null || board[Pos.x - 1, Pos.y + 1].Color != Color)
                { 
                    moves.Add(new Vector2Int(Pos.x - 1, Pos.y + 1));
                }
                else if (board[0, 0].Color == Color){}
            }
           
                
            // Right.Bottom
            if (Pos.x + 1 < board.GetLength(0) && Pos.y - 1 > 0)
            {
                if (board[Pos.x + 1, Pos.y - 1] == null || board[Pos.x + 1, Pos.y - 1].Color != Color)
                { 
                    moves.Add(new Vector2Int(Pos.x + 1, Pos.y - 1));
                }
                else if (board[0, 0].Color == Color){}
            }
            
            
            // Left.Bottom
            if (Pos.x - 1 > 0 && Pos.y - 1 > 0)
            {
                if (board[Pos.x - 1, Pos.y - 1] == null || board[Pos.x - 1, Pos.y - 1].Color != Color)
                { 
                    moves.Add(new Vector2Int(Pos.x - 1, Pos.y - 1));
                }
                else if (board[0, 0].Color == Color){}
            }
            return moves;
        }
    }
}
