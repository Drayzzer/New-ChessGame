using System.Collections.Generic;
using UnityEngine;

namespace Chesspiece
{
    public class Rook : Piece
    {
        public override int Value => 5;
        
        public override void MovePiece(Piece[,] board,Vector2Int movement)
        {
            board[movement.x, movement.y] = this;
            board[Pos.x, Pos.y] = null;
            Pos = movement;
        }
        
        public Rook(ColorPiece color) : base(color) { }

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
                {
                    break;
                }
            }
            
            //Left
            for (int i = Pos.x; i >= 0; i--)
            {
                if (board[i, Pos.y] == null)
                {
                    moves.Add(new Vector2Int(-i, Pos.y));
                }
                else if (board[-i, Pos.y].Color != Color)
                {
                    moves.Add(new Vector2Int(-i, Pos.y));
                    break;
                }
                else if (board[-i, Pos.y].Color == Color)
                {
                    break;
                }
            }
            
            // Top
            for (int i = Pos.y; i < board.GetLength(0); i++)
            {
                if (board[Pos.x, i] == null)
                {
                    moves.Add(new Vector2Int(Pos.x, i)); 
                }
                else if (board[Pos.x, i].Color != Color)
                {
                    moves.Add(new Vector2Int(Pos.x, i)); 
                    break;
                }
                else if (board[Pos.x, i].Color == Color)
                {
                    break;
                }
            }
            
            // Bottom
            for (int i = Pos.y; i >= 0; i--)
            {
                if (board[Pos.x, i] == null)
                {
                    moves.Add(new Vector2Int(Pos.x, -i)); 
                }
                else if (board[Pos.x, -i].Color != Color)
                {
                    moves.Add(new Vector2Int(Pos.x, -i));
                    break;
                }
                else if (board[Pos.x, -i].Color == Color)
                {
                    break;
                }
            }
            return moves;
        }
    }
}