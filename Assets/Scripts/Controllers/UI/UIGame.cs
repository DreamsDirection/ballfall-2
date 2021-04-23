using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class UIGame : MonoBehaviour
    {
        public List<Image> hearths = new List<Image>();
        public Text ScoreText;
        public GameObject pausePanel;


        private PlayerController player => GameController.GC.Ball;

        private void Start()
        {
        }

        private void Update()
        {
            string txt;
            float dis = (Mathf.Round(Vector2.Distance(player.transform.position, Vector2.zero)));
            txt = dis.ToString();
            ScoreText.text = txt;
        }

        public void ChangeHealth()
        {
            int count = player.ball.Health;
            for (int i = 3; i > 0; i--)
            {
                if (i <= count) hearths[i].enabled = true;
                else hearths[i].enabled = false;
            }
        }

        public void PauseGame()
        {
            pausePanel.SetActive(true);
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
            UIController.UI.ShowUI<UIMainMenu>();
        }
    }
}