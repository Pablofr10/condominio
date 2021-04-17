using System;
using Condominio.Domain.Dtos.Identity;
using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Repository.Maps
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        private readonly string _tableName;
        public UserRoleMap(string tableName = "")
        {
            _tableName = tableName;
        }
        public virtual void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
                    
                userRole.ToTable("tb_user_role");
                userRole.HasKey(ur => new {ur.UserId, ur.Role});

                userRole.Property(ur => ur.RoleId).HasColumnName("id_role").IsRequired();
                userRole.Property(ur => ur.User).HasColumnName("id_user").IsRequired();
            });
        }

        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            throw new NotImplementedException();
        }
    }
}