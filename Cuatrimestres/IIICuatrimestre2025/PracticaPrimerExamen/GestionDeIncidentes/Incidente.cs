using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeIncidentes
{
    public class Incidente
    {
        private static int contadorId = 1;
        private int id;
        private string descripcion;
        private string categoria;
        private string estado;
        private Usuario usuario;
        private Tecnico tecnicoAsignado;

        public int Id
        {
            get { return id; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public Tecnico TecnicoAsignado
        {
            get { return tecnicoAsignado; }
            set { tecnicoAsignado = value; }
        }

        public Incidente(string descripcion, string categoria, Usuario usuario)
        {
            this.id = contadorId++;
            this.descripcion = descripcion;
            this.categoria = categoria;
            this.estado = "Abierto";
            this.usuario = usuario;
            this.tecnicoAsignado = null;
        }

        public void AsignarTecnico(Tecnico tecnico)
        {
            this.tecnicoAsignado = tecnico;
            this.estado = "En Proceso";
        }

        public void ActualizarEstado(string nuevoEstado)
        {
            this.estado = nuevoEstado;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"\n--- Incidente #{Id} ---");
            Console.WriteLine($"Descripcion: {Descripcion}");
            Console.WriteLine($"Categoria: {Categoria}");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine($"Usuario: {Usuario.Nombre} - {Usuario.Departamento}");
            if (TecnicoAsignado != null)
            {
                Console.WriteLine($"Tecnico Asignado: {TecnicoAsignado.Nombre} ({TecnicoAsignado.Especialidad})");
            }
            else
            {
                Console.WriteLine("Tecnico Asignado: Sin asignar");
            }
        }
    }
}
