using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.Models
{
    public class ItemPopup : MonoBehaviour
    {
        public Text itemNameText;
        public Text typeText;
        public Text descriptionText;
        public Text priceBuyText;
        public Text priceSellText;

        public void ShowPopup(Item item)
        {
            itemNameText.text = item.itemName;
            typeText.text = item.variety.ToString();
            descriptionText.text = item.description;
            priceBuyText.text = item.buyPrice.ToString();
            priceSellText.text = item.sellPrice.ToString();

            gameObject.SetActive(true);
        }

        public void HidePopup()
        {
            gameObject.SetActive(false);
        }
    }
}


