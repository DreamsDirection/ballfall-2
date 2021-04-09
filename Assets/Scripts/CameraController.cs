using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed;

    public float SpeedMultiplier;

    public bool Move = false;
    GameController GC => GameController.GC;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public void Init()
    {
        StopAllCoroutines();
        Speed = GC.CameraStartSpeed;
        SpeedMultiplier = GC.CameraSpeedMultiplier;
        StartCoroutine(SpeedUp());
    }

    // Update is called once per frame
    void Update()
    {
        if(Move)transform.Translate(Vector2.down * Speed* Time.deltaTime);
    }

    IEnumerator SpeedUp()
    {
        while (Speed < GC.CameraMaxSpeed)
        {
            yield return new WaitForSeconds(1);
            Speed += SpeedMultiplier;
        }
    }
}
