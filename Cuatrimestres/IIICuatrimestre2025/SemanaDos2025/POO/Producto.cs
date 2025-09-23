using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class Producto
    {
        // Atributos
        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        //Constructor - constructores

        public Producto(string nombre, decimal precio, int cantidad)
        {
            Nombre = nombre;
            ValidarPrecio(precio);
            ValidarCantidad(cantidad);

        }

        // Métodos

        public string DetallesProducto()
        {

            return $"Nombre: {Nombre}, Precio: {Precio}, Cantidad: {Cantidad}";
            
        }

        public void ValidarPrecio(decimal precio)
        {
            if (precio < 0)
            {
               throw new ArgumentException("El precio debe ser un número positivo o cero.");
            }
            else 
            {
                Precio = precio;
            } 

        }

        public void ValidarCantidad(int cantidad)
        {
            if (cantidad < 0)
            {
                throw new ArgumentException("El precio debe ser un número positivo o cero.");
            }
            else
            {
                Cantidad = cantidad;
            }
        }

 
    }


}
