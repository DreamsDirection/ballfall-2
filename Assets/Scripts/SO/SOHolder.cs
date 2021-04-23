using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Holder", menuName = "SO/Holder", order = 0)]
    public class SOHolder : ScriptableObject
    {
        public SOItem[] Items;
    }
}