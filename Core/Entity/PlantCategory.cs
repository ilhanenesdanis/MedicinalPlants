namespace Core.Entity
{
    public class PlantCategory:Base
    {
        public string Name { get; set; }
        public List<Plants> Plants { get; set; }
    }
}
