// See https://aka.ms/new-console-template for more information


using PatronBridge.Implementations;
using PatronBridge.Interfaces;
using PatronBridge.Services;

IEnviarNotificacion servicioEmail = new ServicioEmailMicrosoft();
IEnviarNotificacion servicioSMS = new ServicioSMS();

EnviarEmail enviarEmailCostaRica = new EnviarEmail(servicioEmail);
enviarEmailCostaRica.EnviarNotificacion("Mensaje para enviar: Hola mundo", "andrey@aum.com");