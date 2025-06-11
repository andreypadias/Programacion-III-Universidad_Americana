using GestionDeProyectos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProyectos.Models
{
    public class MiembroDeEquipo
    {
        //Atributos

        public string Id { get; set; }

        public string Nombre { get; set; }

        public string CorreoElectronico { get; set; }

        public TipoRol Rol { get; set; }

        //Constructor
        public MiembroDeEquipo(string cedula, string nombre, string correo, int rol)
        {
            Id = cedula;
            Nombre = nombre;
            CorreoElectronico = correo;
            ProcesadorRol(rol);
        }

        private void ProcesadorRol(int rol) 
        {
            if (!Enum.IsDefined(typeof(TipoRol), rol)) 
            {
                Console.WriteLine("No hay un rol asignado a este numero.");
                return;
            }

            TipoRol rolSeleccionado = (TipoRol)rol;

            switch (rolSeleccionado) 
            { 
                case TipoRol.Administrador:
                    Console.WriteLine("El rol asignado es Administrador.");
                    this.Rol = TipoRol.Administrador; // Asignar el rol al miembro del equipo
                    break;

                case TipoRol.Desarrollador:
                    Console.WriteLine("El rol asignado es Desarrollador.");
                    this.Rol = TipoRol.Desarrollador; // Asignar el rol al miembro del equipo
                    break;
                case TipoRol.Tester:
                    Console.WriteLine("El rol asignado es Tester.");
                    this.Rol = TipoRol.Tester; // Asignar el rol al miembro del equipo
                    break;
                case TipoRol.Diseñador:
                    Console.WriteLine("El rol asignado es Diseñador.");
                    this.Rol = TipoRol.Diseñador; // Asignar el rol al miembro del equipo
                    break;
            }

        }

    }
}
