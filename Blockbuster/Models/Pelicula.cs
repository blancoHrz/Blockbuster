using System.ComponentModel.DataAnnotations;

namespace Blockbuster.Models
{
    public class Pelicula
{
            [Key]
            public int idPelicula { get; set; }
            public string Titulo { get; set; }
            public string Genero { get; set; }
            public string Director { get; set; }
            public string Sinopsis { get; set; }
            public string Duracion { get; set; }
            public string Clasificacion { get; set; }
            public byte[] Caratula { get; set; }
        }
    }

