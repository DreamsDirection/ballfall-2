using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.PlatformControllers
{
    public class MoveLeftRight : MonoBehaviour
    {
        public float speed;
        public float left;
        public float right;
        private Vector2 _direct = Vector2.left;

        void FixedUpdate()
        {
            if (transform.position.x <= left) _direct = Vector2.right;
            if (transform.position.x >= right) _direct = Vector2.left;
            var dir = _direct * speed;
            transform.Translate(dir * Time.deltaTime);

        }
    }
}
