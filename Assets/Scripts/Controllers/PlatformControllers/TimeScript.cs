using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Controllers.PlatformControllers
{
    public class TimeScript : MonoBehaviour
    {
        public float times;

        public bool isDamage;
        private PlayerController _player;

        IEnumerator StartTime()
        {
            yield return new WaitForSeconds(times);
            if (isDamage && _player) _player.MakeDamage();
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _player = other.gameObject.GetComponent<PlayerController>();
                StartCoroutine(StartTime());
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _player = null;
            }
        }
    }
}
