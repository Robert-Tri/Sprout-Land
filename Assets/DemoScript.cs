using UnityEngine;

namespace Assets._Scripts.Models
{
    public class DemoScript : MonoBehaviour
    {
        public InventoryManager inventoryManager;

        public GameObjectData[] itemsToPickUp;
        private void Start()
        {
        }

        public void PickUpItem()
        {
            inventoryManager.AddItem(itemsToPickUp[Random.Range(0, 2)]);
        }

    }
}
 