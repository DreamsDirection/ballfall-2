using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers.PlatformControllers
{
    public class PlatformLeftRight : MonoBehaviour
    {
        public float Left;
        public float Right;
        public float MoveSpeed;
        private Rigidbody2D Rigidbody2D;
        private Vector2 Direct;

        private void Start()
        {
            Rigidbody2D = TryGetComponent(out Rigidbody2D rv) ? rv : gameObject.AddComponent<Rigidbody2D>();
            int i = Random.Range(0, 1);
            if (i == 0) Direct = Vector2.left;
            else Direct = Vector2.right;

        }

        private void Update()
        {
            if (Rigidbody2D)
            {
                if( transform.position.x <= Left) Direct = Vector2.right;
                if(transform.position.x >= Right) Direct = Vector2.left;
                var dir = Vector2.Lerp(Rigidbody2D.velocity, Direct * MoveSpeed, 0.1f);
                Rigidbody2D.velocity = dir;
            }
        }
    }
}