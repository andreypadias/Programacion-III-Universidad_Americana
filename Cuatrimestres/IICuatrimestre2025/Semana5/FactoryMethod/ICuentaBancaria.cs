﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public interface ICuentaBancaria
    {
        string ObtenerTipoCuenta();
        decimal ObtenerSaldoMinimo();
        decimal CalcularInteres(decimal saldo);
        void MostrarDetalles();

    }
}
