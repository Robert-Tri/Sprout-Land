using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Scripts.DataPersistence.Data
{
    [Serializable]
    public class ResourceDataDTO
    {
        public List<ResourceDTO> resources;

        public ResourceDataDTO()
        {
            resources = new List<ResourceDTO>();
        }
    }
}
