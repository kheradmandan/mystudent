using Microsoft.AspNetCore.Mvc;

namespace Students.Areas.AreaStudent.Controllers
{
    [Area("AreaStudent")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
