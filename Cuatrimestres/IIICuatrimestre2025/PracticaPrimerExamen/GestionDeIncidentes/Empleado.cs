using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeIncidentes
{
    public abstract class Empleado
    {
        private string nombre;
        private string id;
        protected string email;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Empleado(string nombre, string id, string email)
        {
            this.nombre = nombre;
            this.id = id;
            this.email = email;
        }

        public abstract void MostrarInformacion();
    }
}
