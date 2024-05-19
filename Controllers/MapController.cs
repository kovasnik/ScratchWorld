using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;

namespace ScratchWorld.Controllers
{
    public class MapController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IRegionRepository _regionRepository;
        private readonly IRegionSettingsRepository _regionSettingsRepository;

        public MapController(UserManager<User> userManager, IRegionRepository regionRepository, IRegionSettingsRepository regionSettingsRepository)
        {
            _userManager = userManager;
            _regionRepository = regionRepository;
            _regionSettingsRepository = regionSettingsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var regions = await _regionRepository.GetAll();
            var regionsSettings = await _regionSettingsRepository.GetUsersRegions(user.Id);
            List<MapViewModel> result = new List<MapViewModel>();
            int index = 0;
            foreach (var region in regions)
            {
                if (index < regions.Count() - 1)
                {
                    var setting = regionsSettings?.FirstOrDefault(s => s.RegionId == region.Id);
                    var mapViewModel = new MapViewModel()
                    {
                        Name = region.Name,
                        UkrName = region.UkrName,
                        Coordinates = region.Coordinates,
                        ColorPalette = setting?.ColorPalette ?? 0,
                        Status = setting?.Status ?? 0
                    };
                    result.Add(mapViewModel);
                }
                index++;
            }
            //var jsonResult = JsonConvert.SerializeObject(result);
            var jsonResult = JsonConvert.SerializeObject(result);
            ViewBag.RegionsJson = jsonResult;
            return View();
        }
    }
}
