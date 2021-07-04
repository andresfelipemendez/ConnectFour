using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    int[,] input = new[,]
    {  // 0   1   2   3   4
        { 1,  2,  3,  4,  5,},
        { 6,  7,  8,  9, 10,},
        {11, 12, 13, 14, 15,},
        {16, 17, 18, 19, 20,},
        {21, 22, 23, 23, 25,},
    };

    void PrintMatrix(int[,] mat)
    {
        string l="";
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                l += mat[i,j] + "\t";
            }

            l += "\n";

        }
        Debug.Log(l);
    }
    void PrintArray(int[] arr)
    {
        string l="";
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            
            l += arr[i] + "\t";
           
        }
        Debug.Log( l);
    }
    [Test]
    public void AddTile()
    {
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
        
        var res = TileManager.GetDiagonalDown(3, 0, input);
        var res1 = TileManager.GetDiagonalDown(4, 1, input);
         
        Assert.AreEqual(4, input[0,3]);
        Assert.AreEqual(10, input[1,4]);
        
        Assert.AreEqual(new []{4,10,0,0,0}, res);
        Assert.AreEqual(res, res1);
    }

    [Test]
    public void TestDiagonalUp()
    {
        {    
            var (diagonalStartX, diagonalStartY) = TileManager.GetDiagonalUpStart(1,1,5,5);
            Assert.AreEqual(0, diagonalStartX);
            Assert.AreEqual(2, diagonalStartY);
        }
        {
            var (diagonalStartX, diagonalStartY) = TileManager.GetDiagonalUpStart(1,1,2,3);
            Assert.AreEqual(0, diagonalStartX);
            Assert.AreEqual(2, diagonalStartY);
        }
        
        {
            var (diagonalStartX, diagonalStartY) = TileManager.GetDiagonalUpStart(3,0,4,2);
            Assert.AreEqual(2, diagonalStartX);
            Assert.AreEqual(1, diagonalStartY);
        }
        
        var res = TileManager.GetDiagonalUp(3, 0, input);
        var res1 = TileManager.GetDiagonalUp(4, 1, input);
        PrintArray(res);
        PrintArray(res1);
        Assert.AreEqual(new []{16,12,8,4,0}, res);
        Assert.AreEqual(new []{22,18,14,10,0}, res1);
    }

    [Test]
    public void TestWinCondition()
    {
        Assert.AreEqual((false,0), TileManager.IsWin(new []{0,0,0,0,0}));
        Assert.AreEqual((false,0), TileManager.IsWin(new []{1,0,1,0,1}));
        Assert.AreEqual((false,0), TileManager.IsWin(new []{1,1,1,0,0}));
        Assert.AreEqual((true,2), TileManager.IsWin(new []{0,2,2,2,2}));
        Assert.AreEqual((true,2), TileManager.IsWin(new []{2,2,2,2,2}));
        Assert.AreEqual((true,2), TileManager.IsWin(new []{2,2,2,2,0}));
        Assert.AreEqual((false,0), TileManager.IsWin(new []{2,2,0,2,2}));
        
        Assert.AreEqual((true,1), TileManager.IsWin(new []{0,1,1,1,1}));
        Assert.AreEqual((true,1), TileManager.IsWin(new []{1,1,1,1,1}));
        Assert.AreEqual((true,1), TileManager.IsWin(new []{1,1,1,1,0}));
        Assert.AreEqual((false,0), TileManager.IsWin(new []{1,1,0,1,1}));
    }

    [Test]
    public void AddTileByColumn()
    {
        var tileManager = new TileManager
        {
            NumberOfTiles = new int[7]
        };
        tileManager.AddTile(0,Player.P1);
        Assert.AreEqual(new int[]{ 1,0,0,0,0,0,0}, tileManager.NumberOfTiles);
        
        Assert.AreEqual(new int[6, 7]
        {
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {1, 0, 0, 0, 0, 0, 0},
        }, tileManager.Board);
        
        tileManager.AddTile(3,Player.P2);
        Assert.AreEqual(new int[]{ 1,0,0,1,0,0,0}, tileManager.NumberOfTiles);
        Assert.AreEqual(new int[6, 7]
        {
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {1, 0, 0, 2, 0, 0, 0},
        }, tileManager.Board);
        
        tileManager.AddTile(0,Player.P1);
        Assert.AreEqual(new int[]{ 2,0,0,1,0,0,0}, tileManager.NumberOfTiles);
        Assert.AreEqual(new int[6, 7]
        {
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {1, 0, 0, 0, 0, 0, 0},
            {1, 0, 0, 2, 0, 0, 0},
        }, tileManager.Board);
        
    }
    
    [Test]
    public void IntegrationTestWin()
    {
        var tileManager = new TileManager
        {
            NumberOfTiles = new int[7]
        };
        
        tileManager.AddTile(0,Player.P1);
        Assert.AreEqual(new int[]{ 1,0,0,0,0,0,0}, tileManager.NumberOfTiles);
        
        tileManager.AddTile(3,Player.P2);
        Assert.AreEqual(new int[]{ 1,0,0,1,0,0,0}, tileManager.NumberOfTiles);
        
        tileManager.AddTile(0,Player.P1);
        Assert.AreEqual(new int[]{ 2,0,0,1,0,0,0}, tileManager.NumberOfTiles);
        
        tileManager.AddTile(0,Player.P1);
        Assert.AreEqual(new int[]{ 3,0,0,1,0,0,0}, tileManager.NumberOfTiles);
       
        Assert.AreEqual(false,tileManager.DidTurnWin(0));
        
        tileManager.AddTile(0,Player.P1);
        Assert.AreEqual(new int[]{ 4,0,0,1,0,0,0}, tileManager.NumberOfTiles);
        
        Assert.AreEqual(true,tileManager.DidTurnWin(0));

    }
}
