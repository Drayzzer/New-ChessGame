using System;
using Chesspiece;
using UnityEngine;

namespace Script
{
    public class Board : ICloneable
    {
        //l'échiquier
        public Piece[,] Matrix;

        public void SetupBaseBoard()
        {
            Matrix = new Piece[,]
            {
                { new Rook(ColorPiece.Black), new Knight(ColorPiece.Black), new Bishop(ColorPiece.Black), new King(ColorPiece.Black), new Queen(ColorPiece.Black), new Bishop(ColorPiece.Black), new Knight(ColorPiece.Black), new Rook(ColorPiece.Black) },
                { new Pawn(ColorPiece.Black), new Pawn(ColorPiece.Black), new Pawn(ColorPiece.Black), new Pawn(ColorPiece.Black), new Pawn(ColorPiece.Black), new Pawn(ColorPiece.Black), new Pawn(ColorPiece.Black), new Pawn(ColorPiece.Black) },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { new Pawn(ColorPiece.White), new Pawn(ColorPiece.White), new Pawn(ColorPiece.White), new Pawn(ColorPiece.White), new Pawn(ColorPiece.White), new Pawn(ColorPiece.White), new Pawn(ColorPiece.White), new Pawn(ColorPiece.White)
                },
                { new Rook(ColorPiece.White), new Knight(ColorPiece.White), new Bishop(ColorPiece.White), new King(ColorPiece.White), new Queen(ColorPiece.White), new Bishop(ColorPiece.White), new Knight(ColorPiece.White), new Rook(ColorPiece.White) },
            };
        }
        
        public void SetupTestBoard()
        {
            Matrix = new Piece[,]
            {
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, new Pawn(ColorPiece.Black), null, null, null, null },
                { null, null, null, null, null, null, null, null }
            };
        }
        
        public void SetupPieces()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Piece piece = Matrix[i, j];
                    if (piece != null) piece.Pos = new Vector2Int(i, j);
                }
            }
        }

        public object Clone()
        {
            Board obj = new Board
            {
                Matrix = new Piece[Matrix.GetLength(0), Matrix.GetLength(1)]
            };
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Piece piece = Matrix[i, j];
                    obj.Matrix[i, j] = (Piece)piece?.Clone();
                }
            }
            return obj;
        }
    }
}