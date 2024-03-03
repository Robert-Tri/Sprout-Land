using Assets._Scripts.DataPersistence.Data;
using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    [SerializeField] private PlantData plants;
    private static PlantManager instance;

    public static PlantManager Instance { get => instance; set => instance = value; }
    public PlantData Plants { get => plants; set => plants = value; }

    private void Start()
    {
        instance = this;
        plants = GlobalControl.Instance.plantData;
        foreach (var plant in plants.plants)
        {
            plant.GetComponent<SpriteRenderer>().enabled = true;
            foreach (var collider in plant.GetComponents<Collider2D>())
            {
                if (collider != null)
                {
                    collider.enabled = true;
                }
            }
        }
    }

    public void SavePlant()
    {
        foreach (var plant in plants.plants)
        {
            DontDestroyOnLoad(plant);
            plant.GetComponent<SpriteRenderer>().enabled = false;
            foreach (var collider in plant.GetComponents<Collider2D>())
            {
                if (collider != null)
                {
                    collider.enabled = false;
                }
            }
        }
        GlobalControl.Instance.plantData = plants;
    }

    public void SaveData(ref GameData data)
    {
        
    }

    public void LoadData(GameData data)
    {
    }
}
