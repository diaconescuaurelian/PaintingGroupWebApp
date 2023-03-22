using System.ComponentModel.DataAnnotations;

namespace PaintingGroupWebApp.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
