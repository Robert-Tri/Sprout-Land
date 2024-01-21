using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        DragableItem dragableItem = droppedItem.GetComponent<DragableItem>();
        dragableItem.parentAfterDrag = transform;
    }
}
