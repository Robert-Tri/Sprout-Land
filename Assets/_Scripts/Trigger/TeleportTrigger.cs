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
            SceneManager.LoadScene(teleportLocation);
        }
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == teleportLocation)
        {
            Player.Instance.gameObject.transform.position = teleportPos;
        }
    }
}
