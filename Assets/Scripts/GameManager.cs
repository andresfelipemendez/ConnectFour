using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public enum GameState{
    Menu,
    GamePlay,
    End
}

[RequireComponent(typeof(AddTiles))]
public class GameManager : MonoBehaviour
{
    public GameObject beginMenu;
    public GameObject gamePanel;
    
    public GameObject winPanel;
    
    public Transform ContainerOfTileContainers;
    public Text winText;

    private GameState _state = GameState.Menu;
    private AddTiles _tileManager;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _tileManager = GetComponent<AddTiles>();
        _tileManager.gameManager = this;
    }

    void Start()
    {
        GoToState(GameState.Menu);
    }
    
    private void GoToState(GameState targetState)
    {
        switch (targetState)
        {
            case GameState.Menu:  
                beginMenu.SetActive(true);
                winPanel.SetActive(false);
                winText.text = "";
            
                gamePanel.SetActive(false);
                
                break;
            case GameState.GamePlay:
                
                beginMenu.SetActive(false);
                gamePanel.SetActive(true);
                _tileManager.AddListeners();
                break;
            case GameState.End:
                winPanel.SetActive(true);
                winText.text = (_tileManager.player == Player.P1 ? "Player 1" : "Player 2") + "Win!!!"; 
                _tileManager.RemoveListeners();
                break;
            default:
                break;
        }
    }
    
    public void BeginGame()
    { 
        GoToState(GameState.GamePlay);
    }
    public void  GameOver(){
        
        GoToState(GameState.End);
    }

    public void PlayAgain()
    {
        ClearBoard();
        GoToState(GameState.Menu);
    }

    private void ClearBoard()
    {
        for (int i = 0; i < ContainerOfTileContainers.childCount; i++)
        {
            foreach (Transform child in ContainerOfTileContainers.GetChild(i))
            {
                GameObject.Destroy(child.gameObject);
            }

            _tileManager.Clear();
        }
    }

    public void EnableAI()
    {
        _tileManager.isAIEnabled = !_tileManager.isAIEnabled;
    }
}
