using Microsoft.AspNetCore.Mvc;

namespace PaintingGroupWebApp.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
