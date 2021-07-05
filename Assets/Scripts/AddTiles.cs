using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(GameManager))]
public class AddTiles : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tilesContainers;
    public GameObject p1TilePrefab;
    public GameObject p2TilePrefab;
    private TileManager _tileManager = new TileManager();
    public Player player = Player.P1;
    public GameManager gameManager;
    public bool isAIEnabled = false;
    private MiniMaxAI _ai = new MiniMaxAI();
    
    public void Clear()
    {
        player = Player.P1;
        _tileManager.Clear();
    }
    
    public  void AddListeners()
    {
        var numberOfColumn = new ArrayList();
        var buttons = GameObject.FindGameObjectsWithTag(tag: "AddTileButton");
        for (var i = 0; i < buttons.Length; i++)
        {
            var i1 = i;
            buttons[i].GetComponent<Button>()?.onClick.AddListener(call: ()=> AddTile(index: i1));
            numberOfColumn.Add(0);
        }

        _tileManager.NumberOfTiles = (int[]) numberOfColumn.ToArray(typeof(int));
    }

    public void RemoveListeners()
    {
        var buttons = GameObject.FindGameObjectsWithTag(tag: "AddTileButton");
        for (var i = 0; i < buttons.Length; i++)
        {
            var i1 = i;
            buttons[i].GetComponent<Button>()?.onClick.RemoveAllListeners();
        }
    }

    private void AddTile(int index) {
        
        Instantiate(player == Player.P1 ? p1TilePrefab : p2TilePrefab, tilesContainers.GetChild(index));
        _tileManager.AddTile(index,player);
        if (_tileManager.DidTurnWin(index))
        {
            gameManager.GameOver();
            return;
        }
        player = player == Player.P1 ? Player.P2 : Player.P1;
        gameManager.UpdatePlayerLabel();
        
        if (isAIEnabled && player == Player.P2)
        {
            //var (s, col) = _ai.Random(_tileManager);
            int col = Random.Range(0, 7);
            AddTile(col);
        }
        
        
    }

}
