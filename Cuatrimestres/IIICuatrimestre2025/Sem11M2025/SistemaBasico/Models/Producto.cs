using System.ComponentModel.DataAnnotations;

namespace SistemaBasico.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        public string NombreProducto { get; set; }

        public decimal Precio { get; set; }

        public int CantidadEnStock { get; set; }
    }
}
