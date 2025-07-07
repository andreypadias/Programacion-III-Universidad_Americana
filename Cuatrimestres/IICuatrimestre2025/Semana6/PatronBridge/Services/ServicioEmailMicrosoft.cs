using PatronBridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.Services
{
    public class ServicioEmailMicrosoft : IEnviarNotificacion
    {
        public void EnviarNotificacionInterfaz(string mensaje, string destinatario)
        {
            Console.WriteLine("Servicio de Microsoft. \n Mensaje: {0} \n Destinatario:{1}",mensaje,destinatario);
        }
    }
}
