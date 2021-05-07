using System;
using System.Collections;
using UnityEngine;

namespace Controllers.PlatformControllers
{
    public class PlatformHiden : MonoBehaviour
    {

        public float HideTime;
        IEnumerator Hide(float time)
        {
            yield return new WaitForSeconds(time);
            DestroyImmediate(gameObject);
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                StartCoroutine(Hide(HideTime));
            }
        }
    }
    
    
}