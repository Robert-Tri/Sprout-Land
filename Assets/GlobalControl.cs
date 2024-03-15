using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public InventoryData inventoryData;
    public ResourceData resourceData;
    public PlantData plantData;
    public bool isFirstMeeting = true;
    public bool isBackgroundMusicPlaying = true;
    public DataList dataList; 
    public static GlobalControl Instance;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
