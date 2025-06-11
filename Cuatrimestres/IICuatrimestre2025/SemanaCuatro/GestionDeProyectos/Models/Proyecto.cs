using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProyectos.Models
{
    public class Proyecto
    {
        //Atributos
        public int Id { get; set; }

        public string TituloProyecto { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaLimite { get; set; }

        public List<Tarea> Tareas { get; set; } = new List<Tarea>();

        //Asignar un director al proyecto

        //Constructor
        public Proyecto(string tituloProyecto, string descripcion, DateTime fechaLimite)
        {
            Id = GenerarID();
            TituloProyecto = tituloProyecto;
            Descripcion = descripcion;
            FechaLimite = fechaLimite;
        }

        //Metodos

        public int GenerarID()
        {
            //Logica para generar un ID unico
            Random random = new Random();
            int id = random.Next(1, 10000); // Genera un ID aleatorio entre 1 y 9999

            return id + DateTime.Now.Year; // Asegura que el ID sea unico al agregar el año actual
        }

        public void AgregarTarea(Tarea tarea)
        {
            Tareas.Add(tarea); // Agrega la tarea a la lista de tareas del proyecto
            Console.WriteLine("La tarea a sido agregada con exito");
        }
        public void EliminarTarea(int ID)
        {
            //Validar si la tarea existe antes de eliminarla
            if (!Tareas.Any(t => t.Id == ID))
            {
                Console.WriteLine("No se encontró una tarea con el ID especificado.");
                return;
            }
            else
            {
                //Eliminar la tarea
                Tareas.RemoveAll(t => t.Id == ID);
                Console.WriteLine("Tarea {0} eliminada. ", ID);
            }
        }

        public void MostrarTareas()
        {
            if (Tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas asignadas a este proyecto.");
                return;
            }

            Console.WriteLine("Tareas del proyecto {0}:", TituloProyecto);
            foreach (var tarea in Tareas)
            {
                Console.WriteLine("ID: {0}, Título: {1}, Descripción: {2}, Estado: {3}",
                                  tarea.Id, tarea.TituloTarea, tarea.DescripcionTarea, tarea.Estado);
            }
        }

        public void MostrarTarea()
        {

        }

        public void AsignarLiderProyecto(MiembroDeEquipo miembro)
        {
            // Lógica para asignar un líder al proyecto
            // Esto podría implicar seleccionar un miembro del equipo con un rol específico
            Console.WriteLine("Lider del proyecto asignado.");


        }
    }
}
