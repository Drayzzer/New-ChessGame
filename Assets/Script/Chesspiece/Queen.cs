using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public class Queen : Piece
    {
        public override int Value => 9;
        
        public Queen(ColorPiece color) : base(color) {}
        
        public override void MovePiece(Piece[,] board,Vector2Int movement)
        {
            board[movement.x, movement.y] = this;
            board[Pos.x, Pos.y] = null;
            Pos = movement;
        }
        
        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            
            // Right
            
            for (int i = Pos.x; i < board.GetLength(0); i++)
            {
                if (board[i, Pos.y] == null) 
                {
                    moves.Add(new Vector2Int(i, Pos.y)); 
                }
                else if (board[i, Pos.y].Color != Color)
                {
                    moves.Add(new Vector2Int(i, Pos.y));
                    break;
                }
                else if (board[i, Pos.y].Color == Color)
                {}
            } 
            
            // Left
            for (int i = Pos.x; i >= 0; i--)
            {
                if (board[i, Pos.y] == null )
                {
                    moves.Add(new Vector2Int(i, Pos.y)); 
                }
                else if (board[i, Pos.y].Color != Color)
                {
                    moves.Add(new Vector2Int(i, Pos.y));
                    break;
                }
                else if (board[i, Pos.y].Color == Color){}
            }
            
            // Top
            for (int i = Pos.y; i < board.GetLength(0); i++)
            { 
                if (board[Pos.x, i] == null) 
                {
                    moves.Add(Pos + new Vector2Int(Pos.x, i));
                    
                }
                else if (board[Pos.x, i].Color != Color)
                {
                    moves.Add(Pos + new Vector2Int(Pos.x, i));
                    break;
                }
                else if (board[Pos.x, i].Color == Color){}
            }
            
            //Bottom
            for (int i = Pos.y; i >= 0; i--)
            { 
                if (board[Pos.x,i] == null) 
                { 
                    moves.Add(Pos + new Vector2Int(Pos.x,i));
                }
                else if (board[Pos.x, i].Color != Color)
                {
                    moves.Add(Pos + new Vector2Int(Pos.x,i));
                    break;
                }
                else if (board[Pos.x, i].Color == Color) {}
               
            }
            
            // Right.Top
            for (Vector2Int i = Pos; i.x < board.GetLength(0) && i.y < board.GetLength(0); i += new Vector2Int(1, 1)) 
            { 
                if (board[Pos.x, Pos.y] == null )
                { 
                    moves.Add(Pos + i); 
                }
                else if (board[Pos.x, Pos.y].Color != Color)
                {
                    moves.Add(Pos + i);
                    break;
                }
                else if (board[Pos.x, Pos.y].Color == Color){}
            }
            
            // left.Top
            for (Vector2Int i = Pos; i.x >= 0 && i.y < board.GetLength(0); i += new Vector2Int(-1, 1))
            { 
                if (board[Pos.x, Pos.y] == null)
                { 
                    moves.Add(Pos + i);
                }
                else if (board[Pos.x, Pos.y].Color != Color)
                {
                    moves.Add(Pos + i);
                    break;
                }
                else if (board[Pos.x, Pos.y].Color == Color){}
            }
            
            // Right.Bottom
            for (Vector2Int i =  Pos; i.x < board.GetLength(0) && i.y >= 0; i += new Vector2Int(1, -1))
            {
                if (board[Pos.x, Pos.y] == null) 
                {
                    moves.Add(Pos + i); 
                }
                else if (board[Pos.x, Pos.y].Color != Color)
                {
                    moves.Add(Pos + i);
                    break;
                }
                else if (board[Pos.x, Pos.y].Color == Color){}
            }
            
            // Left.Bottom
            for (Vector2Int i =  Pos; i.x >= 0 && i.y >= 0; i += new Vector2Int(-1, -1))
            {
                if (board[Pos.x, Pos.y] == null) 
                { 
                    moves.Add(Pos + i); 
                }
                else if (board[Pos.x, Pos.y].Color != Color)
                {
                    moves.Add(Pos + i);
                    break;
                }
                else if (board[Pos.x, Pos.y].Color == Color){}
            }
            return moves;
        }
    }
}