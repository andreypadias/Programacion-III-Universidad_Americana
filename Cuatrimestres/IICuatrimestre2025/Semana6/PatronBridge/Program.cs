// See https://aka.ms/new-console-template for more information


using PatronBridge.Implementations;
using PatronBridge.Interfaces;
using PatronBridge.Services;

IEnviarNotificacion servicioMicrosoft = new ServicioEmailMicrosoft();
IEnviarNotificacion servicioAWS = new ServicioSMS();

EnviarEmail enviarEmailCostaRica = new EnviarEmail(servicioMicrosoft);
enviarEmailCostaRica.EnviarNotificacion("Mensaje para enviar: Hola mundo", "andrey@aum.com");