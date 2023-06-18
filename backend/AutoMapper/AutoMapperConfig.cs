using AutoMapper;
using backend.Mdl;
using backend.ViewModel.Funcionario;
using backend.ViewModel.Usuario;
using Microsoft.AspNetCore.Identity;

namespace backend.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UsuarioRequestViewModel, Usuario>()
                .ForMember(dest => dest.UserName, u => u.MapFrom(u => u.Nome));

            CreateMap<Usuario, UsuarioResponseViewModel>()
                .ForMember(dest => dest.Nome, src => src.MapFrom(u => u.UserName));


            CreateMap<FuncionarioViewModelRequest, Funcionario>();
            CreateMap<Funcionario, FuncionarioViewModelResponse>();
        }
    }
}
