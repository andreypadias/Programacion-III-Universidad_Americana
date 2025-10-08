using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class FabricaCuentaBancaria
    {
        public ICuentaBancaria CrearCuenta(TipoCuenta tipo, string numeroCuenta, decimal saldoInicial)
        {
            Console.WriteLine($"\n Procesando apertura de cuenta tipo {tipo}...");

            ICuentaBancaria cuenta = tipo switch
            {
                TipoCuenta.Ahorros => new CuentaAhorros(numeroCuenta, saldoInicial),
                TipoCuenta.Corriente => new CuentaCorriente(numeroCuenta, saldoInicial),
                TipoCuenta.Premium => new CuentaPremium(numeroCuenta, saldoInicial),
                TipoCuenta.Internacional => new CuentaInternacional(numeroCuenta, saldoInicial),
                _ => throw new ArgumentException($"Tipo de cuenta no válido: {tipo}")
            };

            Console.WriteLine($" {cuenta.ObtenerTipoCuenta()} creada exitosamente.");
            return cuenta;
        }

        public ICuentaBancaria CrearCuenta(string tipoCuenta, string numeroCuenta, decimal saldoInicial)
        {
            TipoCuenta tipo = tipoCuenta.ToLower() switch
            {
                "ahorros" => TipoCuenta.Ahorros,
                "corriente" => TipoCuenta.Corriente,
                "premium" => TipoCuenta.Premium,
                "internacional" => TipoCuenta.Internacional,
                _ => throw new ArgumentException($"Tipo de cuenta no reconocido: {tipoCuenta}")
            };

            return CrearCuenta(tipo, numeroCuenta, saldoInicial);
        }

        public void MostrarTiposDisponibles()
        {
            Console.WriteLine("\nTipos de cuenta disponibles:");
            Console.WriteLine("  1. Ahorros   - Genera intereses del 3% anual");
            Console.WriteLine("  2. Corriente - Permite sobregiro de $500");
            Console.WriteLine("  3. Premium   - Genera intereses del 5% + bonificaciones");
        }

    }
}
