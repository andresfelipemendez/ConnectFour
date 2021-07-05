using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniMaxAI
{
    public (int score, int col) NegaMax(TileManager p)
    {
       for (int i = 0; i < 7; i++)
       {
           if (p.IsLegalMove(i) && p.WouldTurnWin(i, Player.P2))
           {
               return ((p.Board.GetLength(1) * p.Board.GetLength(0) + 1 -p.numberOfMoves) / 2, i);
           } 
       }

       int bestScore = -p.Board.GetLength(1) * p.Board.GetLength(0);
       int resCol = 0;
       for (int i = 0; i < 7; i++)
       {
           if (p.IsLegalMove(i))
           {
               TileManager copy = new TileManager(p); ;
               p.AddTile(i, Player.P1);
               (int score, int copyCol) = NegaMax(copy);
               if (-score > score)
               {
                   bestScore = -score;
                   resCol = copyCol;
               }
               
           }
       }

       return (bestScore, resCol);
    }
}
