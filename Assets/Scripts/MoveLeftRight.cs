using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class   MoveLeftRight : MonoBehaviour
{
    public float Speed;
    public float Left;
    public float Right;
    private Vector2 dir = Vector2.left;
    void FixedUpdate()
    {
        if(transform.position.x <= Left) dir = Vector2.right;
        if(transform.position.x >= Right) dir = Vector2.left; 
        transform.Translate(dir * Speed* Time.deltaTime);

    }
}
