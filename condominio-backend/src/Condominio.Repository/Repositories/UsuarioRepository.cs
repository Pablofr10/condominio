using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Condominio.Domain.Dtos;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;
using AutoMapper;
using Condominio.Domain.Entities;
using Condominio.Interface.Repositories;
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
            var query = await _context.Usuarios.Where(x => x.Id == id)
                .Select(x => new UsuarioResponse
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    NumeroApartamento = x.NumeroApartamento,
                    Ativo = x.Ativo,
                    Cpf = x.Cpf,
                    Complemento = x.Complemento,
                    Contato = new ContatoDto
                    {
                        Email = x.Contato.Email,
                        Telefone = x.Contato.Telefone,
                        Celular = x.Contato.Celular
                    }
                }).FirstOrDefaultAsync();
            
            return query;
        }

        public async Task<bool> PostUsuario(UsuarioRequest usuario)
        {
            try
            {
                var usuarioGravar = _mapper.Map<Usuario>(usuario);

                await _context.Usuarios.AddAsync(usuarioGravar);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception e)
            {
                throw new ArgumentException("Erro ao gravar usuário" + e.Message);
            }
        }
    }
}