using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
        UIController UI => UIController.UI;
        
        
        public float BallSpeed;
        public float BallGravity;
        public float CameraStartSpeed;
        public float CameraSpeedMultiplier;
        public float CameraMaxSpeed;
        public static GameController GC;

        public MapGenerator Generator;
        public PlayerController Ball;
        public Rigidbody2D BallBody => Ball.GetComponent<Rigidbody2D>();
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
            GameState = GameState.Menu;
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
            BallBody.simulated = true;
            Ball.Init();
            Save();
            UI.ShowUI<UIGame>();
        }

        public void RestoreGame()
        {
            
        }


        public void Death()
        {
            GameState = GameState.Pause;
            BallBody.simulated = false;
            UI.ShowUI<UIGameOver>();
            Save();
        }

        public void GameOver()
        {
            Generator.Clear();
            GameState = GameState.Menu;
            Camera.Init();
            Ball.Init();
            BallBody.simulated = false;
            UI.ShowUI<UIMainMenu>();
            Score += GameScore;
            Save();
        }

        public void PauseGame()
        {
            GameState = GameState.Pause;
            BallBody.simulated = false;
            Save();
        }
        public void ResumeGame()
        {
            GameState = GameState.Play;
            BallBody.simulated = true;
            Save();
        }



        public void Save()
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
        Pause,
        Menu
    }
}
