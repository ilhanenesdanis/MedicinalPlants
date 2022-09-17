using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Plants
{
    public class PlantsDto
    {
        public int PlantId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string SmallContent { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int DisctrictId { get; set; }

    }
}
