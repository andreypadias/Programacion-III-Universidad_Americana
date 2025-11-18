using System.ComponentModel.DataAnnotations;

namespace IdentityBasico.Models
{
    public class Factura
    {
        [Key]
        public int FacturaID { get; set; }

        public string Detalle { get; set; }

        public decimal Monto { get; set; }
    }
}
