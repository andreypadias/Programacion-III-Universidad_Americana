using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoSemanaUno.Data
{
    public class Inventario
    {
        //Atributo
        public List<Producto> productos = new List<Producto>();

        // Crear
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
            Console.WriteLine("Producto agregado al inventario.");
        }

        // Leer
        public void MostrarTodosLosProductos() 
        {
            Console.WriteLine("Lista de productos en inventario:");
            foreach (var producto in productos)
            {
                producto.MostrarInformacion();
            }
        }
        public void MostrarProductosPorCategoria(string categoria)
        {
            Console.WriteLine($"\nProductos en la categoría {categoria}:");
            foreach (var producto in productos.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)))
            {
                producto.MostrarInformacion();
            }
        }

        // Actualizar
        public void ActualizarProducto(string nombre, decimal nuevoPrecio, int nuevaCantidad)
        {
            var producto = productos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                producto.CantidadDisponible = nuevaCantidad;
                Console.WriteLine($"Producto {nombre} actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine($"Producto {nombre} no encontrado.");
            }
        }

        // Eliminar
        public void EliminarProducto(string nombre)
        {
            var producto = productos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"Producto {nombre} eliminado del inventario.");
            }
            else
            {
                Console.WriteLine($"Producto {nombre} no encontrado.");
            }
        }

        public Producto BuscarProducto(string nombre)
        {
            return productos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}
