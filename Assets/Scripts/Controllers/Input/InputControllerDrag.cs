using UnityEngine;

namespace Controllers.InputControllers
{
    public class InputControllerDrag : InputControllerBase
    {
        private Vector2 _direct;

        protected override void InputUpdate()
        {
            var curX = ball.transform.position.x;
            var targetX = _touch.position.x;
            if(curX > targetX) _direct = Vector2.left;
            else if(curX < targetX) _direct = Vector2.right;
            ball.Move(_direct);
        }
    }
}