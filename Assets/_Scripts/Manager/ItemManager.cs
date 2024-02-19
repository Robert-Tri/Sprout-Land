using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Models {
    public class ItemManager : MonoBehaviour
    {
        public List<GameObjectData> itemList;
        private static ItemManager instance;

        public static ItemManager Instance { get => instance; set => instance = value; }

        private void Start()
        {
            instance = this;
        }
        public List<GameObjectData> GetSeedItems()
        {
            List<GameObjectData> seedItems = new List<GameObjectData>();

            foreach (GameObjectData item in itemList)
            {
                if (item.item.variety == Variety.Seed)
                {
                    seedItems.Add(item);
                }
            }

            return seedItems;
        }

        internal List<GameObjectData> GetSeedItemsInInventory()
        {
            return GetSeedItems(InventoryManager.Instance.GetItems());
        }

        private List<GameObjectData> GetSeedItems(List<GameObjectData> items)
        {
            List<GameObjectData> seedItems = new List<GameObjectData>();
            foreach (GameObjectData item in items)
            {
                if (item.item.variety == Variety.Seed)
                {
                    seedItems.Add(item);
                }
            }
            return seedItems;
        }
    } 
}
