using System;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    
    [CreateAssetMenu(fileName = "SOItem_", menuName = "SO/Item", order = 0)] [Serializable]
    public class SOItem : ScriptableObject
    {
        public int ID;
        public Sprite Image;
        public float Price;


    }
}