using UnityEngine;

namespace Controllers.UI
{
    public class UIMainMenu : UIBase
    {
        
        
        
        
        public override void Open()
        {
            
        }

        public override void Close()
        {
            
        }
        
        
        public void Play()
        {
            GC.StartGame();
            UI.ShowUI<UIGame>();
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
    }
}