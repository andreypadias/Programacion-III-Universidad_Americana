using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSemanaUno.Data
{
    public class Pedido
    {
        public string Cliente { get; set; }
        public List<(Producto Producto, int Cantidad)> Productos { get; private set; } = new List<(Producto, int)>();
        public decimal Total { get; private set; } = 0;

        // Crear
        public void AgregarProducto(Producto producto, int cantidad)
        {
            if (producto.EstaDisponible(cantidad))
            {
                producto.ReducirInventario(cantidad);
                Productos.Add((producto, cantidad));
                Total += producto.Precio * cantidad;
                Console.WriteLine($"Producto {producto.Nombre} agregado al pedido.");
            }
            else
            {
                throw new InvalidOperationException($"No hay suficiente inventario para el producto {producto.Nombre}.");
            }
        }

        // Leer
        public void MostrarPedido()
        {
            Console.WriteLine($"\nPedido de {Cliente}:");
            foreach (var (producto, cantidad) in Productos)
            {
                Console.WriteLine($"- {producto.Nombre}: ${producto.Precio} x {cantidad} = ${producto.Precio * cantidad}");
            }
            Console.WriteLine($"Total: ${Total}");
        }

        // Actualizar
        public void ActualizarCantidadProducto(string nombreProducto, int nuevaCantidad)
        {
            var item = Productos.Find(p => p.Producto.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
            if (item.Producto != null)
            {
                var diferencia = nuevaCantidad - item.Cantidad;
                if (item.Producto.EstaDisponible(diferencia))
                {
                    item.Producto.ReducirInventario(diferencia);
                    Productos.Remove(item);
                    Productos.Add((item.Producto, nuevaCantidad));
                    Total += item.Producto.Precio * diferencia;
                    Console.WriteLine($"Cantidad del producto {nombreProducto} actualizada.");
                }
                else
                {
                    Console.WriteLine("No hay suficiente inventario para ajustar la cantidad.");
                }
            }
            else
            {
                Console.WriteLine($"Producto {nombreProducto} no encontrado en el pedido.");
            }
        }

        // Eliminar
        public void EliminarProducto(string nombreProducto)
        {
            var item = Productos.Find(p => p.Producto.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
            if (item.Producto != null)
            {
                Productos.Remove(item);
                Total -= item.Producto.Precio * item.Cantidad;
                item.Producto.CantidadDisponible += item.Cantidad;
                Console.WriteLine($"Producto {nombreProducto} eliminado del pedido.");
            }
            else
            {
                Console.WriteLine($"Producto {nombreProducto} no encontrado en el pedido.");
            }
        }
    }
}
