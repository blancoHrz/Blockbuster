using System.ComponentModel.DataAnnotations;

namespace Blockbuster.Models
{
    public class Alquiler
    {
        [Key]
        public int idAlquiler { get; set; }  // Clave primaria
        public int idPelicula { get; set; }  // Clave foránea hacia Pelicula
        public int idCliente { get; set; }   // Clave foránea hacia Cliente
        public DateTime FechaAlquiler { get; set; }  // Fecha en que se realizó el alquiler
        public DateTime FechaDevolucion { get; set; } // Fecha en que debe devolverse la película

        // Relaciones con otras entidades
        public Pelicula Pelicula { get; set; }  // Relación con Pelicula
        public Cliente Cliente { get; set; }    // Relación con Cliente
    }
}
