using PaintingGroupWebApp.Models;

namespace PaintingGroupWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Meeting>> GetAllUserMeetings();
        Task<List<Club>> GetAllUserClubs();
    }
}
