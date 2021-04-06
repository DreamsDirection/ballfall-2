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

    private float startSpeedCamera;
    public void StartGame()
    {
        startSpeedCamera = Camera.Speed;
        UI.HideMainMenu();
        Generator.NewGame();
        Ball.SetActive(true);
        Ball.GetComponent<PlayerController>().Health = 3;
        Camera.transform.position = new Vector3(0,0,-10);
        Camera.Move = true;
        UI.HideGameOverPanel();
        UI.ShowGamePanel();
    }

    public void GameOver()
    {
        Camera.Speed = startSpeedCamera;
        Ball.transform.position = Vector2.zero;
        Ball.SetActive(false);
        UI.ShowGameOverPanel();
        Camera.Move = false;
        UI.HideGamePanel();
    }

    public void EndGame()
    {
        UI.ShowMainMenu();
        UI.HideGameOverPanel();
        UI.HideGamePanel();
    }
    
}
