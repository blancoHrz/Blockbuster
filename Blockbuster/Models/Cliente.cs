using System.ComponentModel.DataAnnotations;

namespace Blockbuster.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string dui { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
    }
}