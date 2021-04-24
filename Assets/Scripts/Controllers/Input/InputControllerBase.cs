using System;
using Items.Models;
using UnityEngine;

namespace Controllers.InputControllers
{
    public class InputControllerBase : MonoBehaviour
    {
        protected Touch _touch;
        protected PlayerController ball => GameController.GC.Ball;
        private GameState state => GameController.GC.GameState;

        private void Update()
        {
            if (state == GameState.Play)
            {

                if (Input.touchCount > 0)
                {
                    _touch = Input.GetTouch(0);
                    InputUpdate();
                }

                if (Input.GetKey(KeyCode.A))
                    ball.Move(Vector2.left);
                else if (Input.GetKey(KeyCode.D))
                    ball.Move(Vector2.right);
                else ball.Move(Vector2.zero);
            }
        }

        protected virtual void InputUpdate()
        {
            
        }
    }
}