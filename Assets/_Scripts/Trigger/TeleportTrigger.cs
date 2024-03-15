using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTrigger : MonoBehaviour
{
    public string teleportLocation;
    public Vector3 teleportPos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventoryManager.Instance != null) InventoryManager.Instance.SaveInventory();
            if (ResourceManager.Instance != null) ResourceManager.Instance.SaveResource();
            if (PlantManager.Instance != null) PlantManager.Instance.SavePlant();
            if (ShopInteraction.Instance != null) ShopInteraction.Instance.SaveShopInteraction();
            SceneManager.LoadScene(teleportLocation);
        }
    }
    private void Start()
    {
        //OnSceneLoaded();
    }

    private void OnSceneLoaded()
    {
        Player.Instance.gameObject.transform.position = teleportPos;
    }
}
