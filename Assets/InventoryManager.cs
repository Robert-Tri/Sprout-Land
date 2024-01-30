using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static int maxItem = 4;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    private void Start()
    {
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
        selectedSlot = newValue;
    }

    public void AddItem(Item item)
    {

        foreach (var slot in inventorySlots)
        {
            DragableItem inventoryItem = slot.GetComponentInChildren<DragableItem>();
            if (inventoryItem != null && inventoryItem.item == item && inventoryItem.count <= maxItem && inventoryItem.item.stackable == true)
            {
                inventoryItem.count++;
                inventoryItem.RefreshCount();
                return;
            }
        }

        foreach (var slot in inventorySlots)
        {
            DragableItem inventoryItem = slot.GetComponentInChildren<DragableItem>();
            if (inventoryItem == null)
            {
                SpawnItem(item, slot);
                return;
            }
        }
    }

    public void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        DragableItem inventoryItem = newItem.GetComponent<DragableItem>();
        inventoryItem.InitialiseItem(item);
    }
}
