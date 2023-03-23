using Microsoft.AspNetCore.Mvc;
using PaintingGroupWebApp.Data;
using PaintingGroupWebApp.Models;

namespace PaintingGroupWebApp.Controllers
{
    public class MeetingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Meeting> meetings = _context.Meetings.ToList();
            return View(meetings);
        }
    }
}
