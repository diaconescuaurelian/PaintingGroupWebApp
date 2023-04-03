using PaintingGroupWebApp.Data.Enum;
using PaintingGroupWebApp.Models;

namespace PaintingGroupWebApp.ViewModels
{
    public class CreateMeetingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public MeetingCategory MeetingCategory { get; set; }
    }
}
