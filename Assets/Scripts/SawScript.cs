using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class SawScript : MonoBehaviour
{
    public float Speed;
    public float Left;
    public float Right;
    public float RotateSpeed;
    private Vector2 dir;
    private Rigidbody2D rb;
    private void Start()
    {
        int d = 0;
        while (d == 0)
        {
            d = Random.Range(-1, 1);
        }
        dir = new Vector2(d, 0);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(transform.position.x <= Left) dir = Vector2.right;
        if(transform.position.x >= Right) dir = Vector2.left; 
        rb.velocity = (dir * Speed* Time.deltaTime);
        transform.Rotate(Vector3.forward * RotateSpeed);

    }
}
