namespace TunningJap.Data
{
    public class Parts_Model:BaseEntity
    {
        public int ID_model { get; set; }
        public virtual ModelCar? ModelCar { get; set; }
        public int ID_Parts { get; set; }
        public virtual Parts? Parts { get; set; }

    }
}
