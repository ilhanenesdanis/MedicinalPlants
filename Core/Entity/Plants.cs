namespace Core.Entity
{
    public class Plants : Base
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string SmallContent { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public PlantCategory PlantCategory { get; set; }
        public List<PlantsImage> PlantsImages { get; set; }

    }
}
