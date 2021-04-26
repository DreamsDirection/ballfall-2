using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items.Models
{
    [Serializable]
    public class GameData
    {
        public float Money;
        public float GameScore;
        public float BestScore;
        public bool InGame = false;

        public float BallPositionX;
        public float BallPositionY;

        public float CameraPositionY;
        public float CamSpeed;
        public int InputType;

        public List<PlatformData> platforms;

        public void AddPlatform(int id,float positionY)
        {
            if (platforms == null)
            {
                platforms = new List<PlatformData>();
                Debug.Log("Platforms dont loaded");
            }
            PlatformData data = new PlatformData() {ID = id, PositionY = positionY};
            platforms.Add(data);
            if (platforms.Count > 10) platforms.RemoveAt(0);
        }

    }


[Serializable]
    public class PlatformData
    {
        public int ID;
        
        public float PositionY;
    }
}