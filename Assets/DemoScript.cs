using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public Item[] itemsToPickUp;

    public void PickUpItem()
    {
        inventoryManager.AddItem(itemsToPickUp[Random.Range(0,2)]);
    }

}
 