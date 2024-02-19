using UnityEngine;

namespace Assets._Scripts.Models
{
    public class GameObjectData : MonoBehaviour
    {
        public Item item;
        public int amount = 1;
        public void Awake()
        {
            amount = 1;
        }
    }
 }