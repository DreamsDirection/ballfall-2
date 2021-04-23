using System;
using Controllers;
using Controllers.UI;
using Items.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{


    public class UIGameOver : MonoBehaviour
    {
        public GameObject NewBallPanel;
        public Text Text;
        GameController GC => GameController.GC;
        private UIController UI => UIController.UI;

        public void Show()
        {
            UIShop shop = UI.GetUI<UIShop>() as UIShop;
            if (shop.CanBuy())
                NewBallPanel.SetActive(true);
            else
                NewBallPanel.SetActive(false);

            Text.text = "Счет: " + GC.GameScore.ToString();
        }

        public void ShowShop()
        {
            UI.ShowUI<UIShop>();
        }

        public void Return()
        {
            UIController.UI.ShowUI<UIMainMenu>();
        }

        public void Restart()
        {
            UIController.UI.ShowUI<UIGame>();
            GameController.GC.StartGame();
        }

        public void ContinueAD()
        {

        }
    }
}
