using System;
using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Items.Models;
using UnityEditor;

namespace Items.Controller
{
    public class ItemsHolder
    {
        private SOItem[] items;
        // <Уникальный номер, экземпляр класса>
        private Dictionary<int, Item> Items = new Dictionary<int, Item>();
        public int ItemsCount => Items.Count;

        public void Init(SOItem[] list)
        {
            Debug.Log("Init");
            items = list;
            
            for (int i = 0; i< items.Length; i++)
            {
                Debug.Log(items[i].name);
                Item item = new Item(items[i], i);
                Items.Add(i,item);
            }
        }

        public Item GetItem(int id)
        {
            try
            {
                Item item = Items[id];
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}