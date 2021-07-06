using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    P1 = 1,
    P2 = 2
}
public class TileManager
{
    public int[] NumberOfTiles;
    public int[,] Board;
    public int numberOfMoves;

    public TileManager()
    {
        NumberOfTiles = new int[7];
        Board = new int[6, 7];
        numberOfMoves = 0;
    }

    public void Clear()
    {
        NumberOfTiles = new int[7];
        Board = new int[6, 7];
        numberOfMoves = 0;
    }

    public TileManager(TileManager other)
    {
        this.numberOfMoves = other.numberOfMoves;
        this.NumberOfTiles = other.NumberOfTiles.Clone() as int[];
        this.Board = other.Board.Clone() as int[,];
    }

    public void AddTile(int column, Player player)
    {
        if (NumberOfTiles[column] >= Board.GetLength(0))
            return;
        NumberOfTiles[column]++;
        var y = (Board.GetLength(0)) - NumberOfTiles[column];
        var x = column;
        Board[y, x] = (int)player;
        numberOfMoves++;
    }

    public bool IsLegalMove(int column)
    {
        return NumberOfTiles[column] < Board.GetLength(0);
    }

    public bool DidTurnWin(int column)
    {
        var y = (Board.GetLength(0)) - NumberOfTiles[column];
        var x = column;

        var upDiagonal = GetDiagonalUp(x, y, Board);
        var downDiagonal = GetDiagonalDown(x, y, Board);
        var row = GetRow(y, Board);
        var col = GetColumn(x, Board);

        var (udWin, udPlayer) = IsWin(upDiagonal);
        var (ddWin, ddPlayer) = IsWin(downDiagonal);
        var (rWin, rPlayer) = IsWin(row);
        var (cWin, cPlayer) = IsWin(col);

        return udWin || ddWin || rWin || cWin;
    }

    public bool WouldTurnWin(int column, Player player)
    {
        NumberOfTiles[column]++;
        var y = (Board.GetLength(0)) - NumberOfTiles[column];
        var x = column;
        Board[y, x] = (int)player;

        var win = DidTurnWin(column);

        NumberOfTiles[column]--;
        Board[y, x] = 0;

        return win;
    }

    public void AddTile(int x, int y, int val)
    {
        Board[x, y] = val;
    }

    public static (int sx, int sy) GetDiagonalUpStart(int x, int y, int width, int height)
    {
        int x1 = 0, y1 = 0;
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

    public static int[] GetRow(int y, int[,] board)
    {
        ArrayList row = new ArrayList();
        int width = board.GetLength(1);
        for (int i = 0; i < width; i++)
        {
            row.Add(board[y, i]);
        }
        return (int[])row.ToArray(typeof(int));
    }

    public static int[] GetColumn(int x, int[,] board)
    {
        ArrayList column = new ArrayList();
        int height = board.GetLength(0);
        for (int i = 0; i < height; i++)
        {
            column.Add(board[i, x]);
        }
        return (int[])column.ToArray(typeof(int));
    }

    public static (int sx, int sy) GetDiagonalDownStart(int x, int y, int width, int height)
    {
        int x1 = 0, y1 = 0;
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
        var (matrixWidth, matrixHeight) = GetMatrixWidthAndHeight(board);
        var arraySize = Math.Max(matrixWidth, matrixHeight);
        var res = new int[0];
        Array.Resize(ref res, res.Length + arraySize);
        var (diagonalStartX, diagonalStartY) = GetDiagonalDownStart(x, y, matrixWidth, matrixHeight);
        for (int i = 0; i < arraySize; i++)
        {
            res[i] = board[diagonalStartY, diagonalStartX];
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
        var (matrixWidth, matrixHeight) = GetMatrixWidthAndHeight(board);

        var arraySize = Math.Max(matrixWidth, matrixHeight);
        var res = new int[0];
        Array.Resize(ref res, res.Length + arraySize);
        var (diagonalStartX, diagonalStartY) = GetDiagonalUpStart(x, y, matrixWidth, matrixHeight);

        for (int i = 0; i < arraySize; i++)
        {
            res[i] = board[diagonalStartY, diagonalStartX];
            diagonalStartX++;
            diagonalStartY--;
            if (diagonalStartX >= matrixWidth || diagonalStartY < 0)
            {
                break;
            }
        }

        return res;
    }

    public static (bool res, int player) IsWin(int[] line)
    {
        int count = 0, player = 0;
        var len = line.Length - 1;
        for (var i = 0; i < len; i++)
        {
            var next = i + 1;

            if (line[i] == 0 || line[i] != line[next])
            {
                count = 0;
            }
            else
            {
                count++;
            }

            if (count == 3)
            {
                player = line[i];
                break;
            }
        }

        return (player != 0, player);
    }


}
