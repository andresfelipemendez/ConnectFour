using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddTiles : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tilesContainers;
    public GameObject p1TilePrefab;
    public GameObject p2TilePrefab;
    private TileManager _tileManager = new TileManager();
    public Player player = Player.P1;
    
    private void Start()
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

    private void AddTile(int index) {
        
        Instantiate(p1TilePrefab, tilesContainers.GetChild(index));
        _tileManager.AddTile(index,player);
        //_tileManager.NumberOfTiles[index]++;
    }
    
}
