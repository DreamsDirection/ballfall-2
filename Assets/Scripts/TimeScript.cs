using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class TimeScript : MonoBehaviour
{
    public float Times;

    public bool IsDamage;
    private PlayerController player;

    IEnumerator StartTime()
    {
        yield return new WaitForSeconds(Times);
        if (IsDamage && player) player.MakeDamage(); 
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerController>();
            StartCoroutine(StartTime());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }
}
