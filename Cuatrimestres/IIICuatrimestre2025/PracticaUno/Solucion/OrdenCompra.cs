using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    public class OrdenCompra
    {
        public int NumeroOrden { get; set; }
        public DateTime Fecha { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<ItemOrden> Items { get; set; }
        public bool Recibida { get; set; }
        public decimal Total => Items.Sum(item => item.Subtotal);

        public OrdenCompra(int numeroOrden, Proveedor proveedor)
        {
            NumeroOrden = numeroOrden;
            Fecha = DateTime.Now;
            Proveedor = proveedor;
            Items = new List<ItemOrden>();
            Recibida = false;
        }

        public void AgregarItem(Producto producto, int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor a cero.");
            }

            var itemExistente = Items.FirstOrDefault(i => i.Producto.Id == producto.Id);
            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                Items.Add(new ItemOrden(producto, cantidad));
            }
        }

        public override string ToString()
        {
            string estado = Recibida ? "RECIBIDA" : "PENDIENTE";
            string resultado = $"\n--- ORDEN #{NumeroOrden} ({estado}) ---\n";
            resultado += $"Fecha: {Fecha:dd/MM/yyyy HH:mm}\n";
            resultado += $"Proveedor: {Proveedor.Nombre}\n";
            resultado += "Items:\n";

            foreach (var item in Items)
            {
                resultado += item.ToString() + "\n";
            }

            resultado += $"TOTAL: ${Total:F2}\n";
            return resultado;
        }
    }
}
