using System;
using Chesspiece;
using UnityEngine;

namespace Script
{
    public class ChessAI : MonoBehaviour
    {
        private Link _link;
        private Board _board;
        private bool PlayerTurn = true;
        
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

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump");
                Think();
            }
        }
        
        public void Think()
        {
            Node startingNode = new Node(_board);
            Node bestPlay = MinMax(startingNode, 2, PlayerTurn).Item1;
            startingNode = new Node(bestPlay.Board);
            
            if (PlayerTurn) 
            {
                PlayerTurn = false;
            }
            else
            {
                PlayerTurn = true;
            }
            startingNode.Board.SetupPieces();
        }
        
        public (Node, float) MinMax(Node node, int depth, bool maximizingPlayer )
        {
            Node NextNode = null;
            if (depth == 0 || node.GetChildren().Count == 0)
            { 
                return (node, node.GetHeuristic());
            }
            float value;
            
            if (maximizingPlayer)
            {
                value = Mathf.NegativeInfinity;
                foreach (Node child in node.GetChildren())
                {
                    value = Math.Max(value, MinMax(child, depth - 1, false).Item2);
                    if (NextNode == null)
                    {
                        NextNode = child;
                    }
                    if (NextNode.GetHeuristic() < child.GetHeuristic())
                    {
                        NextNode = child;
                    }
                }
            }
            //MinimizingPlayer
            else
            {
                value = Mathf.Infinity;
                foreach (Node child in node.GetChildren())
                {
                    value = Math.Min(value, MinMax(child, depth - 1, true).Item2);
                    if (NextNode == null)
                    {
                        NextNode = child;
                    }
                    if (NextNode.GetHeuristic() > child.GetHeuristic())
                    {
                        NextNode = child;
                    }
                }
            }
            return  (NextNode, value);
        }
    }
}