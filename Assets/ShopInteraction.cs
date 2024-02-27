using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets._Scripts.Models
{
    public class ShopInteraction : MonoBehaviour
    {
        private bool isPlayerInRange = false;
        private TextMesh interactText;
        private GameObject textObject;
        public string textInteraction;
        protected TextAsset textJson;
        protected bool isFirstMeeting = true;
        public GameObject dialogue;
        public GameObject shop;
        private List<GameObjectData> items;
        public GameObject seedItemPrefab;
        public GameObject sellItemPrefab;
        public Transform contentPanel;
        private static ShopInteraction instance;
        public static ShopInteraction Instance { get => instance; set => instance = value; }

        private void Start()
        {
            instance = this;
            this.items = new List<GameObjectData>();
            textObject = InteractManager.Instance.textObject;
            interactText = InteractManager.Instance.interactText;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = true;
                interactText.text = textInteraction;
                interactText.gameObject.SetActive(true);
                textObject.transform.SetParent(transform);
                textObject.transform.localPosition = new Vector3(0f, 1f, 0f);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = false;
                interactText.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (isPlayerInRange)
            {
                if (Input.GetKeyDown(KeyCode.E) && !dialogue.activeSelf)
                {
                    if (isFirstMeeting)
                    {
                        textJson = JsonLoader.GetJsonFile("ShopOwner_First_Meeting");
                        isFirstMeeting = false;
                    }
                    else
                    {
                        textJson = JsonLoader.GetJsonFile("ShopOwner_Default_Meeting");
                    }
                    Dialogue.Instance.ShowDialogue();
                    Dialogue.Instance.SetDialogueJson(textJson);
                }
            }
            if ((Dialogue.Instance.NodeName.Equals("buyNode") || Dialogue.Instance.NodeName.Equals("sellNode")) && !dialogue.activeSelf)
            {
                shop.SetActive(true);
                PurchasePopup.Instance.purchasePopup.SetActive(false);
                if (Dialogue.Instance.NodeName.Equals("buyNode"))
                {
                    RefreshListItem();
                    RefreshItemInShop();
                    items = ItemManager.Instance.GetSeedItems();
                    foreach (GameObjectData item in items)
                    {
                        GameObject newItem = Instantiate(seedItemPrefab, contentPanel);
                        SeedItemUI seedItemUI = newItem.GetComponent<SeedItemUI>();
                        seedItemUI.Setup(item);
                    }
                }
                else if (Dialogue.Instance.NodeName.Equals("sellNode"))
                {
                    RefreshListItem();
                    items = ItemManager.Instance.GetSeedItemsInInventory();
                    SetItemFromInventoryIntoShop(items);
                }
                Dialogue.Instance.NodeName = "";
            }
        }
        private void RefreshItemInShop()
        {
            foreach (Transform child in contentPanel)
            {
                Destroy(child.gameObject);
            }
        }

        public void SetItemFromInventoryIntoShop(List<GameObjectData> items)
        {
            RefreshItemInShop();
            foreach (GameObjectData item in items)
            {
                GameObject newItem = Instantiate(sellItemPrefab, contentPanel);
                SellSeedItemUI sellSeedItemUI = newItem.GetComponent<SellSeedItemUI>();
                sellSeedItemUI.Setup(item);
            }
        }

        public void RefreshListItem()
        {
            items.Clear();
        }
    }
}

