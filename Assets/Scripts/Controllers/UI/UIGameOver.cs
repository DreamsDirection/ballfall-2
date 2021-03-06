using System;
using Controllers;
using Controllers.UI;
using Items.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{


    public class UIGameOver : UIBase
    {
        public GameObject NewBallPanel;
        public Text Text;
        public Text Text_BestScore;

        public override void Open()
        {
            UIShop shop = UI.GetUI<UIShop>();
            if (shop.CanBuy())
                NewBallPanel.SetActive(true);
            else
                NewBallPanel.SetActive(false);

            Text.text = "Счет: " + GC.Data.GameScore.ToString();
            Text_BestScore.text = "Лучший счет: " + GC.Data.BestScore.ToString();
        }

        public override void Close()
        {
            
        }
        public void Show()
        {
            
        }

        public void ShowShop()
        {
            GC.GameOver();
            UI.ShowUI<UIShop>();
        }

        public void Return()
        {
            GC.GameOver();
            UI.ShowUI<UIMainMenu>();
        }

        public void Restart()
        {
            GC.GameOver();
            GC.StartGame();
        }

        public void ContinueAD()
        {

        }
    }
}
