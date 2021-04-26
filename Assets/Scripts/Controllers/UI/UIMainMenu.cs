using System;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class UIMainMenu : UIBase
    {


        public Button PlayButton;
        public Text PlayButtonText;
        
        public override void Open()
        {
            
        }

        public override void Close()
        {
            
        }
        

        public void Settings()
        {
            UI.ShowUI<UISettings>();
        }

        public void Shop()
        {
            UI.ShowUI<UIShop>();
        }

        public void Info()
        {
        }

        public void Exit()
        {
            
        }

        private void OnEnable()
        {
            try
            {
                if (GC.Data.InGame)
                {
                    PlayButtonText.text = "Продолжить";
                    PlayButton.onClick.RemoveAllListeners();
                    PlayButton.onClick.AddListener(()=> GC.ContinueGame());
                }
                else
                {
                    PlayButtonText.text = "Новая игра";
                    PlayButton.onClick.RemoveAllListeners();
                    PlayButton.onClick.AddListener(()=> GC.StartGame());
                }
            }
            catch (Exception e)
            {
                PlayButtonText.text = "Новая игра";
                PlayButton.onClick.RemoveAllListeners();
                PlayButton.onClick.AddListener(()=> GC.StartGame());
            }
            
        }
    }
}