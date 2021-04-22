using System;
using UnityEngine;
using UnityEngine.UI;

namespace Items.Models
{
    [Serializable]
    public class Item
    {
        public float ID { get; private set; }
        public float Price { get; private set; }
        public Sprite image { get; private set; }
        public bool IsBuy = false;
        private SOItem SoItem;


        public Item(SOItem obj,int _id)
        {
            SoItem = obj;
            ID = _id;
            Price = SoItem.Price;
            image = SoItem.Image;
        }
        
    }
}