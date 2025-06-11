using GestionDeProyectos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProyectos.Models
{
    internal class TareaPrueba : Tarea, IGestionarTarea
    {
        //Atributo
        public List<string> Bugs { get; set; }

        public TareaPrueba(string Titulo, string Descripcion) : base(Titulo, Descripcion)
        {

        }

        public override void ActualizarEstadoTarea()
        {
            Console.WriteLine("Estado actualizado");
        }

        public void GestionarTarea()
        {
            Console.WriteLine("La lista de errores encontrados es:");
            foreach (var item in Bugs) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
