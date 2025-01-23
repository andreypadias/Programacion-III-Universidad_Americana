using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSemanaUno.Data
{
    public class ProductoHogar : Producto
    {
        public ProductoHogar(string nombre, decimal precio, int cantidadDisponible)
            : base(nombre, "Hogar", precio, cantidadDisponible) { }

        public override void MostrarInformacion()
        {
            /*Console.WriteLine("Hogar - "+Nombre+Precio+CantidadDisponible);
            Console.WriteLine("Hogar - Cantidad{0} Nombre:{1} Precio {2}",CantidadDisponible, Nombre, Precio);
            */
            Console.WriteLine($"Hogar - {Nombre}: ${Precio} ({CantidadDisponible} disponibles)");
        }
    }

  

    
}
