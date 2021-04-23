using System;
using Items.Models;
using UnityEngine;

namespace Controllers.InputControllers
{
    public class InputControllerBase : MonoBehaviour
    {
        protected Touch _touch;
        protected PlayerController ball => GameController.GC.Ball;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                InputUpdate();
            }
        }

        protected virtual void InputUpdate()
        {
            
        }
    }
}