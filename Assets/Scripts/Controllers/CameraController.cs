using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{


    public class CameraController : MonoBehaviour
    {
        public float Speed;

        public float SpeedMultiplier;

        public bool Move = false;

        GameController GC => GameController.GC;
        private GameState state => GC.GameState;

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        public void Init(float PositionY = 0)
        {
            StopAllCoroutines();
            Speed = GC.CameraStartSpeed;
            SpeedMultiplier = GC.CameraSpeedMultiplier;
            StartCoroutine(SpeedUp());
            transform.position = new Vector3(0, PositionY, -10);
        }

        // Update is called once per frame
        void Update()
        {
            if (state == GameState.Play)
                transform.Translate(Vector2.down * Speed * Time.deltaTime);
        }

        IEnumerator SpeedUp()
        {
            while (Speed < GC.CameraMaxSpeed)
            {
                yield return new WaitForSeconds(1);
                Speed += SpeedMultiplier;
            }
        }

        public void ResetSpeed()
        {
            Speed -= Speed * 0.2f;
            if (Speed < GC.CameraStartSpeed) Speed = GC.CameraStartSpeed;
        }
    }
}
