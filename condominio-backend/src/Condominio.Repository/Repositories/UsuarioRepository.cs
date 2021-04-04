using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Dtos.Response;
using AutoMapper;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.UsuarioRequest;
using Condominio.Domain.Entities;
using Condominio.Interface.Repository;
using Condominio.Repository.Commom;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CondominioDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepository(CondominioDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UsuarioResponse>> Get()
        {
            var query = await _context.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.Imagem)
                .ToListAsync();

            var retornoUsuario = _mapper.Map<IEnumerable<UsuarioResponse>>(query);

            return retornoUsuario;
        }

        public async Task<UsuarioResponse> Get(int id)
        {
            var query = await _context.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.Imagem).FirstOrDefaultAsync();
            
            var usuarioRetorno = _mapper.Map<UsuarioResponse>(query);
            
            return usuarioRetorno;
        }
        
        public async Task<bool> PostUsuario(UsuarioRequest usuario)
        {
            try
            {
                var usuarioGravar = _mapper.Map<Usuario>(usuario);
                
                usuarioGravar.CriadoEm = DateTime.Now;
                usuarioGravar.Ativo = true;
        
                await _context.Usuarios.AddAsync(usuarioGravar);
                await _context.SaveChangesAsync();
        
                return true;
        
            }
            catch (Exception e)
            {
                throw new ArgumentException("Erro ao gravar usuário" + e.Message);
            }
        }
        
        public async Task<bool> PutUsuario(int id, UsuarioRequest usuario)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentException("Usuário não informado");
                }
                
                var usuarioBanco = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
                
                if (usuarioBanco == null)
                {
                    throw new ArgumentException("Usuário não existe no banco de dados.");
                }
                
                var usuarioGravar = _mapper.Map(usuario, usuarioBanco);
        
                _context.Update(usuarioGravar);
                await _context.SaveChangesAsync();
        
                return true;
        
            }
            catch (Exception e)
            {
                throw new ArgumentException("Erro ao editar usuário " + e.Message);;
            }
        
        }
    }
}