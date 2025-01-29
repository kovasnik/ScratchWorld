using AutoMapper;
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
        private readonly IMapper _mapper;

        public MapService(UserManager<User> userManager, IRegionRepository regionRepository, 
            IRegionSettingsRepository regionSettingsRepository, IMapper mapper)
        {
            _userManager = userManager;
            _regionRepository = regionRepository;
            _regionSettingsRepository = regionSettingsRepository;
            _mapper = mapper;
        }

        public async Task<List<MapViewModel>> GetRegionsForUserAsync(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);
            if (currentUser == null)
                throw new InvalidOperationException("User is not authorized");


            var regions = await _regionRepository.GetRegions();
            var regionsSettings = await _regionSettingsRepository.GetUsersRegions(currentUser.Id);
            
            var result = _mapper.Map<List<MapViewModel>>(regions);

            foreach (var region in result)
            {
                var settings = regionsSettings?.FirstOrDefault(s => s.RegionId == region.RegionId);

                region.ColorPalette = settings?.ColorPalette ?? 0;
                region.Status = settings?.Status ?? 0;
            }

            return result;
        }

        public async Task UpdateRegionForUserAsync(ClaimsPrincipal user, RegionSettingsViewModel viewModel)
        {
            var currentUser = await _userManager.GetUserAsync(user);
            if (currentUser == null)
                throw new InvalidOperationException("User is not authorized");

            var regionSettings = _mapper.Map<RegionSettings>(viewModel);
            regionSettings.UserId = currentUser.Id;
            //var regionSettings = new RegionSettings()
            //{
            //    RegionId = mapViewModel.RegionId,
            //    UserId = currentUser.Id,
            //    ColorPalette = mapViewModel.ColorPalette,
            //    Status = mapViewModel.Status
            //};

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
