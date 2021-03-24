using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Condominio.Domain.Dtos;
using Condominio.Interface.Repositories;
using Condominio.Repository.Commom;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CondominioDbContext _context;

        public UsuarioRepository(CondominioDbContext context)
        {
            _context = context;
        }
        public async Task<List<UsuarioDto>> Get()
        {
            var query = await _context.Usuarios.Select( x => new UsuarioDto
            {
                Id = x.Id,
                Nome = x.Nome,
                NumeroApartamento = x.NumeroApartamento,
                Ativo = x.Ativo,
                Cpf = x.Cpf,
                Complemento = x.Complemento
            }).ToListAsync();

            return query;
        }

        public async Task<UsuarioDto> Get(int id)
        {
            var query = await _context.Usuarios.Where(x => x.Id == id)
                .Select(x => new UsuarioDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    NumeroApartamento = x.NumeroApartamento,
                    Ativo = x.Ativo,
                    Cpf = x.Cpf,
                    Complemento = x.Complemento
                }).FirstOrDefaultAsync();
            
            return query;
        }
    }
}