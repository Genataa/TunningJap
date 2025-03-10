using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TunningJap.Data
{
    public class ModelCar : BaseEntity
    {
        public string NameOfModel { get; set; }

        public int Id_Brand { get; set; }

        [ForeignKey("Id_Brand")]
        [DisplayName("Brand Name")]
        public virtual Brand? BrandName { get; set; }

        public ICollection<Parts_Model>? Parts_Models { get; set; }
    }
}
