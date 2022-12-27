using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingHomework.Controllers
{
    public class HostingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
