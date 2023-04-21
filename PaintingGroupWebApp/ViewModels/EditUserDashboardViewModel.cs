namespace PaintingGroupWebApp.ViewModels
{
    public class EditUserDashboardViewModel
    {
        public string Id { get; set; }
        public string? FavouriteStyle { get; set; }
        public string? FavouriteMedium { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public IFormFile Image { get; set; }
    }
}
