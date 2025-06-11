using GestionDeProyectos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProyectos.Menus
{
    public class Menu
    {
        //Atributos

        private List<Proyecto> Proyectos = new List<Proyecto>();

        public void MostrarMenu() 
        {
            try
            {
                bool controlMenu = true;
                do
                {
                    Console.WriteLine("****Bienvenido al sistema gestor de proyectos****");
                    Console.WriteLine("1. Crear Proyecto");
                    Console.WriteLine("2. Ver Proyectos");
                    Console.WriteLine("3. Administrar Tareas");
                    Console.WriteLine("4. Salir");

                    Console.Write("Seleccione una opcion: ");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            CrearProyecto();
                            break;
                        case 2:
                            VerProyectos();
                            break;
                        case 3:
                            AdministrarTareas();
                            break;
                        case 4:
                            controlMenu=Salir();
                            break;
                        default:
                            Console.WriteLine("Opcion no valida, por favor intente de nuevo.");
                            break;

                    }

                } while (controlMenu);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ha ocurrido el siguiente error: "+ex.Message);
            }
           
            
        }

        private void CrearProyecto() 
        {
            Console.WriteLine("Indique nombre del proyecto:");
            string tituloProyecto = Console.ReadLine();
            Console.WriteLine("Indique descripcion del proyecto:");
            string descripcion = Console.ReadLine();
            Console.WriteLine("Indique fecha limite del proyecto (dd/mm/yyyy):");
            DateTime fechaLimite;
            while (!DateTime.TryParse(Console.ReadLine(), out fechaLimite))
            {
                Console.WriteLine("Fecha invalida, por favor ingrese una fecha valida (dd/mm/yyyy):");
            }
            Proyecto nuevoProyecto = new Proyecto(tituloProyecto, descripcion, fechaLimite);
            Proyectos.Add(nuevoProyecto); // Agregar el nuevo proyecto a la lista de proyectos
            Console.WriteLine("Proyecto creado exitosamente con ID: " + nuevoProyecto.Id);

        }

        private void VerProyectos()
        {
            //Mostrar todos los proyectos de la lista
            if (Proyectos.Count == 0)
            {
                Console.WriteLine("No hay proyectos disponibles.");
                return;
            }
            Console.WriteLine("Proyectos disponibles:");
            foreach (var proyecto in Proyectos)
            {
                Console.WriteLine("ID: {0}, Título: {1}, Descripción: {2}, Fecha Límite: {3}",
                                  proyecto.Id, proyecto.TituloProyecto, proyecto.Descripcion, proyecto.FechaLimite.ToShortDateString());
            }
        }

        private void AdministrarTareas()
        {
            //Administrar tareas de un proyecto especifico
            Console.WriteLine("Ingrese el ID del proyecto para administrar sus tareas:");
            int idProyecto;
            while (!int.TryParse(Console.ReadLine(), out idProyecto) || !Proyectos.Any(p => p.Id == idProyecto))
            {
                Console.WriteLine("ID invalido, por favor ingrese un ID valido:");
            }

            Proyecto proyectoSeleccionado = Proyectos.FirstOrDefault(p => p.Id == idProyecto);
            if (proyectoSeleccionado != null)
            {
                // Lógica para administrar las tareas del proyecto seleccionado
                Console.WriteLine("Administrando tareas del proyecto: " + proyectoSeleccionado.TituloProyecto);

                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Eliminar Tarea");
                Console.WriteLine("3. Ver Tareas");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                int opcionTarea;
                while (!int.TryParse(Console.ReadLine(), out opcionTarea) || opcionTarea < 1 || opcionTarea > 4)
                {
                    Console.WriteLine("Opción inválida, por favor intente de nuevo:");
                }
                //Logica para agregar tareas
                //Logica para eliminar tareas
                switch (opcionTarea)
                {
                    case 1:
                        Console.WriteLine("Ingrese el título de la tarea:");
                        string tituloTarea = Console.ReadLine();
                        Console.WriteLine("Ingrese la descripción de la tarea:");
                        string descripcionTarea = Console.ReadLine();
                        Tarea nuevaTarea = new TareaDesarrollo(tituloTarea, descripcionTarea);
                        proyectoSeleccionado.AgregarTarea(nuevaTarea);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el ID de la tarea a eliminar:");
                        int idTarea;
                        while (!int.TryParse(Console.ReadLine(), out idTarea) || !proyectoSeleccionado.Tareas.Any(t => t.Id == idTarea))
                        {
                            Console.WriteLine("ID de tarea inválido, por favor intente de nuevo:");
                        }
                        proyectoSeleccionado.EliminarTarea(idTarea);
                        break;
                    case 3:
                        proyectoSeleccionado.MostrarTareas();
                        break;
                    case 4:
                        Console.WriteLine("Volviendo al menú principal...");
                        return; // Volver al menú principal
                }
            }
        }

        public bool Salir() 
        {
            Console.WriteLine("Desea salir? SI/NO");
            string respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "SI")
            {
                Console.WriteLine("Gracias por usar el sistema gestor de proyectos. ¡Hasta luego!");
                return false; // Salir del menú
            }
            else if (respuesta == "NO")
            {
                Console.WriteLine("Regresando al menú principal...");
                return true; // Volver al menú
            }
            else
            {
                Console.WriteLine("Respuesta no válida, regresando al menú principal...");
                return true; // Volver al menú
            }

        }

    }
}
