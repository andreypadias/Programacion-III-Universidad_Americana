using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeIncidentes
{
    public class Usuario
    {
        private string nombre;
        private string id;
        private string departamento;

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

        public string Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public Usuario(string nombre, string id, string departamento)
        {
            this.nombre = nombre;
            this.id = id;
            this.departamento = departamento;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Usuario: {Nombre} | Departamento: {Departamento}");
        }
    }
}
