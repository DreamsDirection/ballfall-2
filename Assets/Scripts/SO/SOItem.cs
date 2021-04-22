using System;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    [CreateAssetMenu(menuName = "SO/Item",fileName = "SOItem_")]
    public class SOItem : ScriptableObject
    {
        public Sprite Image;
        public float Price;
    }
}