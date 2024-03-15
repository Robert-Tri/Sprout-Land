using Assets._Scripts.DataPersistence.Data;
using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField]
    public InventoryDTO inventoryData;
    [SerializeField]
    public ResourceDataDTO resourceData;
    [SerializeField]
    public List<PlantDTO> plantData;
    [SerializeField]
    public bool isFirstMeeting = true;
    public bool isBackgroundMusicPlaying = true;

    public GameData ()
    {
        inventoryData = new InventoryDTO ();
        resourceData = new ResourceDataDTO();
        plantData = new List<PlantDTO> ();
    }
}
