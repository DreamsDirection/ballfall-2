using System;
using UnityEngine;

namespace Controllers.InputControllers
{
    public class InputControllerDrag : InputControllerBase
    {
        private Vector2 _direct;
        private Camera cam;

        private void Start()
        {
            cam = Camera.main;
            InputType = 2;
        }

        protected override void InputUpdate()
        {
            var curX = cam.WorldToScreenPoint(ball.transform.position).x;
            var targetX = _touch.position.x;
            if(curX > targetX) _direct = Vector2.left;
            else if(curX < targetX) _direct = Vector2.right;
            else _direct = Vector2.zero;
            ball.Move(_direct);
        }
    }
}