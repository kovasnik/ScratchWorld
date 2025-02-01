using AutoMapper;
using ScratchWorld.Models;
using ScratchWorld.ViewModels;

namespace ScratchWorld.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterVeiwModel, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<AddDataViewModel, User>();
            CreateMap<User, AddDataViewModel>();
            CreateMap<DetailViewModel, User>();
            CreateMap<User, DetailViewModel>();
            CreateMap<LandmarkViewModel, Landmark>()
                .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(_ => false));
            CreateMap<RegionSettingsViewModel, RegionSettings>();
            CreateMap<Region, MapViewModel>()
                .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ColorPalette, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore());

        }
    }
}
