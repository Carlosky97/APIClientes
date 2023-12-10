using System.ComponentModel.DataAnnotations;

namespace ApiCrudCliente.Models
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }

        [StringLength(75)]
        public string primerNombre { get; set; } = "";

        [StringLength(75)]
        public string segundoNombre { get; set; } = "";

        [StringLength(50)]
        public string telefono { get; set; } = "";

        [StringLength(75)]
        public string email { get; set; } = "";
    }

}
