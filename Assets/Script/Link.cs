using Chesspiece;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Script
{
    public class Link : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap;
         
         Board _board = new Board();
         
        [SerializeField] private TileBase WhitePawn;
        [SerializeField] private TileBase BlackPawn;
        [SerializeField] private TileBase WhiteRook;
        [SerializeField] private TileBase BlackRook;
        [SerializeField] private TileBase WhiteKnight;
        [SerializeField] private TileBase BlackKnight;
        [SerializeField] private TileBase WhiteBishop;
        [SerializeField] private TileBase BlackBishop;
        [SerializeField] private TileBase WhiteKing;
        [SerializeField] private TileBase BlackKing;
        [SerializeField] private TileBase WhiteQueen;
        [SerializeField] private TileBase BlackQueen;
        
        [ContextMenu("Set All Tiles")]
        private void Tilebase ()
        {
            for (int i = 0; i < _board.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _board.Matrix.GetLength(1); j++)
                {
                    Piece piece = _board.Matrix[i, j];
                    //permet de placer les pions sur l'échiquier
                    switch (piece)
                    {
                        case Pawn:
                            tilemap.SetTile(new Vector3Int(j, i, 0), piece.Color == ColorPiece.White ? WhitePawn : BlackPawn);
                            break;
                        case Rook: 
                            tilemap.SetTile(new Vector3Int(j, i, 0), piece.Color == ColorPiece.White ? WhiteRook : BlackRook);
                            break;
                        case Knight: 
                            tilemap.SetTile(new Vector3Int(j, i, 0), piece.Color == ColorPiece.White ? WhiteKnight : BlackKnight);
                            break;
                        case Bishop: 
                            tilemap.SetTile(new Vector3Int(j, i, 0), piece.Color == ColorPiece.White ? WhiteBishop : BlackBishop);
                            break;
                        case Queen: 
                            tilemap.SetTile(new Vector3Int(j, i, 0), piece.Color == ColorPiece.White ? WhiteQueen : BlackQueen);
                            break;
                        case King: 
                            tilemap.SetTile(new Vector3Int(j, i, 0), piece.Color == ColorPiece.White ? WhiteKing : BlackKing);
                            break;
                        default: break;
                    }
                }
            } 
            return;
        }
        [ContextMenu("Clear All Tiles")]
        public void ClearAllTiles()
        {
            tilemap.ClearAllTiles();
        }
    }
}