using PatronBridge.Implementador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.ImplementadoresAbstractos
{
    public class ProveedorGoogle : IProveedorMensajeria
    {
        public void EnviarMensaje(string destinatario, string mensaje)
        {
            Console.WriteLine($"[Utilizando servicios de - Google] Enviando a: {destinatario}");
            Console.WriteLine($"Contenido: {mensaje}");
            Console.WriteLine($"Estado: Email enviado exitosamente\n");
        }
    }
}
