using System.ComponentModel.DataAnnotations;

namespace MuchosAmuchos.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(12)]
        public string Telefono { get; set; } //+506 XXXX XXXX


        public virtual ICollection<Factura> Facturas { get; set; }


    }
}
