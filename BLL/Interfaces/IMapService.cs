﻿using ScratchWorld.ViewModels;
using System.Security.Claims;

namespace ScratchWorld.BLL.Interfaces
{
    public interface IMapService
    {
        Task<List<MapViewModel>> GetRegionsForUserAsync(ClaimsPrincipal user);
        Task UpdateRegionForUserAsync(ClaimsPrincipal user, MapViewModel mapViewModel);
    }
}
