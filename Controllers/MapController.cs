using Microsoft.AspNetCore.Mvc;

namespace ScratchWorld.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
