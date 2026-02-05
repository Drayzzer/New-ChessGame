using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public class Bishop : Piece
    {
        public override int Value => 3;
        public override void MovePiece(Piece[,] board,Vector2Int movement)
        {
            board[movement.x, movement.y] = this;
            board[Pos.x, Pos.y] = null;
            Pos = movement;
        }
        public Bishop(ColorPiece color) : base(color) {}

        public override List<Vector2Int> GetAvailableMoves(Piece[,] board)
        {
            List<Vector2Int> moves = new List<Vector2Int>();
            
            //right.Top
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
                else if (board[Pos.x, Pos.y].Color == Color)
                {
                    break;
                }
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
                else if (board[Pos.x, Pos.y].Color == Color)
                {
                    break;
                }
               
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
                else if (board[Pos.x, Pos.y].Color == Color)
                {
                    break;
                }
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
                else if (board[Pos.x, Pos.y].Color == Color)
                {
                    break;
                }
            }
            return moves;
        }
    }
}
