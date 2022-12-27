using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingHomework.Controllers
{
    public class ServerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
