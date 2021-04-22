using System;
using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Items.Models;
using UnityEditor;

namespace Items.Controller
{
    public class ItemsHolder : MonoBehaviour
    {
        [SerializeField]List<SOItem> L_Items = new List<SOItem>();
        // <Уникальный номер, экземпляр класса>
        private Dictionary<int, Item> Items = new Dictionary<int, Item>();
        public int ItemsCount => Items.Count;

        private void Start()
        {
            Init();
        }

        void Init()
        {
            for (int i = 0; i< L_Items.Count; i++)
            {
                Item item = new Item(L_Items[i], i);
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