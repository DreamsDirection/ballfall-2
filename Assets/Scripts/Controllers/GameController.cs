using System;
using System.Collections;
using System.Collections.Generic;
using BallFall.Controllers.UI;
using UnityEngine;

namespace BallFall.Controllers
{



    public class GameController : MonoBehaviour
    {
        public float BallSpeed;
        public float BallGravity;
        public float CameraStartSpeed;
        public float CameraSpeedMultiplier;
        public float CameraMaxSpeed;
        public static GameController GC;
        public float GameScore = 0;
        public float Score = 0;
        public float BestScore;

        public GameUI UI;
        public MapGenerator Generator;
        public GameObject Ball;
        public CameraController Camera;
        public ControllType controllType = ControllType.LeftRight;

        private void Awake()
        {
            if (!GC) GC = this;
            else Destroy(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            Load();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

        }

        public void StartGame()
        {
            UI.HideMainMenu();
            Generator.NewGame();
            Ball.transform.position = Vector2.zero;
            Ball.SetActive(true);
            Camera.transform.position = new Vector3(0, 0, -10);
            Camera.Move = true;
            UI.HideGameOverPanel();
            UI.ShowGamePanel();


            Ball.GetComponent<PlayerController>().Init();
            Camera.Init();
            Save();
        }

        public void GameOver()
        {
            Score += GameScore;
            Ball.transform.position = Vector2.zero;
            Ball.SetActive(false);
            UI.ShowGameOverPanel();
            Camera.Move = false;
            UI.HideGamePanel();
            Save();
        }

        public void EndGame()
        {
            UI.ShowMainMenu();
            UI.HideGameOverPanel();
            UI.HideGamePanel();
            Ball.SetActive(false);
            Camera.Move = false;
            Save();
        }

        public void SetAccelerometerControll()
        {
            controllType = ControllType.Accelerometer;
        }

        public void SetTouchControll()
        {
            controllType = ControllType.Touch;
        }

        public void SetLeftRightControll()
        {
            controllType = ControllType.LeftRight;
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
        LeftRight,
        Accelerometer,
        Touch
    }
}
