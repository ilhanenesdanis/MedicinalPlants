namespace Core.Entity
{
    public class PlantsImage:Base
    {
        public string ImagePath { get; set; }
        public int PlantId { get; set; }
        public Plants Plants { get; set; }
    }
}
