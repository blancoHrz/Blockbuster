using System.ComponentModel.DataAnnotations;

namespace Blockbuster.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string DUI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}