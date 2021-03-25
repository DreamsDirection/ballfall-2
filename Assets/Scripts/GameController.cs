using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController GC;
    public float Score= 0;

    public GameUI UI;
    public MapGenerator Generator;
    public GameObject Ball;
    public CameraController Camera;

    private void Awake()
    {
        if (!GC) GC = this;
        else Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }


    public void StartGame()
    {
        UI.MainMenuIsActive(false);
        Generator.NewGame();
        Ball.SetActive(true);
        Ball.GetComponent<PlayerController>().Health = 3;
        Camera.transform.position = new Vector3(0,0,-10);
        Camera.Move = true;
        UI.GameOverPanelIsActive(false);
    }

    public void GameOver()
    {
        Ball.transform.position = Vector2.zero;
        Ball.SetActive(false);
        UI.GameOverPanelIsActive(true);
        Camera.Move = false;
    }

    public void EndGame()
    {
        UI.MainMenuIsActive(true);
        UI.GameOverPanelIsActive(false);
    }
    
}
