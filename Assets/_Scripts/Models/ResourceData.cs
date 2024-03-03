using System.Collections.Generic;
using UnityEngine;
namespace Assets._Scripts.Models
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Scriptable Object/ResourceData")]
    public class ResourceData : ScriptableObject
    {
        public List<Resource> resources = new List<Resource>();
        private void OnDisable()
        {
            Resource resource = resources.Find(resource => resource.Name == "Gold");
            if (resource != null) resource.Quantity = 2000;
        }
    }
}
