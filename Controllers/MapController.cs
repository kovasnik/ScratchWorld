using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScratchWorld.BLL.Interfaces;
using ScratchWorld.ViewModels;

namespace ScratchWorld.Controllers
{
    public class MapController : Controller
    {
        private readonly IMapService _mapService;

        public MapController(IMapService mapService)
        {
            _mapService = mapService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.HideFooter = true;
            try
            {
                var result = await _mapService.GetRegionsForUserAsync(User);
                var jsonResult = JsonConvert.SerializeObject(result);
                ViewBag.RegionsJson = jsonResult;
                return View();
            }
            catch (InvalidOperationException ex)
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        [Route("Map")]
        public async Task<IActionResult> Index([FromBody] MapViewModel json)
        {
            try
            {
                await _mapService.UpdateRegionForUserAsync(User, json);
                return Ok(new { success = true, message = "Region status updated successfully" });
            }
            catch (InvalidOperationException ex)
            {
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}
