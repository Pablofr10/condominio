using AutoMapper;
using Condominio.Domain.Dtos;
using Condominio.Domain.Dtos.Identity;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;
using Condominio.Domain.Entities;

namespace Condominio.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, UsuarioResponse>().ForMember(
                dest => dest.UrlImagem, opt =>
                    opt.MapFrom(src => src.Imagem.Url));
            CreateMap<Contato, ContatoDto>().ReverseMap();
            CreateMap<UsuarioRequest, Usuario>().ReverseMap();
            CreateMap<Imagem, ImagemDto>().ReverseMap();
            CreateMap<Contato, ContatoDto>().ReverseMap();
            CreateMap<User, UserRequest>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, UserLoginResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());
            CreateMap<Role, PermissoesResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NormalizedName));
            CreateMap<PermissoesRequest, Role>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome));
        }
    }
}