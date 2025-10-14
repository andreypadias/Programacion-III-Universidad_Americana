// See https://aka.ms/new-console-template for more information


using ChainOfResponsability;

Aprobador supervisor = new Supervisor();
Aprobador gerente = new Gerente();
Aprobador director = new Director();
Aprobador vicepresidente = new VicePresidente();

//Establecer la cadena de responsabilidad

supervisor.EstablecerSiguiente(gerente);
gerente.EstablecerSiguiente(director);
director.EstablecerSiguiente(vicepresidente);

SolicitudCompra solicitud1 = new SolicitudCompra("Equipo de computo", 18000, "ANA");

supervisor.ProcesarSolicitud(solicitud1);
