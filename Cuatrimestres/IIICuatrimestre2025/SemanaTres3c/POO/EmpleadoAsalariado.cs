using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class EmpleadoAsalariado : Empleado,IContrato
    {
        
        public EmpleadoAsalariado(string nombre, int id, decimal salarioBase) : base(nombre, id, salarioBase)
        {

        }

        public override decimal CalcularSalario()
        {
            return SalarioBase;
        }

        public string MostrarContrato()
        {
            return "Contrato es: ...";
        }
    }
}
