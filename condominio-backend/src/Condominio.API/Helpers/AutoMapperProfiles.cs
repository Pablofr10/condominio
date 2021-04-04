
using System;
using AutoMapper;
using Condominio.Domain.Dtos;
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
                    opt.Condition( (src, dest, srcMember) => srcMember != null));
            CreateMap<Contato, ContatoDto>().ReverseMap();
            CreateMap<UsuarioRequest, Usuario>().ReverseMap();
            CreateMap<Imagem, ImagemDto>().ReverseMap();
            CreateMap<Contato, ContatoDto>().ReverseMap();
        }
    }
}