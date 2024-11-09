using Microsoft.EntityFrameworkCore;

namespace Blockbuster.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Alquiler> Alquiler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pelicula>().HasKey(e => e.idPelicula);
            modelBuilder.Entity<Cliente>().HasKey(e => e.idCliente);
            modelBuilder.Entity<Alquiler>().HasKey(e => e.idAlquiler);
        }
    }
}