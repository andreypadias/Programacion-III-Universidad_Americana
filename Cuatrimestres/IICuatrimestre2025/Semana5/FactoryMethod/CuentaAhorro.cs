using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class CuentaAhorro : ICuentaBancaria
    {
        public string ObtenerTipoCuenta()
        {
            return "Cuenta de Ahorro";
        }

        public decimal ObtenerSaldoMinimo()
        {
            return 500.00m; // Saldo mínimo para una cuenta de ahorro
        }

        public decimal CalcularInteres(decimal saldo)
        {
            return saldo * 0.03m; // Interés del 3% anual
        }

        public void MostrarDetalles()
        {
            Console.WriteLine("Detalles de la Cuenta de Ahorro:");
            Console.WriteLine($"Tipo de Cuenta: {ObtenerTipoCuenta()}");
            Console.WriteLine($"Saldo Mínimo: {ObtenerSaldoMinimo()}");
        }
    }
    
}
