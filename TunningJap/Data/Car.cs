using System.ComponentModel.DataAnnotations.Schema;

namespace TunningJap.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        // Add a property to store the image path
        public string ImagePath { get; set; }

        // Add a property for the uploaded image
        [NotMapped] // This will be ignored by EF
        public IFormFile Image { get; set; }
    }
}
