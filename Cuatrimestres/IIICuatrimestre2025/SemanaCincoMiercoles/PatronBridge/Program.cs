// See https://aka.ms/new-console-template for more information
using PatronBridge.AbstraccionesRefinadas;
using PatronBridge.Implementador;
using PatronBridge.ImplementadoresAbstractos;



IProveedorMensajeria proveedorGoogle = new ProveedorGoogle();
IProveedorMensajeria proveedorAWS = new ProveedorAWS();
IProveedorMensajeria proveedorRACSA = new ProveedorRACSA();

NotificacionEmail notificacionEmail = new NotificacionEmail(proveedorRACSA);
notificacionEmail.Enviar("andrey@gmail.es");