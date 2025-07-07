using PatronBridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.Services
{
    public class ServicioEmail : IEnviarNotificacion
    {
        public void EnviarNotificacionInterfaz(string mensaje, string destinatario)
        {
            Console.WriteLine("Email enviado por el servicio de Google. \n Mensaje:{0} \n Destinatario: {1}", mensaje, destinatario);
        }
    }
}
