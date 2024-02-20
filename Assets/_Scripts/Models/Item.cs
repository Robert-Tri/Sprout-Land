using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets._Scripts.Models
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Scriptable Object/Item2")]
    public class Item : ScriptableObject
    {
        public string itemName;
        [Header("Base Setting")]
        public int ID = -1;
        public Sprite icon;
        public GameObject m_object;
        public bool isStackable = false;
        public int maxStackNumber = 1;
        public Variety variety;

        [Header("Base Information")]
        [TextArea(3, 100)]
        public string description;
        [Space(10)]
        public int buyPrice;
        public int sellPrice;

        [Header("Audio Clip")]
        public AudioClip clipOnUse;
        public int playClipTimes;
    }
}
