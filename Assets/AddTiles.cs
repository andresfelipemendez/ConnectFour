using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddTiles : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tilesContainers;
    public GameObject tilePrefab;
    private void Start()
    {
        var buttons = GameObject.FindGameObjectsWithTag(tag: "AddTileButton");
        for (var i = 0; i < buttons.Length; i++)
        {
            var i1 = i;
            buttons[i].GetComponent<Button>()?.onClick.AddListener(call: ()=> addTile(index: i1));
        }
    }

    private void addTile(int index) {
        Debug.Log ("You have clicked the button! " + index);
      //  tilesContainers.GetChild(index)
            
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
