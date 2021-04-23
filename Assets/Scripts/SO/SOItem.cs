using System;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    [CreateAssetMenu(fileName = "SOItem_", menuName = "SO/Item", order = 0)]
    public class SOItem : ScriptableObject
    {
        public Sprite Image;
        public float Price;
    }
}