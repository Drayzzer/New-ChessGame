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
            for (int i = Pos.x + 1; i < board.GetLength(0); i++)
            {
                if (!TryAddPosition(board, moves, new Vector2Int(i, 0))) break;
            }
            
            // Left
            for (int i = Pos.x - 1; i >= 0; i--)
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(-i, 0))) break;
            }
            
            // Top
            for (int i = Pos.y + 1; i < board.GetLength(0); i++)
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(0, i))) break; 
            }
            
            //Bottom
            for (int i = Pos.y - 1; i >= 0; i--)
            {
                if (!TryAddPosition(board, moves, new Vector2Int(0, -i))) break;
            }
            
            // Right.Top
            for (int i = 0; i < board.GetLength(0); i++) 
            { 
                if (!TryAddPosition(board, moves, new Vector2Int(Pos.x + i, Pos.y + i))) break;
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