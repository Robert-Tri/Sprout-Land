using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Scripts.Models
{
    [System.Serializable]
    public class Resource
    {
        public string Name;
        public int Quantity;

        public Resource(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
