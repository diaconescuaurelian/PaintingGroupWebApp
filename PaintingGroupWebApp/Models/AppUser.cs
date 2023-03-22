using System.ComponentModel.DataAnnotations;

namespace PaintingGroupWebApp.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }
        public string? FavouriteStyle { get; set; }
        public string? FavouriteMedium { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Meeting> Meetings { get; set; }

    }
}
