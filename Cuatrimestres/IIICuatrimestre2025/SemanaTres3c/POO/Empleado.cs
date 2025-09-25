using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public abstract class Empleado
    {
        //Atributos
        public string Nombre { get; set; }
        public int Id { get; set; }
        public decimal SalarioBase { get; set; }

        //Constructor
        public Empleado(string nombre, int id, decimal salarioBase)
        {
            Nombre = nombre;
            Id = id;
            SalarioBase = salarioBase;
        }

        //Metodo para calcular salario
        public abstract decimal CalcularSalario();

        //Metodo para mostrar informacion
        public void MostrarDetalles()
        {
            Console.WriteLine($"ID: {Id}, Nombre: {Nombre}, Salario Base: {SalarioBase:C}");
        }

       
    }
}
