using Microsoft.AspNetCore.Mvc;

namespace ProjectInAndOut.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
           
        }
    }
}
