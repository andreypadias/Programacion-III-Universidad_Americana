using GestionDeProyectos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProyectos.Models
{
    public abstract class  Tarea
    {
        //Atributos
        public int Id { get; set; }

        public string TituloTarea { get; set; }

        public string DescripcionTarea { get; set; }

        public EstadoTarea Estado { get; set; }

        private MiembroDeEquipo MiembroAsignado = null; // Miembro asignado a la tarea, inicialmente nulo

        //Constructor

        public Tarea(string Titulo, string Descripcion)
        {
            TituloTarea = Titulo;
            DescripcionTarea = Descripcion;
            Estado = EstadoTarea.Pendiente; // Por defecto, una tarea nueva está pendiente

        }

        public void AsignarMiembro(MiembroDeEquipo miembroDeEquipo)
        {
            MiembroAsignado = miembroDeEquipo; // Asignar el miembro de equipo a la tarea
            Console.WriteLine("Miembro Asignado. {0} esta a cargo de esta tarea.", miembroDeEquipo.Nombre);
        }

        //Crear Metodo para generar ID unico segun fecha y hora de creacion

        public abstract void ActualizarEstadoTarea();
    }
}
