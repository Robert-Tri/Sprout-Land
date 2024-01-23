using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject droppedItem = eventData.pointerDrag;
            DragableItem dragableItem = droppedItem.GetComponent<DragableItem>();
            dragableItem.parentAfterDrag = transform;
        }
    }
}
