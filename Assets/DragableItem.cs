using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._Scripts.Models
{
    public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Header("UI")]
        public Image image;
        public Text countText;
        [HideInInspector] public GameObjectData item;
        [HideInInspector] public int count = 1;
        [HideInInspector] public Transform parentAfterDrag;

        public void OnBeginDrag(PointerEventData eventData)
        { 
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            image.raycastTarget = false;
        }

        public void RefreshCount()
        {
            countText.text = count.ToString();
            bool textActive = count > 1;
            countText.gameObject.SetActive(textActive);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(parentAfterDrag);
            image.raycastTarget = true;
        }

        public void InitialiseItem(GameObjectData item)
        {
            this.item = item;
            image.sprite = item.item.icon;
            RefreshCount();
        }
    }
}

