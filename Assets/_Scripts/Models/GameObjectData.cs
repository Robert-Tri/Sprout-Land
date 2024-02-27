using UnityEngine;

namespace Assets._Scripts.Models
{
    public class GameObjectData : MonoBehaviour
    {
        public Item item;
        public int amount = 1;
        public GameObject itemPrefab;

        public GameObjectData()
        {
        }

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