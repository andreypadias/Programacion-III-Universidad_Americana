using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    public class Inventario
    {
        private Dictionary<int, int> stock;

        public Inventario()
        {
            stock = new Dictionary<int, int>();
        }

        public void ActualizarStock(int productoId, int cantidad)
        {
            if (stock.ContainsKey(productoId))
            {
                stock[productoId] += cantidad;
            }
            else
            {
                stock[productoId] = cantidad;
            }
        }

        public int ObtenerStock(int productoId)
        {
            return stock.ContainsKey(productoId) ? stock[productoId] : 0;
        }

        public void MostrarInventario(List<Producto> productos)
        {
            Console.WriteLine("\n=== INVENTARIO ACTUAL ===");
            foreach (var producto in productos)
            {
                int cantidadEnStock = ObtenerStock(producto.Id);
                Console.WriteLine($"{producto.Nombre}: {cantidadEnStock} unidades");
            }
            Console.WriteLine("========================");
        }
    }
}
