using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TunningJap.Data
{
    public class ModelCar:BaseEntity
    {
        public string NameOfModel { get; set; }
        public int Id_Brand { get; set; }
        [ForeignKey("Brand")]
        [DisplayName("Brand Name")]
        public virtual Brand? BrandName { get; set; }

        //  PartsModel (връзка много към много)
        public ICollection<Parts_Model>? Parts_Models { get; set; }

    }
}
