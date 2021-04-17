using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces.Repository;
using Condominio.Infrastructure.Commom;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly CondominioDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepository(CondominioDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Usuario>> Get()
        {
            var query = await _context.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.Imagem)
                .ToListAsync();

            return query;
        }

        public async Task<Usuario> Get(int id)
        {
            var query = await _context.Usuarios
                .Include(u => u.Contato)
                .Include(u => u.Imagem).FirstOrDefaultAsync();

            return query;
        }

        public async Task<bool> Adicionar(Usuario usuario)
        {
            Add(usuario);

            if (await SaveChangesAsync())
            {
                return true;
            }

            throw new ArgumentException("Erro ao gravar usuário");
        }

        public async Task<bool> Atualizar(Usuario usuario)
        {
            Add(usuario);

            if (await SaveChangesAsync())
            {
                return true;
            }

            throw new ArgumentException("Erro ao editar usuário");
        }
    }
}