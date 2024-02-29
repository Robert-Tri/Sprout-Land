using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Inventory/InventoryData")]
public class InventoryData : ScriptableObject
{
    public List<GameObjectData> items = new List<GameObjectData>();
    private void OnDisable()
    {
        items.Clear();
    }
}
