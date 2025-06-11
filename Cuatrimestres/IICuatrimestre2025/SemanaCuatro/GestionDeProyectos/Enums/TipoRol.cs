using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProyectos.Enums
{
    public enum TipoRol
    {
        Administrador, // Rol con permisos completos para gestionar el proyecto
        Desarrollador, // Rol encargado de desarrollar las tareas asignadas
        Tester,       // Rol encargado de probar y verificar las tareas completadas
        Diseñador     // Rol encargado del diseño y la interfaz del proyecto
    }
}
