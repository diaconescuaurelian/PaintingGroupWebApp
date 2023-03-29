using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaintingGroupWebApp.Data;
using PaintingGroupWebApp.Interfaces;
using PaintingGroupWebApp.Models;

namespace PaintingGroupWebApp.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingRepository _meetingRepository;

        public MeetingController(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Meeting> meetings = await _meetingRepository.GetAll();
            return View(meetings);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Meeting meeting = await _meetingRepository.GetByIdAsync(id); 
            return View(meeting);
        }
    }
}
