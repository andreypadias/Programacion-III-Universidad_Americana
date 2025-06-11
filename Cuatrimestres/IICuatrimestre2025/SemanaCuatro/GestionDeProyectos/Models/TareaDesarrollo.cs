using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProyectos.Models
{
    public class TareaDesarrollo : Tarea
    {
        //Atributos
        public string TipoDeLenguaje { get; set; }
        public TareaDesarrollo(string Titulo, string Descripcion) : base(Titulo, Descripcion)
        {

        }

        public override void ActualizarEstadoTarea()
        {
            Console.WriteLine("EL lider de proyecto ya aprobo este cambio? S/N");
            string respuesta = Console.ReadLine().ToUpper();

            if (respuesta == "SI")
            {
                //CAMBIAR ESTADO A FINALIZADO
            }
            else 
            {
                Console.WriteLine("No se puede cambiar el estado");
            }
        }
    }
}
