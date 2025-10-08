using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class CuentaCorriente : ICuentaBancaria
    {
        private decimal saldo;
        private readonly string numeroCuenta;
        private readonly decimal sobregiro;
        private readonly decimal comisionMantenimiento = 5.00m;

        public CuentaCorriente(string numeroCuenta, decimal saldoInicial = 0, decimal sobregiro = 500m)
        {
            this.numeroCuenta = numeroCuenta;
            this.saldo = saldoInicial;
            this.sobregiro = sobregiro;
        }

        public string ObtenerTipoCuenta() => "Cuenta Corriente";

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
            if (monto <= saldo + sobregiro)
            {
                saldo -= monto;
                Console.WriteLine($"Retiro exitoso: ${monto:N2}");
                if (saldo < 0)
                    Console.WriteLine($"ADVERTENCIA: Usando sobregiro. Saldo negativo: ${saldo:N2}");
                return true;
            }
            Console.WriteLine("Excede el límite de sobregiro disponible.");
            return false;
        }

        public decimal ObtenerSaldo() => saldo;

        public decimal CalcularIntereses()
        {
            return 0; // Las cuentas corrientes no generan intereses
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"\n--- {ObtenerTipoCuenta()} ---");
            Console.WriteLine($"Número: {numeroCuenta}");
            Console.WriteLine($"Saldo: ${saldo:N2}");
            Console.WriteLine($"Sobregiro disponible: ${sobregiro:N2}");
            Console.WriteLine($"Comisión mensual: ${comisionMantenimiento:N2}");
            Console.WriteLine($"Saldo disponible total: ${saldo + sobregiro:N2}");
        }
    }
}
