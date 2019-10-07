using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MilanCorp.Domain.Identity;
using MilanCorp.Domain.Models;

namespace MilanCorp.Repository
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int,
                                                        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Material> Materiais { get; set; }
        public virtual DbSet<FileUpload> Uploads { get; set; }
        public virtual DbSet<Aniversariante> Aniversariantes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

                userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            builder.Entity<Material>()
                 .HasKey(PE => new { PE.Id, PE.UploadId, PE.UserId });

            //builder.Entity<Material>(material =>
            //{
            //    material.HasKey(ur => new { ur.Id });

            //    material.HasOne(ur => ur.Upload)
            //    .WithMany(r => r.Materiais)
            //    .HasForeignKey(ur => ur.UploadId)
            //    .HasConstraintName("FK_Materiais_Upload");

            //    material.HasOne(ur => ur.Usuario)
            //    .WithMany(r => r.Materiais)
            //    .HasForeignKey(ur => ur.UserId)
            //    .HasConstraintName("FK_Materiais_User");
            //});

        }

    }
}

