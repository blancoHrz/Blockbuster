using System.ComponentModel.DataAnnotations;

namespace Blockbuster.Models
{
    public class Pelicula
    {
        [Key]
        public int idPelicula { get; set; }
        public string titulo { get; set; }
        public string genero { get; set; }
        public string director { get; set; }
        public string sinopsis { get; set; }
        public string duracion { get; set; }
        public string clasificacion { get; set; }
        public byte[] caratula { get; set; }
    }
}