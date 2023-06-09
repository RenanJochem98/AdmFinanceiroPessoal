using AutoMapper;
using backend.Dto;
using backend.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace backend.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<IdentityUser, UsuarioResponseViewModel>()
                .ForMember(dest => dest.Nome, src => src.MapFrom(u => u.UserName));

            CreateMap<UsuarioRequestViewModel, IdentityUser>()
                .ForMember(dest => dest.UserName, u => u.MapFrom(u => u.Nome));
        }
    }
}
