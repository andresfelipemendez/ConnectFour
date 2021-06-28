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

    private void Awake()
    {
        
    }

    private void Start()
    {
        var buttons = GameObject.FindGameObjectsWithTag(tag: "AddTileButton");
        for (var i = 0; i < buttons.Length; i++)
        {
            var i1 = i;
            buttons[i].GetComponent<Button>()?.onClick.AddListener(call: ()=> AddTile(index: i1));
        }
    }

    private void AddTile(int index) {
        Debug.Log ("You have clicked the button! " + index);
        Instantiate(p1TilePrefab, tilesContainers.GetChild(index));
    }
    
}
