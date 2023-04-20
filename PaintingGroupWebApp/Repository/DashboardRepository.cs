using PaintingGroupWebApp.Data;
using PaintingGroupWebApp.Models;
using PaintingGroupWebApp.Data;
using PaintingGroupWebApp.Interfaces;
using PaintingGroupWebApp.Models;
namespace PaintingGroupWebApp.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Club>> GetAllUserClubs()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userClubs = _context.Clubs.Where(r => r.AppUser.Id == curUser);
            return userClubs.ToList();
        }

        public async Task<List<Meeting>> GetAllUserMeetings()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userRaces = _context.Meetings.Where(r => r.AppUser.Id == curUser);
            return userRaces.ToList();
        }
    }
}
