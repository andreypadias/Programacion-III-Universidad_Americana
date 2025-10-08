using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public interface ICuentaBancaria
    {
        string ObtenerTipoCuenta();
        void Depositar(decimal monto);
        bool Retirar(decimal monto);
        decimal ObtenerSaldo();
        void MostrarInformacion();
        decimal CalcularIntereses();
    }
}
