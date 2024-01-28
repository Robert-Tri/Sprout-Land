using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public Item[] itemsToPickUp;
    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            inventoryManager.AddItem(itemsToPickUp[2]);
        }
    }

    public void PickUpItem()
    {
        inventoryManager.AddItem(itemsToPickUp[Random.Range(0,2)]);
    }

}
 