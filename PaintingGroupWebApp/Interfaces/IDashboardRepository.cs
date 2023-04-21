using PaintingGroupWebApp.Models;

namespace PaintingGroupWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Meeting>> GetAllUserMeetings();
        Task<List<Club>> GetAllUserClubs();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
