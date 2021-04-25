using System;
using UnityEngine;
using UnityEngine.UI;

namespace Items.Models
{
    [Serializable]
    public class Item
    {
        public float ID;
        public bool IsBuy = false;
        public bool IsSelected;
    }
}