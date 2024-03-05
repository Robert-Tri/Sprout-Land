using Assets._Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Scripts.Models
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Scriptable Object/PlantData")]
    public class PlantData : ScriptableObject
    {
        public List<GameObject> plants = new List<GameObject>();
        private void OnDisable()
        {
            plants.Clear();
        }
    }
}
