using PatronBridge.Abstractions;
using PatronBridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.Implementations
{
    public class EnviarSMS: Notificacion
    {
        public EnviarSMS(IEnviarNotificacion enviarNotificacion) : base(enviarNotificacion)
        {
        }

        public override void EnviarNotificacion(string mensaje, string destinatario)
        {
            _enviarNotificacion.EnviarNotificacionInterfaz(mensaje, destinatario);
            Console.WriteLine("SMS enviado con éxito.");
        }
    }
}
