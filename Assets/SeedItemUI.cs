using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._Scripts.Models
{
    public class SeedItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image iconImage;
        public Text priceText;
        public Button buyButton;
        public GameObject popupPrefab;

        private GameObject popupInstance;

        private GameObjectData item;
        private void Start()
        {
            popupInstance = Instantiate(popupPrefab, transform);
            popupInstance.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            popupInstance.GetComponent<ItemPopup>().ShowPopup(item.item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            popupInstance.GetComponent<ItemPopup>().HidePopup();
        }

        public void Setup(GameObjectData itemData)
        {
            item = itemData;
            iconImage.sprite = item.item.icon;
            priceText.text = item.item.buyPrice.ToString();
            buyButton.onClick.AddListener(BuyButtonClicked);
        }

        private void BuyButtonClicked()
        {
            PurchasePopup.Instance.purchasePopup.SetActive(true);
            PurchasePopup.Instance.SetAttributeToBuy(item, ResourceManager.Instance.FindResourceByName("Gold").Quantity);
        }
    }
}
