using System;
using UnityEngine;

namespace Code.Inventory
{
    public class ItemManager : MonoBehaviour
    {
        public Item[] items;
        public static ItemManager Instance;
        private void Awake()
        {
            Instance = this;
        }
    }
}
