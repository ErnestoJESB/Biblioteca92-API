using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options): base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en la tabla usuario

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre= "Neto",
                    User= "Usuario1",
                    Password= "1234",
                    FkRol= 1
                });

            //Insertar en la tabla Rol

            modelBuilder.Entity<Rol>().HasData(
                new Rol
            {
                PkRol = 1,
                Nombre = "Admin"
            });

            //Insertar en la tabla Autor

        }
    }
}
