using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeIncidentes
{
    public class Administrador : Empleado
    {
        public Administrador(string nombre, string id, string email)
            : base(nombre, id, email)
        {
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"Administrador: {Nombre} | ID: {Id}");
        }

        public void GenerarReporte(List<Incidente> incidentes)
        {
            Console.WriteLine("\n===== REPORTE DE INCIDENTES =====");

            int abiertos = 0;
            int enProceso = 0;
            int resueltos = 0;
            int cerrados = 0;

            for (int i = 0; i < incidentes.Count; i++)
            {
                if (incidentes[i].Estado == "Abierto")
                    abiertos++;
                else if (incidentes[i].Estado == "En Proceso")
                    enProceso++;
                else if (incidentes[i].Estado == "Resuelto")
                    resueltos++;
                else if (incidentes[i].Estado == "Cerrado")
                    cerrados++;
            }

            Console.WriteLine($"Total de Incidentes: {incidentes.Count}");
            Console.WriteLine($"Abiertos: {abiertos}");
            Console.WriteLine($"En Proceso: {enProceso}");
            Console.WriteLine($"Resueltos: {resueltos}");
            Console.WriteLine($"Cerrados: {cerrados}");
        }
    }
}
