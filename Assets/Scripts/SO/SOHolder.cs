using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Holder", menuName = "SO/Holder", order = 0)]
    public class SOHolder : ScriptableObject
    {
        public List<SOItem> items = new List<SOItem>();

        private void OnValidate()
        {
            int id = 0;
            foreach (var item in items)
            {
                item.ID = id;
                id++;
            }
        }
    }
}