using System.ComponentModel.DataAnnotations.Schema;

namespace TunningJap.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }  // This will be mapped to the database
        [NotMapped]  // Tell EF Core to ignore this property
        public IFormFile Image { get; set; }   // Used for file uploads
    }

}
