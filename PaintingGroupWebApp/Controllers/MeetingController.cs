using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaintingGroupWebApp.Data;
using PaintingGroupWebApp.Interfaces;
using PaintingGroupWebApp.Models;
using PaintingGroupWebApp.Repository;
using PaintingGroupWebApp.Services;
using PaintingGroupWebApp.ViewModels;

namespace PaintingGroupWebApp.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IPhotoService _photoService;

        public MeetingController(IMeetingRepository meetingRepository, IPhotoService photoService)
        {
            _meetingRepository = meetingRepository;
            _photoService = photoService;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetingViewModel meetingVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(meetingVM.Image);
                var meeting = new Meeting
                {
                    Title = meetingVM.Title,
                    Description = meetingVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = meetingVM.Address.Street,
                        City = meetingVM.Address.City,
                        County = meetingVM.Address.County,
                    }
                };
                _meetingRepository.Add(meeting);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(meetingVM);
        }
    }
}
