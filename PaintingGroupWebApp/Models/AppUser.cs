using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintingGroupWebApp.Models
{
    public class AppUser : IdentityUser
    {
        
        public string? FavouriteStyle { get; set; }
        public string? FavouriteMedium { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Meeting> Meetings { get; set; }

    }
}
