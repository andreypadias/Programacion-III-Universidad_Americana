using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public class EmpleadoHora : Empleado
    {
        public int HorasTrabajadas { get; set; }
        public EmpleadoHora(string nombre, int id, decimal salarioBase) : base(nombre, id, salarioBase)
        {

        }

        public override decimal CalcularSalario()
        {
            return HorasTrabajadas + SalarioBase;
        }


    }
}
