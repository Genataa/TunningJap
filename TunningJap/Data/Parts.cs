namespace TunningJap.Data
{
    public class Parts:BaseEntity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int IDCategory { get; set; }
        public Category CategoryName { get; set; }
    }
}
