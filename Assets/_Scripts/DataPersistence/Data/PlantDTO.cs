using Assets._Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Scripts.DataPersistence.Data
{
    [System.Serializable]
    public class PlantDTO
    {
        public int plantId;
        public float growTime;
        public float totalGrowTime;
        public int maxStage;
        public string textInteraction;
        public string startTimeToGrow;
        public string endTimeToGrow;
        public int harvestAmount;
        public float doubleChange;
        public float[] position = new float[3];
    }
}
