using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D),typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    public int Health;
    public bool Shield;
    public bool IsDebug = false;
    float Speed => GC.BallSpeed;
    private float gravity => GC.BallGravity;
    private Rigidbody2D _rigidbody2D;
    private Vector2 dir;
    private float center;
    
    
    
    GameController GC=> GameController.GC;
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        TryGetComponent(out Rigidbody2D rb);
        if (rb) _rigidbody2D = rb;
        else _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        Screen.SetResolution(1080,1920,FullScreenMode.FullScreenWindow);
        center = Screen.width / 2;
        Health = 3;
        rb.gravityScale = gravity;
        GC.UI.ChangeHealth(Health);
    }

    private float t = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsDebug) InputUpdate2();
        else InputUpdate();
        MoveUpdate();
        t -= Time.deltaTime;
    }

    void InputUpdate()
    {
        Touch touch;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            var horizontal = touch.position.x;


            if (horizontal < center) dir = Vector2.left;
            else if (horizontal > center) dir = Vector2.right;
        }
        else dir= Vector2.zero;
    }

    void InputUpdate2()
    {
        if (Input.GetMouseButton(0))
        {
            var horizontal = Input.mousePosition.x;
            if (horizontal < center) dir = Vector2.left;
            else if (horizontal > center) dir = Vector2.right;
        }
        else dir= Vector2.zero;

        if (Input.GetKey(KeyCode.A)) dir = Vector2.left;
        if ( Input.GetKey(KeyCode.D)) dir = Vector2.right;
    }

    
    void MoveUpdate()
    {
        _rigidbody2D.velocity =
            Vector2.Lerp(_rigidbody2D.velocity, new Vector2(dir.x*Speed, _rigidbody2D.velocity.y), 0.5f);
        GC.Score = Vector2.Distance(Vector2.zero, transform.position);
            
    }

    public void MakeDamage()
    {
        if (!Shield && t <= 0)
        {
            Health--;
            if (Health <= 0)
                GC.GameOver();
                else
                GC.UI.ChangeHealth(Health);

            t = 1;
        }
        else Shield = false;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision enrer");
        switch (other.collider.tag)
        {
            case "Spike":
            {
            GC.GameOver();
                break;
            }
            case "Spike_2":
            {
                MakeDamage();
                break;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Spike_2":
            {
                MakeDamage();
                break;
            }
            case "Hearth":
            {
                Health++;
                GC.UI.ChangeHealth(Health);
                Destroy(other.gameObject);
                if (Health >= 3) Health = 3;
                break;
            }
            case "Shield":
            {
                Destroy(other.gameObject);
                Shield = true;
                break;
            }
        }
    }
}
