using Assets._Scripts.DataPersistence.Data;
using Assets._Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryDTO
{
    public List<GameObjectDataDTO> items;

    public InventoryDTO()
    {
        items = new List<GameObjectDataDTO>();
    }
}
