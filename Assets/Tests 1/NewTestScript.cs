using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    [Test]
    public void AddTile()
    {
        // Use the Assert class to test conditions
        var tilemanager = new TileManager();
        tilemanager.AddTile(0, 0, 1);
        Assert.AreEqual(1, tilemanager.Board[0,0]);
    }
    
    [Test]
    public void TestWin()
    {
        // Use the Assert class to test conditions
        var tilemanager = new TileManager();
        tilemanager.Board = new int[6, 7]
        {
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 0, 0, 0},
        };
        tilemanager.AddTile(0, 0, 1);
        
        
        for (int i = 0; i < tilemanager.Board.GetLength(0); i++)
        {
            string l="";
            for (int j = 0; j < tilemanager.Board.GetLength(1); j++)
            {
                l += tilemanager.Board[i,j] + "\t";
            }
            Debug.Log( l);
        }
        
        Assert.AreEqual(tilemanager.Board, new int[6, 7] {
            {1, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 0, 0, 0},
        });
    }
}
