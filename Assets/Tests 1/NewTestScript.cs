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

    [Test]
    public void TestDiagonal()
    {
        var input = new[,]
        {
            { 1,  2,  3,  4,  5,},
            { 6,  7,  8,  9, 10,},
            {11, 12, 13, 14, 15,},
            {16, 17, 18, 19, 20,},
            {21, 22, 23, 23, 25,},
        };
        var res = TileManager.GetUpDiagonal(3, 0, input);
        string l="";
        for (int i = 0; i < res.GetLength(0); i++)
        {
            
            l += res[i] + "\t";
           
        }
        Debug.Log( l); 
        Assert.AreEqual(4, input[0,3]);
        Assert.AreEqual(10, input[1,4]);
        Assert.AreEqual(new []{4,10}, res);
    }
}
