using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Controllers.InputControllers;
using Controllers.UI;
using Items.Controller;
using Items.Models;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Controllers
{



    public class GameController : MonoBehaviour
    {
        public GameObject inputController;
        private Dictionary<int,InputControllerBase> InputTypes = new Dictionary<int, InputControllerBase>();
        UIController UI => UIController.UI;
        public GameData Data;
        
        
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
        public GameState GameState = GameState.Menu;

        private void Awake()
        {
            if (!GC) GC = this;
            else Destroy(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            InputTypes.Add(1,new InputControllerTouch());
            InputTypes.Add(2,new InputControllerAccelerometer());
            InputTypes.Add(3,new InputControllerDrag());
            
            
            Load();
            GameState = GameState.Menu;
            UIController.UI.ShowUI<UIMainMenu>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return)
                | Input.GetKeyDown(KeyCode.Home)
                | Input.GetKeyDown(KeyCode.Menu)
                | Input.GetKeyDown(KeyCode.Escape))
                Save();
        }

        public void StartGame()
        {
            GameState = GameState.Play;
            Data.InGame = true;
            Generator.NewGame();
            Camera.Init();
            BallBody.simulated = true;
            Ball.Init();
            Save();
            UI.ShowUI<UIGame>();
        }
        public void ContinueGame()
        {
            Debug.LogWarning("PlayerY- " + Data.BallPositionY + "\nPlayerX- " + Data.BallPositionX);            
            
            
            GameState = GameState.Play;
            BallBody.simulated = true;
            Ball.Init(Data.BallPositionY,Data.BallPositionX);
            Data.InGame = true;
            Camera.Init(Data.CameraPositionY);
            Generator.ContinueGame(Data);
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
            Data.InGame = false;
            GameState = GameState.Menu;
            Camera.Init();
            Ball.Init();
            BallBody.simulated = false;
            UI.ShowUI<UIMainMenu>();
            Data.Money += Data.GameScore;
            if (Data.GameScore > Data.BestScore) Data.BestScore = Data.GameScore;
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
            Data.BallPositionX = Ball.transform.position.x;
            Data.BallPositionY = Ball.transform.position.y;
            Data.CameraPositionY = Camera.transform.position.y;
            Data.InputType = inputController.GetComponent<InputControllerBase>().InputType;
            
            PersistentCache.Save(Data);
            Debug.Log("Saved");
        }

        void Load()
        {
            Data = PersistentCache.TryLoad<GameData>();
            if (Data == null)
            {
                Debug.Log("Data load unsuccessful");
                Data = new GameData();
            }
            SetControll(Data.InputType);
        }

        public void SetControll(int id)
        {
            Destroy(inputController.GetComponent<InputControllerBase>());
            switch (id)
            {
                case 0:
                {
                    inputController.AddComponent<InputControllerTouch>();
                    break;
                }
                case 1:
                {
                    inputController.AddComponent<InputControllerAccelerometer>();
                    break;
                }
                case 2:
                {
                    inputController.AddComponent<InputControllerDrag>();
                    break;
                }
            }
        
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
