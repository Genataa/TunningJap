namespace TunningJap.Data
{
    public class ModelCar:BaseEntity
    {
        public string NameOfModel { get; set; }
        public int Id_Brand { get; set; }
        public virtual Brand BrandName { get; set; }

    }
}
