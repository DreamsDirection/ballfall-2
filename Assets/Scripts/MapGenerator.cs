using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> Lines = new List<GameObject>();

    public float DistanceBetweenPlatforms;


    private GameObject lastLine;
    void Start()
    {
       lastLine = Instantiate(Lines[0], transform.position, Quaternion.identity); 
    }

    void Update()
    {
        float dis = Vector2.Distance(transform.position, lastLine.transform.position);
        if (dis > DistanceBetweenPlatforms)
            Spawn();
    }


    void Spawn()
    {
        var r = Lines[Random.Range(0, Lines.Count)];
        lastLine = Instantiate(r, transform.position, Quaternion.identity);
        Destroy(lastLine,20f);
    }
}
