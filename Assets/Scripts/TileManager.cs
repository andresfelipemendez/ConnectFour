using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager 
{
    public int[,] Board = new int[6, 7];
    public void AddTile(int x, int y, int val)
    {
        Board[x, y] = val;
    }

    public static int[] GetUpDiagonal(int x, int y, int[,] board)
    {

        var matrixWidth = board.GetLength(1);
        var matrixHeight = board.GetLength(0);
        int arraySize = Math.Max(matrixWidth, matrixHeight);
        int[] res = new int[0];
        Array.Resize(ref res, res.Length + arraySize);
         
        for (int i = 0 ; i < arraySize; i++)
        {
            res[i] = board[y,x];
            x++;
            y++;
            if (x >= matrixWidth || y >= matrixHeight)
            {
                break;
            }
            
        }
        
        return res;
    }
}
