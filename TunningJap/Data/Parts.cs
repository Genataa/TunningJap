using System.ComponentModel.DataAnnotations.Schema;

namespace TunningJap.Data
{
    public class Parts:BaseEntity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int IDCategory { get; set; }

        [ForeignKey("IDCategory")]
        public virtual Category? CategoryName { get; set; }
        // Колекция от PartsModel, за да се реализира много към много връзка
        public ICollection<Parts_Model>?  Parts_Models { get; set; }
    }
}
