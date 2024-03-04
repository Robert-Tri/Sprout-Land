using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Scripts.Models
{
    [CreateAssetMenu(menuName = "Scriptable Object/DataList")]
    public class DataList : ScriptableObject
    {
        public List<Item> Items = new List<Item>();

        public Item GetItemById(int id)
        {
            foreach(var item in Items)
            {
                if (item.ID == id) return item;
            }
            return null;
        }
    }
}
