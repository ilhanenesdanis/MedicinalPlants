namespace Core.Entity
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public List<District> Districts { get; set; }
    }
}
