using UnityEngine;
using UnityEngine.XR;

namespace Controllers.UI
{
    public class UIBase : MonoBehaviour
    {
        protected GameController GC => GameController.GC;
        protected UIController UI => UIController.UI;
        private GameState GameState => GC.GameState;

        public virtual void Open()
        {
            
        }

        public virtual void Close()
        {
            
        }
    }
}