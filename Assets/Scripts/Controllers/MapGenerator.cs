using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> Lines = new List<GameObject>();

    public float DistanceBetweenPlatforms;


    private List<GameObject> LastLines = new List<GameObject>();
    void Start()
    {
    }

    void Update()
    {
        if (LastLines.Count > 0)
        {
            float dis = Vector2.Distance(transform.position, LastLines[LastLines.Count - 1].transform.position);
            if (dis > DistanceBetweenPlatforms)
                Spawn();
        }
    }


    void Spawn()
    {
        var r = Lines[Random.Range(0, Lines.Count)];
        LastLines.Add(Instantiate(r, transform.position, Quaternion.identity));
        float dis = Vector2.Distance(transform.position, LastLines[0].transform.position);
        if (dis > 100)
        {
            Destroy(LastLines[0]);
            LastLines.RemoveAt(0);
        }
    }
    void Spawn(Vector2 pos)
    {
        var r = Lines[Random.Range(0, Lines.Count)];
        LastLines.Add(Instantiate(r, pos, Quaternion.identity));
    }

    public void NewGame()
    {
        Vector2 startPos = new Vector2(0,-5);
        var offset = DistanceBetweenPlatforms;
        foreach (var line in LastLines)
        {
            Destroy(line);
        }
        LastLines.Clear();
        for (int i = 0; i < 3; i++)
        {
            Spawn(startPos);
            startPos.y -= offset;
        }
    }
}
