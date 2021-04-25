using System;
using System.Collections.Generic;
using Controllers;
using Items;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Items.Models;
using UnityEditor;

namespace Items.Controller
{
    [Serializable]
    public class ItemsHolder
    {
        // <Уникальный номер, экземпляр класса>
        public Dictionary<int, Item> Items = new Dictionary<int, Item>();
        private SOHolder _holder;
        public int ItemsCount => Items.Count;

        public void Init()
        {
            foreach (var item in _holder.items)
            {
                Item i = new Item() {ID = item.ID, IsBuy = false};
                Items.Add(item.ID,i);
            }
        }


        public SOItem GetItem(int id)
        {
            try
            {
                foreach (var item in _holder.items)
                {
                    if (item.ID == id) return item;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        
        public void Save()
        {
            PersistentCache.Save(Items);
            GameController.GC.Save();
        }

        void Load()
        {
            Dictionary<int, Item> _items = PersistentCache.TryLoad<Dictionary<int, Item>>();
            if(_items == null) return;
            foreach (var item in _items)
            {
                try
                {
                    Items[item.Key].IsBuy = item.Value.IsBuy;
                    Items[item.Key].IsSelected = item.Value.IsSelected;
                }
                catch (KeyNotFoundException)
                {
                    Item _item = new Item() {ID = item.Key, IsBuy = item.Value.IsBuy,IsSelected = item.Value.IsSelected};
                    Items.Add(item.Key,_item);
                }
                catch (Exception ex)
                {
                    Debug.LogWarning(ex);
                }
            }
        }
        public ItemsHolder(SOHolder soHolder)
        {
            _holder = soHolder;
            Init();
            Load();
            Save();
        }
    }
}