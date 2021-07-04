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
    
    public static (int sx, int sy) GetDiagonalUpStart(int x, int y,int width, int height)
    {
        int x1=0, y1=0;
        height--;
        if ((y + x) > height)
        {
            int th = (y + x) - height;
            x1 = th;
            y1 = height;
        }
        else
        {
            x1 = 0;
            y1 = y + x;
        }
        
        return (x1, y1);
    }

    public static (int sx, int sy) GetDiagonalDownStart(int x, int y,int width, int height)
    {
        int x1=0, y1=0;
        int less = Math.Min(x, y);
        x1 = x - less;
        y1 = y - less;
        return (x1, y1);
    }

    static (int matrixWidth, int matrixHeight) GetMatrixWidthAndHeight(int[,] matrix)
    {
        return (matrix.GetLength(1), matrix.GetLength(0));
    }
    
    public static int[] GetDiagonalDown(int x, int y, int[,] board)
    {
        var (matrixWidth,matrixHeight) = GetMatrixWidthAndHeight(board);
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

    public static int[] GetDiagonalUp(int x, int y, int[,] board)
    {
        var (matrixWidth,matrixHeight) = GetMatrixWidthAndHeight(board);
        
        var arraySize = Math.Max(matrixWidth, matrixHeight);
        var res = new int[0];
        Array.Resize(ref res, res.Length + arraySize);
        var (diagonalStartX, diagonalStartY) = GetDiagonalUpStart(x, y, matrixWidth, matrixHeight);
        
        for (int i = 0 ; i < arraySize; i++)
        {
            res[i] = board[diagonalStartY,diagonalStartX];
            diagonalStartX++;
            diagonalStartY--;
            if (diagonalStartX >= matrixWidth || diagonalStartY < 0)
            {
                break;
            }
        }
        
        return res;
    }
}
