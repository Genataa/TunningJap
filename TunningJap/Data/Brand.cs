namespace TunningJap.Data
{
    public class Brand:BaseEntity
    {
        public string BrandOfCar { get; set; }
        public ICollection<ModelCar>? ModelCars { get; set; } = new List<ModelCar>();
    }
}
