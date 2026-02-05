using System;
using Chesspiece;
using UnityEngine;

namespace Script
{
    public class ChessAI : MonoBehaviour
    {
        Node Node;
        Board Board = new Board();

        private void Start()
        {
            //Création du board
            Board board = new Board();
            Debug.Log(board.Matrix.GetLength(0));
            Debug.Log(board.Matrix.GetLength(1));

            //permet de parcourir le plateau
            for (int i = 0; i < board.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < board.Matrix.GetLength(1); j++)
                {
                    Debug.Log(board.Matrix[i, j] + "");
                }
            }
        }

        [ContextMenu("MinMax")]
        private void Launch()
        {
            Think(Board.Matrix);
        }
        
        public void Think(Piece[,] board)
        {
            Node startingNode = new Node(Board);
            MinMax(startingNode, 2, true);
            Debug.Log("il joue !");
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