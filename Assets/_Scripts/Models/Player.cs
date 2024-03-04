using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Scripts.Models
{
    public class Player : MonoBehaviour
    {
        private static Player instance;
        public ResourceManager resourceManager;
        public static Player Instance { get => instance; set => instance = value; }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.Log("Found more than one Player in the scene.");
                Destroy(gameObject);
            }
            Player.instance = this;
            resourceManager = ResourceManager.Instance;
        }

        public bool PurchaseItemWithGold(int goldCost)
        {
            foreach (var resource in resourceManager.resourceData.resources)
            {
                if (resourceManager.SpendGold(goldCost))
                {
                    Debug.Log("Purchase successful!");
                    return true;
                }
                else
                {
                    Debug.Log("Not enough gold!");
                    return false;
                }
            }
            return false;
        }
    }
}
