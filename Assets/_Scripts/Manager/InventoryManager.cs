using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets._Scripts.Models
{
    public class InventoryManager : MonoBehaviour
    {
        public InventorySlot[] inventorySlots;
        public GameObject inventoryItemPrefab;
        private static InventoryManager instance;
        private List<GameObjectData> items = new List<GameObjectData>();
        int selectedSlot = -1;
        public GameObjectData selectedItem;

        public static InventoryManager Instance { get => instance; set => instance = value; }

        private void Start()
        {
            instance = this;
            ChangeSelectedSlot(0);
        }
        private void Update()
        {
            if(Input.inputString != null)
            {
                bool isNumber = int.TryParse(Input.inputString, out int number);
                if(isNumber && number > 0 && number  <= 9)
                {
                    ChangeSelectedSlot(number - 1);
                }
            }
        }

        void ChangeSelectedSlot(int newValue)
        {
            if(selectedSlot >= 0)
            {
                inventorySlots[selectedSlot].DeSelected();
            }
            inventorySlots[newValue].Selected();
            DragableItem inventoryItem = inventorySlots[newValue].GetComponentInChildren<DragableItem>();
            if (inventoryItem != null)
            {
                selectedItem = inventoryItem.item;
            } else
            {
                selectedItem = null;
            }
            selectedSlot = newValue;
        }

        public void AddItem(GameObjectData itemData)
        {
            GameObjectData gameObjectData = Instantiate(itemData);
            foreach (var slot in inventorySlots)
            {
                DragableItem inventoryItem = slot.GetComponentInChildren<DragableItem>();
                if (inventoryItem != null && (inventoryItem.item.item.ID == gameObjectData.item.ID) && (inventoryItem.item.item.isStackable == true) && (inventoryItem.item.amount < inventoryItem.item.item.maxStackNumber))
                {
                    inventoryItem.count ++;
                    inventoryItem.RefreshCount();
                    inventoryItem.item.amount ++;
                    GameObjectData item = items.FirstOrDefault(item => item.item.ID == inventoryItem.item.item.ID);
                    Destroy(gameObjectData.gameObject);
                    return;
                }
            }

            foreach (var slot in inventorySlots)
            {
                DragableItem inventoryItem = slot.GetComponentInChildren<DragableItem>();
                if (inventoryItem == null)
                {
                    SpawnItem(gameObjectData, slot);
                    return;
                }
            }
            RefreshInventory();
        }

        public void SpawnItem(GameObjectData item, InventorySlot slot)
        {
            GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
            DragableItem inventoryItem = newItem.GetComponent<DragableItem>();
            inventoryItem.InitialiseItem(item);
            items.Add(item);
        }

        public List<GameObjectData> GetItems()
        {
            return items;
        }

        public void RemoveItem(GameObjectData targetItem, int quantity)
        {
            GameObjectData itemToRemove = items.FirstOrDefault(item => item.item.ID == targetItem.item.ID & item.amount == targetItem.amount);
            if (targetItem.amount == quantity)
            {
                items.Remove(itemToRemove);
                Destroy(targetItem.gameObject);
            }
            else
            {
                if (itemToRemove != null)
                {
                    itemToRemove.amount -= quantity;
                }
            }
            RefreshInventory();
        }

        private void RefreshInventory()
        {
            foreach (var slot in inventorySlots)
            {
                if (slot.GetComponentInChildren<DragableItem>() != null)
                    DestroyImmediate(slot.GetComponentInChildren<DragableItem>().gameObject);
            }

            foreach (var item in items)
            {
                foreach (var slot in inventorySlots)
                {
                    if (slot.GetComponentInChildren<DragableItem>() == null)
                    {
                        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
                        DragableItem inventoryItem = newItem.GetComponent<DragableItem>();
                        inventoryItem.count = item.amount;
                        inventoryItem.InitialiseItem(item);
                        break;
                    }
                }
            }
        }
    }
}

