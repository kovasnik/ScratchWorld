using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScratchWorld.BLL.Interfaces;
using ScratchWorld.Data.Interfaces;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;
using System.Security.Claims;

namespace ScratchWorld.BLL.Services
{
    public class MapService : IMapService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRegionRepository _regionRepository;
        private readonly IRegionSettingsRepository _regionSettingsRepository;

        public MapService(UserManager<User> userManager, IRegionRepository regionRepository, IRegionSettingsRepository regionSettingsRepository)
        {
            _userManager = userManager;
            _regionRepository = regionRepository;
            _regionSettingsRepository = regionSettingsRepository;
        }

        public async Task<List<MapViewModel>> GetRegionsForUserAsync(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);
            if (currentUser == null)
                throw new InvalidOperationException("User is not authorized");


            var regions = await _regionRepository.GetAll();
            var regionsSettings = await _regionSettingsRepository.GetUsersRegions(currentUser.Id);
            List<MapViewModel> result = new();

            int index = 0;
            foreach (var region in regions)
            {
                if (index < regions.Count() - 1)
                {
                    var settings = regionsSettings?.FirstOrDefault(s => s.RegionId == region.Id);
                    var mapViewModel = new MapViewModel()
                    {
                        RegionId = region.Id,
                        Name = region.Name,
                        UkrName = region.UkrName,
                        Coordinates = region.Coordinates,
                        ColorPalette = settings?.ColorPalette ?? 0,
                        Status = settings?.Status ?? 0
                    };

                    result.Add(mapViewModel);
                }
                index++;
            }
            return result;
        }

        public async Task UpdateRegionForUserAsync(ClaimsPrincipal user, MapViewModel mapViewModel)
        {
            var currentUser = await _userManager.GetUserAsync(user);
            if (currentUser == null)
                throw new InvalidOperationException("User is not authorized");

            var regionSettings = new RegionSettings()
            {
                RegionId = mapViewModel.RegionId,
                UserId = currentUser.Id,
                ColorPalette = mapViewModel.ColorPalette,
                Status = mapViewModel.Status
            };

            var existingRegion = await _regionSettingsRepository.GetByRegionIdNoTracking(regionSettings);

            if (existingRegion == null)
            {
                await _regionSettingsRepository.AddAsync(regionSettings);
            }
            else
            {
                regionSettings.Id = existingRegion.Id;
                await _regionSettingsRepository.UpdateAsync(regionSettings);
            }
        }
    }
}
