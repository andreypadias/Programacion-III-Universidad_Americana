using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSemanaUno.Data
{
    public class ProductoModa : Producto
    {
        public ProductoModa(string nombre, decimal precio, int cantidadDisponible)
            : base(nombre, "Moda", precio, cantidadDisponible) { }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"Moda - {Nombre}: ${Precio} ({CantidadDisponible} disponibles)");
        }
    }
}
