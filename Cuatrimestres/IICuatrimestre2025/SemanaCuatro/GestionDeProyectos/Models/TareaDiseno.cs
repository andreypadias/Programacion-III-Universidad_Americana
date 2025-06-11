using GestionDeProyectos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProyectos.Models
{
    public class TareaDiseno : Tarea,IGestionarTarea
    {
        //Atributos
        public string URLservidor { get; set; }

        public TareaDiseno(string Titulo, string Descripcion) : base(Titulo, Descripcion)
        {
        }

        public override void ActualizarEstadoTarea()
        {
            Console.WriteLine("El estado se va actualizar en la proxima reunion.");
        }

        public void GestionarTarea()
        {
            Console.WriteLine("Servidor donde se alojaron los disenos: " + URLservidor);
        }
    }
}
