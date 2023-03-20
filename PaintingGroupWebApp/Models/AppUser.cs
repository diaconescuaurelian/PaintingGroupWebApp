namespace PaintingGroupWebApp.Models
{
    public class AppUser
    {
        public string? FavouriteStyle { get; set; }
        public string? FavouriteMedium { get; set; }
        public Address? MAddress { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Meeting> Meetings { get; set; }

    }
}
