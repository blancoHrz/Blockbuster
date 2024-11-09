using System.ComponentModel.DataAnnotations;

namespace Blockbuster.Models
{
    public class Alquiler
    {
        [Key]
        public int idAlquiler { get; set; }
        public string idCliente { get; set; }
        public string idPelicula { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; } = "Pendiente";
    }
}
