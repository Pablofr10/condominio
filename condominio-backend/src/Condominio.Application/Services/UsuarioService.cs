using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces.Repository;
using Condominio.Domain.Interfaces.Services;

namespace Condominio.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UsuarioResponse>> BuscaUsuarios()
        {
            var usuarios = await _repository.Get();
            var retornoUsuario = _mapper.Map<IEnumerable<UsuarioResponse>>(usuarios);

            return retornoUsuario;
        }

        public async Task<UsuarioResponse> BuscaUsuarioPorId(int id)
        {
            var usuario = await _repository.Get(id);
            var usuarioRetorno = _mapper.Map<UsuarioResponse>(usuario);

            return usuarioRetorno;
        }

        public Task<bool> AdicionaUsuario(UsuarioRequest usuario)
        {
            var usuarioGravar = _mapper.Map<Usuario>(usuario);
            usuarioGravar.CriadoEm = DateTime.Now;
            usuarioGravar.Ativo = true;
            
            var retorno = _repository.Adicionar(usuarioGravar);

            return retorno;
        }

        public async Task<bool> AtualizaUsuario(int id, UsuarioRequest usuario)
        {
            if (id < 0)
            {
                throw new ArgumentException("Usuário não informado");
            }
            
            var usuarioBanco = await _repository.Get(id);

            if (usuarioBanco == null)
            {
                throw new ArgumentException("Usuário não existe no banco de dados.");
            }
            
            var usuarioGravar = _mapper.Map(usuario, usuarioBanco);
            
            var retorno = await _repository.Adicionar(usuarioGravar);

            return retorno;
        }

        
    }
}