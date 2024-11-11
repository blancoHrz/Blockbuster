using Microsoft.EntityFrameworkCore;

namespace Blockbuster.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }  // Agregamos el DbSet de Alquiler

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pelicula>().HasKey(e => e.idPelicula);
            modelBuilder.Entity<Cliente>().HasKey(e => e.idCliente);
            modelBuilder.Entity<Alquiler>().HasKey(e => e.idAlquiler);  // Definimos la clave primaria de Alquiler

            // Configuramos las relaciones entre Alquiler, Pelicula y Cliente
            modelBuilder.Entity<Alquiler>()
                .HasOne(a => a.Pelicula)  // Relación con la Pelicula
                .WithMany()  // Un alquiler tiene una película, pero una película puede tener muchos alquileres
                .HasForeignKey(a => a.idPelicula);  // Establecemos la clave foránea

            modelBuilder.Entity<Alquiler>()
                .HasOne(a => a.Cliente)  // Relación con el Cliente
                .WithMany()  // Un alquiler tiene un cliente, pero un cliente puede hacer muchos alquileres
                .HasForeignKey(a => a.idCliente);  // Establecemos la clave foránea
        }
    }
}
