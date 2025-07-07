using PatronBridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronBridge.Services
{
    public class ServicioSMS: IEnviarNotificacion
    {
        public void EnviarNotificacionInterfaz(string mensaje, string destinatario)
        {
            Console.WriteLine("SMS enviado por el servicio de Kolbi. \n Mensaje:{0} \n Destinatario: {1}", mensaje, destinatario);
        }
    }
    
    
}
