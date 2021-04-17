﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Condominio.Application.Exceptions;
using Condominio.Domain.Dtos;
using Condominio.Domain.Dtos.Identity;
using Condominio.Domain.Dtos.Request;
using Condominio.Domain.Dtos.Response;
using Condominio.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Condominio.Application.Services
{
    public class PermissaoService : IPermissaoService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PermissaoService(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }
        
        public IEnumerable<PermissoesResponse> GetPermissoes()
        {
            var roles = _roleManager.Roles;
            var permicoes = _mapper.Map<List<PermissoesResponse>>(roles);

            return permicoes;
        }
        
        public async Task<IEnumerable<UserRoleDto>> GetPermissao(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            
            if (role == null)
            {
                throw new PermissaoException("A permissão não existe na base de dados.");
            }

            List<UserRoleDto> userRole = new List<UserRoleDto>();

            var userRoles = await _userManager.GetUsersInRoleAsync(role.Name);

            foreach (var user in userRoles)
            {
                var userRoleDto = new UserRoleDto
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    RoleId = role.Id
                };
                
                userRole.Add(userRoleDto);
            }
            
            return userRole;
        }

        public async Task<bool> CriarPermissao(PermissoesRequest role)
        {
            var criarPermissao = _mapper.Map<Role>(role);

            IdentityResult resul = await _roleManager.CreateAsync(criarPermissao);
            
            return resul.Succeeded;
        }

        public async Task<bool> EditarPermissoes(PermissoesEditarRequest permicao)
        {
            var role = await _roleManager.FindByIdAsync(permicao.Id);

            if (role == null)
            {
                throw new PermissaoException("A perissão não existe na base de dados.");
            }

            role.Name = permicao.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}