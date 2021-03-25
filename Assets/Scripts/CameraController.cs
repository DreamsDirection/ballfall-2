using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed;

    public float SpeedMultiplier;

    public bool Move = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpeedUp());
    }

    // Update is called once per frame
    void Update()
    {
        if(Move)transform.Translate(Vector2.down * Speed* Time.deltaTime);
    }

    IEnumerator SpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Speed += SpeedMultiplier;
        }
    }
}
