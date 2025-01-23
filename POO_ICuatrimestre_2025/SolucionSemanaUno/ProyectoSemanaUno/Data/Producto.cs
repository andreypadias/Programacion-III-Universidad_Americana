using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSemanaUno.Data
{
    public abstract class Producto
    {
        //Atributos
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int CantidadDisponible { get; set; }

        //Constructor
        public Producto(string nombre, string categoria, decimal precio, int cantidadDisponible)
        {
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
            CantidadDisponible = cantidadDisponible;
        }

        public abstract void MostrarInformacion();

        public bool EstaDisponible(int cantidad)
        {
            return CantidadDisponible >= cantidad;
        }

        public void ReducirInventario(int cantidad)
        {
            if (EstaDisponible(cantidad))
            {
                
                CantidadDisponible -= cantidad;
            }
            else
            {
                throw new InvalidOperationException("Inventario insuficiente.");
            }
        }
    }
}
