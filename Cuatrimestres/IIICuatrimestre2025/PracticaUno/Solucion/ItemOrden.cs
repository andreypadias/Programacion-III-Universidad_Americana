using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    public class ItemOrden
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Producto.PrecioPorUnidad * Cantidad;

        public ItemOrden(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        public override string ToString()
        {
            return $"  - {Producto.Nombre} x {Cantidad} = ${Subtotal:F2}";
        }
    }
}
