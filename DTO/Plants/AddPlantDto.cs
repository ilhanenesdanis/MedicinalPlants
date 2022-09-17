namespace DTO.Plants
{
    public class AddPlantDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string SmallContent { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int DisctrictId { get; set; }
    }
}
