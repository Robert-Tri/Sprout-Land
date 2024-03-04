using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._Scripts.Models
{
    public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("UI")]
        public Image image;
        public Text countText;
        [HideInInspector] public GameObjectData item;
        [HideInInspector] public int count = 1;
        [HideInInspector] public Transform parentAfterDrag;
        public GameObject popupPrefab;
        private GameObject popupInstance;
        private void Start()
        {
            Vector3 newPosition = transform.position + Vector3.right * 1.5f;
            popupInstance = Instantiate(popupPrefab, newPosition, Quaternion.identity, transform);
            popupInstance.SetActive(false);
        }

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

        public void OnPointerEnter(PointerEventData eventData)
        {
            popupInstance.GetComponent<ItemPopup>().ShowPopup(item.item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            popupInstance.GetComponent<ItemPopup>().HidePopup();
        }

        public void InitialiseItem(GameObjectData item)
        {
            this.item = item;
            image.sprite = item.item.icon;
            RefreshCount();
        }
    }
}

