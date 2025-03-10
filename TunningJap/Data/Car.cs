using System.ComponentModel.DataAnnotations.Schema;

namespace TunningJap.Data
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car:BaseEntity
    {
       // public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }  
    }

}
