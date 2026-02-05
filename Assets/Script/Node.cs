using System.Collections.Generic;
using Chesspiece;
using Script;
using UnityEngine;

public class Node
{
    public Board Board;
    public ColorPiece PlayerTurn;

    //nouveau node 
    //constructeur
    public Node(Board board)
    {
        Board = board.Clone() as Board;
    }
    
    //Graph des noeuds
    public List<Node> GetChildren()
    {
        List<Node> children = new List<Node>();

        // Récupérer toutes les pièces de ma couleur
        foreach (Piece piece in Board.Matrix)
        {
            if (piece == null) continue;
            
            // Récupérer tout les mouvements de ma pièce
            foreach (Vector2Int move in piece.GetAvailableMoves(Board.Matrix))
            {
                // Cloner mon board actuel
                Board MBoard = (Board)Board.Clone();

                // Jouer le coup sur mon clone
                piece.MovePiece(MBoard.Matrix, move);
                if (PlayerTurn == ColorPiece.White)
                {
                    PlayerTurn = ColorPiece.Black;
                }
                if (PlayerTurn == ColorPiece.Black)
                {
                    PlayerTurn = ColorPiece.White;
                }
                //ajouter un nouveau noeud
                children.Add(new Node(MBoard));
            }
        }
        return children;
    }
    public int GetHeuristic()
    {
        int Totalheuristic = 0;
        // Je fait la somme de mes pièces moins la somme des pièces adverse
        foreach (Piece piece in Board.Matrix)
        {
            if (PlayerTurn == piece.Color)
            {
                
                Totalheuristic += piece.Value;
            }
            
            if (PlayerTurn == piece.Color)
            {
                Totalheuristic -= piece.Value;
            }
        }
        return Totalheuristic;
    }
}
