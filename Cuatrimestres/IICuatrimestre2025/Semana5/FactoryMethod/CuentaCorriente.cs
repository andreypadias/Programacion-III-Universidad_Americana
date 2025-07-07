using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class CuentaCorriente: ICuentaBancaria
    {
        public string ObtenerTipoCuenta()
        {
            return "Cuenta Corriente";
        }

        public decimal ObtenerSaldoMinimo()
        {
            return 1000.00m; // Saldo mínimo para una cuenta corriente
        }

        public decimal CalcularInteres(decimal saldo)
        {
            return saldo * 0.02m; // Interés del 2% anual
        }

        public void MostrarDetalles()
        {
            Console.WriteLine("Detalles de la Cuenta Corriente:");
            Console.WriteLine($"Tipo de Cuenta: {ObtenerTipoCuenta()}");
            Console.WriteLine($"Saldo Mínimo: {ObtenerSaldoMinimo()}");
        }
    
    
    }
}
