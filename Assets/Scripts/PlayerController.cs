using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D),typeof(PolygonCollider2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float horizontal;
    private Vector2 dir;
    private float center;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out Rigidbody2D rb);
        if (rb) _rigidbody2D = rb;
        else _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        Screen.resolutions.SetValue(1080, 1920);
        center = Screen.width / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputUpdate();
        MoveUpdate();
    }

    void InputUpdate()
    {
        Touch touch;
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            horizontal = touch.position.x;
        }
        if (horizontal < center) dir = Vector2.left;
        else if(horizontal>center) dir=Vector2.right;
        else dir= Vector2.zero;
    }
    void MoveUpdate()
    {
        _rigidbody2D.velocity =
            Vector2.Lerp(_rigidbody2D.velocity, new Vector2(horizontal, _rigidbody2D.velocity.y), 025f);
        
    }
}
