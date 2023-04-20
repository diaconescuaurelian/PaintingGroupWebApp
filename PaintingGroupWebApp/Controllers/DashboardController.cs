using Microsoft.AspNetCore.Mvc;
using PaintingGroupWebApp.Interfaces;
using PaintingGroupWebApp.ViewModels;

namespace PaintingGroupWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRespository;

        public DashboardController(IDashboardRepository dashboardRespository)
        {
            _dashboardRespository = dashboardRespository;
        }
        public async Task<IActionResult> Index()
        {
            var userRaces = await _dashboardRespository.GetAllUserMeetings();
            var userClubs = await _dashboardRespository.GetAllUserClubs();
            var dashboardViewModel = new DashboardViewModel()
            {
                Meetings = userRaces,
                Clubs = userClubs
            };
            return View(dashboardViewModel);
        }
    }
}
