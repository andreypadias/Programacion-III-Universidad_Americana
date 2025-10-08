using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class CuentaAhorros : ICuentaBancaria
    {
        private decimal saldo;
        private readonly string numeroCuenta;
        private readonly decimal tasaInteres = 0.03m; // 3% anual
        private readonly int retirosGratis = 3;
        private int retirosRealizados = 0;

        public CuentaAhorros(string numeroCuenta, decimal saldoInicial = 0)
        {
            this.numeroCuenta = numeroCuenta;
            this.saldo = saldoInicial;
        }

        public string ObtenerTipoCuenta() => "Cuenta de Ahorros";

        public void Depositar(decimal monto)
        {
            if (monto > 0)
            {
                saldo += monto;
                Console.WriteLine($"Depósito exitoso: ${monto:N2}");
            }
        }

        public bool Retirar(decimal monto)
        {
            decimal comision = retirosRealizados >= retirosGratis ? 2.00m : 0;
            decimal totalRetiro = monto + comision;

            if (totalRetiro <= saldo)
            {
                saldo -= totalRetiro;
                retirosRealizados++;
                Console.WriteLine($"Retiro exitoso: ${monto:N2}");
                if (comision > 0)
                    Console.WriteLine($"Comisión aplicada: ${comision:N2}");
                return true;
            }
            Console.WriteLine("Saldo insuficiente para realizar el retiro.");
            return false;
        }

        public decimal ObtenerSaldo() => saldo;

        public decimal CalcularIntereses()
        {
            return saldo * tasaInteres;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"\n--- {ObtenerTipoCuenta()} ---");
            Console.WriteLine($"Número: {numeroCuenta}");
            Console.WriteLine($"Saldo: ${saldo:N2}");
            Console.WriteLine($"Tasa de interés: {tasaInteres * 100}%");
            Console.WriteLine($"Retiros realizados: {retirosRealizados}");
            Console.WriteLine($"Intereses generados: ${CalcularIntereses():N2}");
        }
    }
}
