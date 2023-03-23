using Microsoft.AspNetCore.Mvc;

namespace PaintingGroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
