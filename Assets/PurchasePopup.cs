using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets._Scripts.Models;

public class PurchasePopup : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private static PurchasePopup instance;
    public Text priceText;
    public InputField quantityInputField;
    public Button button;
    public GameObject purchasePopup;
    private int playerGold;
    private int price;
    private GameObjectData item;
    private bool isSelling = false;
    private bool isBuying = false;
    public static PurchasePopup Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
    }

    public void BuyItem()
    {
        int quantity = int.Parse(quantityInputField.text);
        if ( ResourceManager.Instance.SpendGold(price * quantity))
        {
            for (int i = 1; i <= quantity; i++) inventoryManager.AddItem(item);
            purchasePopup.SetActive(false);
        }
    }

    public void SellItem()
    {
        int quantity = int.Parse(quantityInputField.text);
        inventoryManager.RemoveItem(item, quantity);
        ShopInteraction.Instance.RefreshListItem();
        ShopInteraction.Instance.SetItemFromInventoryIntoShop(ItemManager.Instance.GetSeedItemsInInventory());
        ResourceManager.Instance.AddGold(price * quantity);
        purchasePopup.SetActive(false);
    }

    public void ShowGoldToBuyWithThisQuantity(string value)
    {
        if (isBuying)
        {
            if (quantityInputField.text.Equals(""))
            {
                quantityInputField.text = "1";
            }
            this.priceText.text = (price * int.Parse(quantityInputField.text)).ToString();
            if (playerGold < int.Parse(priceText.text))
            {
                priceText.color = Color.red;
            }
            else { priceText.color = Color.white;}
        }
        else if (isSelling)
        {
            if (quantityInputField.text.Equals(""))
            {
                quantityInputField.text = "1";
            }
            if (item.amount < int.Parse(quantityInputField.text)) quantityInputField.text = item.amount.ToString();
            this.priceText.text = (price * int.Parse(quantityInputField.text)).ToString();
        }

    }

    public void SetAttributeToBuy(GameObjectData item, int playerGold)
    {
        isBuying = true;
        this.item = item;
        this.priceText.text = item.item.buyPrice.ToString();
        price = item.item.buyPrice;
        this.playerGold = playerGold;
        button.GetComponentInChildren<Text>().text = "Buy";
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(BuyItem);
    }

    public void SetAttributeToSell(GameObjectData item, int playerGold)
    {
        isSelling = true;
        this.item = item;
        this.priceText.text = item.item.sellPrice.ToString();
        this.quantityInputField.text = "1";
        price = item.item.sellPrice;
        this.playerGold = playerGold;
        button.GetComponentInChildren<Text>().text = "Sell";
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(SellItem);
    }
}
