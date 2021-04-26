using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class UIGame : UIBase
    {
        public List<Image> hearths = new List<Image>();
        public Text ScoreText;
        public GameObject pausePanel;
        public List<GameObject> Hide = new List<GameObject>();


        private PlayerController player => GameController.GC.Ball;

        private void Start()
        {
        }

        private void Update()
        {
            string txt;
            float dis = (Mathf.Round(Vector2.Distance(player.transform.position, Vector2.zero))) / 10;
            txt = dis.ToString();
            ScoreText.text = txt;
            GC.Data.GameScore = dis;
        }

        public override void Open()
        {
            
        }

        public override void Close()
        {
            
        }

        public void ChangeHealth()
        {
            int count = player.ball.Health;
            switch (count)
            {
                case 1:
                {
                    hearths[0].enabled = true;
                    hearths[1].enabled = false;
                    hearths[2].enabled = false;
                 break;   
                }
                case 2:
                {
                    hearths[0].enabled = true;
                    hearths[1].enabled = true;
                    hearths[2].enabled = false;
                    break;
                }
                case 3:
                {
                    hearths[0].enabled = true;
                    hearths[1].enabled = true;
                    hearths[2].enabled = true;
                    break;
                }
                default:
                {
                    break;
                }
            }
        }

        public void PauseGame()
        {
            pausePanel.SetActive(true);
            GC.Save();
            Time.timeScale = 0;
        }

        public void UnPauseGame()
        {

            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void EndGame()
        {
            UnPauseGame();
            GameController.GC.GameOver();
            UIController.UI.ShowUI<UIMainMenu>();
        }
    }
}