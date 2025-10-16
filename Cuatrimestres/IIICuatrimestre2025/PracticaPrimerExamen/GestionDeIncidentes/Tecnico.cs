using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeIncidentes
{
    public class Tecnico : Empleado
    {
        private string especialidad;
        private bool disponible;

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public bool Disponible
        {
            get { return disponible; }
            set { disponible = value; }
        }

        public Tecnico(string nombre, string id, string email, string especialidad)
            : base(nombre, id, email)
        {
            this.especialidad = especialidad;
            this.disponible = true;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id} | Tecnico: {Nombre} | Especialidad: {Especialidad} | Disponible: {(Disponible ? "Si" : "No")}");
        }
    }
}
