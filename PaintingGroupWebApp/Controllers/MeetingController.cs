using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Detail(int id)
        {
            Meeting meeting = _context.Meetings.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
            return View(meeting);
        }
    }
}
