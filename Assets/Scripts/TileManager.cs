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

    public static (int sx, int sy) GetDiagonalDownStart(int x, int y,int width, int height)
    {
        int x1=0, y1=0;
        int less = Math.Min(x, y);
        x1 = x - less;
        y1 = y - less;
        return (x1, y1);
    }
    public static int[] GetDiagonalDown(int x, int y, int[,] board)
    {
        var matrixWidth = board.GetLength(1);
        var matrixHeight = board.GetLength(0);
        var arraySize = Math.Max(matrixWidth, matrixHeight);
        var res = new int[0];
        Array.Resize(ref res, res.Length + arraySize);
        var (diagonalStartX, diagonalStartY) = GetDiagonalDownStart(x, y, matrixWidth, matrixHeight);
        for (int i = 0 ; i < arraySize; i++)
        {
            res[i] = board[diagonalStartY,diagonalStartX];
            diagonalStartX++;
            diagonalStartY++;
            if (diagonalStartX >= matrixWidth || diagonalStartY >= matrixHeight)
            {
                break;
            }
        }
        
        return res;
    }
}
