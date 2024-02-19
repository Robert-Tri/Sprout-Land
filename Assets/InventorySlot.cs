using Assets._Scripts.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Image outlineImage;
    [HideInInspector] public Color outlineColor = Color.white;
    [HideInInspector] public float outlineWidth = 5f;
    public float newWidth = 5f;
    public float newHeight = 5f;
    //public Color selectedColor, noSelectedColor;

    private void Awake()
    {
        DeSelected();
    }

    public void Selected()
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(1.1f, 1.1f, 1f);
    }

    public void DeSelected()
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }

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
