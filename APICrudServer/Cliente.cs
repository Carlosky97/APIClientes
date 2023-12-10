using System.ComponentModel.DataAnnotations;

namespace APICrudServer
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(75)]
        public string PrimerNombre { get; set; } = "";
        [Required]
        [StringLength(75)]
        public string SegundoNombre { get; set; } = "";
        [Required]
        [StringLength(50)]
        public string Telefono { get; set; } = "";
        [Required]
        [StringLength(75)]
        public string Email { get; set; } = "";
    }
}
