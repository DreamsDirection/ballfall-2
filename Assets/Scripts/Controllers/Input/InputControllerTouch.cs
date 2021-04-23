using System;
using UnityEngine;

namespace Controllers.InputControllers
{
    public class InputControllerTouch : InputControllerBase
    {
        private Vector3 _direct;
        private float ScreenCenter;

        private void Start()
        {
            ScreenCenter = Screen.width / 2;
        }

        protected override void InputUpdate()
        {
            if (_touch.position.x < ScreenCenter) _direct = Vector2.left;
            else if (_touch.position.x > ScreenCenter) _direct = Vector2.right;
            ball.Move(_direct);
        }
    }
}