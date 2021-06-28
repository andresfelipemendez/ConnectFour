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
}
