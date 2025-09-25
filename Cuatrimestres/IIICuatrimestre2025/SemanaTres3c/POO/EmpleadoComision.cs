using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class EmpleadoComision : Empleado, IContrato
    {
        public int VentasRealizadas { get; set; }

        public EmpleadoComision(string nombre, int id, decimal salarioBase,int ventas) : base(nombre, id, salarioBase)
        {
            VentasRealizadas = ventas;
        }

        public override decimal CalcularSalario()
        {
           return VentasRealizadas* 0.10m + SalarioBase;
        }

        public string MostrarContrato()
        {
            return "Este contrato solo se valida con HR";
        }
    }
}
