using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class CuentaInternacional: ICuentaBancaria
    {


        private decimal saldo;
        private readonly string numeroCuenta;
        private readonly decimal tasaInteres = 0.02m; // 5% anual
        private readonly decimal bonificacion = 0.09m; // 1% adicional

        public CuentaInternacional(string numeroCuenta, decimal saldoInicial = 0)
        {
            this.numeroCuenta = numeroCuenta;
            this.saldo = saldoInicial;
        }

        public string ObtenerTipoCuenta() => "Cuenta Internacional";

        public void Depositar(decimal monto)
        {
            if (monto > 0)
            {
                decimal bonus = monto * bonificacion;
                saldo += monto + bonus;
                Console.WriteLine($"Depósito exitoso: ${monto:N2}");
                Console.WriteLine($"Bonificación Premium: ${bonus:N2}");
            }
        }

        public bool Retirar(decimal monto)
        {
            if (monto <= saldo)
            {
                saldo -= monto;
                Console.WriteLine($"Retiro exitoso: ${monto:N2} (Sin comisiones)");
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
            Console.WriteLine($"Bonificación por depósito: {bonificacion * 100}%");
            Console.WriteLine($"Intereses generados: ${CalcularIntereses():N2}");
        }
    }
}
