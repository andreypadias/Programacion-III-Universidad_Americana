using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class FabricaCuentaBancaria
    {
        public ICuentaBancaria CrearCuenta()
        {
            Console.WriteLine("Seleccione el tipo de cuenta bancaria:");
            Console.WriteLine("1. Cuenta Corriente");
            Console.WriteLine("2. Cuenta de Ahorro");
            Console.Write("Ingrese su opción (1 o 2): ");
            string opcion = Console.ReadLine();

            ICuentaBancaria cuenta;

            switch (opcion)
            {
                case "1":
                    cuenta = new CuentaCorriente();
                    break;
                case "2":
                    cuenta = new CuentaAhorro();
                    break;
                default:
                    throw new ArgumentException("Opción no válida. Debe ser 1 o 2.");
            }

            cuenta.MostrarDetalles();
            return cuenta;
        }
    }
}
