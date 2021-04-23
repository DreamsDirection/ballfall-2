using UnityEngine;

namespace Controllers.UI
{
    public class UIMainMenu : MonoBehaviour
    {
        private UIController ui => UIController.UI;
        GameController gc => GameController.GC;
        public void Play()
        {
            gc.StartGame();
            ui.ShowUI<UIGame>();
        }

        public void Settings()
        {
            ui.ShowUI<UISettings>();
        }

        public void Shop()
        {
            ui.ShowUI<UIShop>();
        }

        public void Info()
        {
        }

        public void Exit()
        {
            
        }
    }
}