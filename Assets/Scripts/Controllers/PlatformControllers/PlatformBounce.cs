using System;
using UnityEngine;

namespace Controllers.PlatformControllers
{
    public class PlatformBounce : MonoBehaviour
    {
        public float Force;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.collider.attachedRigidbody)
                other.collider.attachedRigidbody.AddForce(Vector2.up * Force);
        }
    }
}