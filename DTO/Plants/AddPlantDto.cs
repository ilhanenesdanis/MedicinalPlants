using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Plants
{
    public class AddPlantDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string SmallContent { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public List<string> ImageList { get; set; }
    }
}
