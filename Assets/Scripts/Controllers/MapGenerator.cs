using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Items.Models;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> Lines = new List<GameObject>();
    public List<int> StartLines = new List<int>();

    public float DistanceBetweenPlatforms;


    public List<GameObject> LastLines = new List<GameObject>();
    GameController GC => GameController.GC;
    private GameState state => GameController.GC.GameState;
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
        var r = Random.Range(0, Lines.Count);
        var obj = Lines[r];
        LastLines.Add(Instantiate(obj, transform.position, Quaternion.identity));
        float dis = Vector2.Distance(transform.position, LastLines[0].transform.position);
        if (dis > 100)
        {
            Destroy(LastLines[0]);
            LastLines.RemoveAt(0);
            GC.Data.AddPlatform(r,LastLines[LastLines.Count-1].transform.position.y);
        }
    }
    void Spawn(Vector2 pos)
    {
        var r = Lines[Random.Range(0, Lines.Count)];
        LastLines.Add(Instantiate(r, pos, Quaternion.identity));
    }

    public void NewGame()
    {
        Clear();
        Vector2 startPos = new Vector2(0,-2);
        var offset = DistanceBetweenPlatforms;
        for (int i = 0; i < StartLines.Count; i++)
        {
            var obj = Lines[StartLines[i]];
            LastLines.Add(Instantiate(obj, startPos, Quaternion.identity));
            GC.Data.AddPlatform(StartLines[i],LastLines[LastLines.Count-1].transform.position.y);
            startPos.y -= offset;
        }
    }

    public void ContinueGame(GameData data)
    {
        Debug.Log("Generator continue");
        Clear();
        Vector2 pos = Vector2.zero;
        foreach (var platformData in data.platforms)
        {
            pos.y = platformData.PositionY;
            var obj = Lines[platformData.ID];
            LastLines.Add(Instantiate(obj, pos, Quaternion.identity));
        }
    }

    public void Clear()
    {
        foreach (var line in LastLines)
        {
            Destroy(line);
        }
        LastLines.Clear();
    }
}
