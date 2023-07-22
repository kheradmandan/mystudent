using Microsoft.AspNetCore.Mvc;

namespace Students.Areas.AreaTeacher.Controllers
{
    [Area("AreaTeacher")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
