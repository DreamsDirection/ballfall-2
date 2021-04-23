using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers.PlatformControllers
{
    public class SawScript : MonoBehaviour
    {
        public float speed;
        public float left;
        public float right;
        public float rotateSpeed;
        private Vector2 _direct;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            int d = 0;
            while (d == 0)
            {
                d = Random.Range(-1, 1);
            }

            _direct = new Vector2(d, 0);
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if (transform.position.x <= left) _direct = Vector2.right;
            if (transform.position.x >= right) _direct = Vector2.left;
            var velocity = _direct * speed;
            _rigidbody2D.velocity = velocity * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotateSpeed);

        }
    }
}
