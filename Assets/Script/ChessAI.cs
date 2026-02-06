using System;
using Chesspiece;
using UnityEngine;

namespace Script
{
    public class ChessAI : MonoBehaviour
    {
        private Link _link;
        private Board _board;

        private void Start()
        {
            _link = GetComponent<Link>();
            
            //Création du board
             _board = new Board();
            _board.SetupBaseBoard();
            _board.SetupPieces();
            
            _link.SetAllTiles(_board);

            //permet de parcourir le plateau
            for (int i = 0; i < _board.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _board.Matrix.GetLength(1); j++)
                {
                    Debug.Log(_board.Matrix[i, j] + "");
                }
            }
        }

        [ContextMenu("MinMax")]
        private void Launch()
        {
            Think(_board.Matrix);
        }
        
        public void Think(Piece[,] board)
        {
            Node startingNode = new Node(_board);
            MinMax(startingNode, 2, true);
        }
        
        public float MinMax(Node node, int depth, bool maximizingPlayer)
        {
            if (depth == 0 || node.GetChildren().Count == 0)
            { 
                return node.GetHeuristic();
            } 
            float value;
            if (maximizingPlayer)
            {
                value = Mathf.NegativeInfinity;
                foreach (Node child in node.GetChildren())
                {
                    value = Math.Max(value, MinMax(child, depth - 1, false));
                }
            }
            else
            {
                value = Mathf.Infinity;
                foreach (Node child in node.GetChildren())
                {
                    value = Math.Min(value, MinMax(child, depth - 1, true));
                }
            }
            return value;
        }
    }
}