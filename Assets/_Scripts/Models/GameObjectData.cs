using System;
using UnityEngine;

namespace Assets._Scripts.Models
{
    [System.Serializable]
    public class GameObjectData : MonoBehaviour
    {
        public Item item;
        public int amount = 1;
        public GameObject itemPrefab;

        public void Awake()
        {
            amount = 1;
        }
        /*
            ID list:
            - Seed: 1 - 14
            - Product from farming: 15 - 28
         */
    }
 }