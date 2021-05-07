using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers.PlatformControllers
{
    public class PlatformBomb : MonoBehaviour
    {
        public float ExplosionTime;

        private PlayerController Ball;
        IEnumerator Hide(float time)
        {
            yield return new WaitForSeconds(time);
            DestroyImmediate(gameObject);
            if(Ball) Ball.MakeDamage();
            
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                StartCoroutine(Hide(ExplosionTime));
                other.gameObject.TryGetComponent(out PlayerController ball);
                Ball = ball;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
                Ball = null;
        }
    }
}