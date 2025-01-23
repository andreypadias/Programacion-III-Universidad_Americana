using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSemanaUno.Data
{
    public class ProductoElectronico : Producto
    {
        public ProductoElectronico(string nombre, decimal precio, int cantidadDisponible)
            : base(nombre, "Electrónica", precio, cantidadDisponible) { }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"Electrónica - {Nombre}: ${Precio} ({CantidadDisponible} disponibles)");
        }
    }
}
