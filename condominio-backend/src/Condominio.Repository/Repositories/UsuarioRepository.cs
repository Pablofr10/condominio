using System.Collections.Generic;
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
                Nome = x.Nome,
                NumeroApartamento = x.NumeroApartamento,
                Ativo = x.Ativo,
                Cpf = x.Cpf,
                Complemento = x.Complemento
            }).ToListAsync();

            return query;
        }
    }
}