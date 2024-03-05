using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
    }

    public void LoadGameplayScene()
    {
        SaveData();
        SceneManager.LoadScene("Map 1");
    }

    public void LoadMainMenu()
    {
        DestroyImmediate(GlobalControl.Instance.gameObject);
        DestroyImmediate(InteractManager.Instance.gameObject);
        DestroyImmediate(DataPersistenceManager.Instance.gameObject);
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadMapHome()
    {
        SaveData();
        SceneManager.LoadScene("Map Home");
    }

    public void LoadMap3()
    {
        SaveData();
        SceneManager.LoadScene("Map 3");
    }

    private void SaveData()
    {
        if (InventoryManager.Instance != null) InventoryManager.Instance.SaveInventory();
        if (ResourceManager.Instance != null) ResourceManager.Instance.SaveResource();
        if (PlantManager.Instance != null) PlantManager.Instance.SavePlant();
        if (ShopInteraction.Instance != null) ShopInteraction.Instance.SaveShopInteraction();
    }
}
