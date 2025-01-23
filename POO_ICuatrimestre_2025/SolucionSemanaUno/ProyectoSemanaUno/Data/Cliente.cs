using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSemanaUno.Data
{
    public class Cliente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public Cliente(string cedula, string nombre, string email) 
        { 
            Cedula = cedula;
            Nombre = nombre;
            Email = email;
        }

    }
}
