using System;
using System.Collections;
using System.Collections.Generic;
using Controllers.InputControllers;
using Controllers.UI;
using Items.Controller;
using UnityEngine;

namespace Controllers
{



    public class GameController : MonoBehaviour
    {
        
        public float GameScore = 0;
        public float Score = 0;
        public float BestScore;


        public GameObject inputController;
        
        
        public float BallSpeed;
        public float BallGravity;
        public float CameraStartSpeed;
        public float CameraSpeedMultiplier;
        public float CameraMaxSpeed;
        public static GameController GC;

        public MapGenerator Generator;
        public PlayerController Ball;
        public CameraController Camera;
        public ControllType controllType = ControllType.Touch;
        public GameState GameState = GameState.Menu;

        private void Awake()
        {
            if (!GC) GC = this;
            else Destroy(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            Load();
            UIController.UI.ShowUI<UIMainMenu>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

        }

        public void StartGame()
        {
            GameState = GameState.Play;
            Generator.NewGame();
            Camera.Init();
            Ball.gameObject.SetActive(true);
            Ball.GetComponent<PlayerController>().Init();
            Save();
        }

        public void GameOver()
        {
            GameState = GameState.Menu;
            Score += GameScore;
            Ball.gameObject.SetActive(false);
            Save();
        }

        public void Return()
        {
            Generator.Clear();
        }

        public void Continue()
        {
            GameState = GameState.Play;
            Ball.gameObject.SetActive(true);
        }

        

        

        void Save()
        {
            PlayerPrefs.SetFloat("bestScore", BestScore);
            PlayerPrefs.SetFloat("score", Score);
        }

        void Load()
        {
            if (PlayerPrefs.HasKey("score")) Score = PlayerPrefs.GetFloat("score");
            if (PlayerPrefs.HasKey("bestScore")) BestScore = PlayerPrefs.GetFloat("bestScore");
        }

    }

    public enum ControllType
    {
        Touch = 0,
        Accelerometer = 1,
        Drag = 2
    }

    public enum GameState
    {
        Play,
        Menu
    }
}
