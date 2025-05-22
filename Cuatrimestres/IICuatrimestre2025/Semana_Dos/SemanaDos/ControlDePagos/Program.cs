using ControlDePagos;

bool opcionMenu = true;

//Lista de clientes
List<Cliente> clientes = new List<Cliente>(); 
do
{
    //Lista
    Console.WriteLine("****Menu de control de clientes****");
    Console.WriteLine("1 - Crear cliente");
    Console.WriteLine("2 - Consultar deuda cliente");
    Console.WriteLine("3 - Ver todos los clientes");
    Console.WriteLine("4 - Abonar deuda");
    Console.WriteLine("5 - Salir");
    Console.WriteLine("Seleccione una opcion");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1": 

                Console.WriteLine("Creando Cliente");
                Console.WriteLine("Ingrese la cedula del cliente");
                string cedula = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del cliente");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el telefono del cliente");
                string telefono = Console.ReadLine();
                Cliente cliente = new Cliente(cedula, nombre, telefono);
                Console.WriteLine("Cliente creado con exito");
                clientes.Add(cliente);
           
                break;
        case "2":
                Console.WriteLine("Consultando deuda cliente:");
                string cedulaConsulta = Console.ReadLine();
                Cliente clienteConsulta = clientes.Find(c => c.Cedula == cedulaConsulta);
                Console.WriteLine(clienteConsulta.VerDeuda);

                /*foreach (Cliente clienteConsulta in clientes) 
                {
                    if (cedulaConsulta == clienteConsulta.Cedula) 
                    {
                        Console.WriteLine(clienteConsulta.VerDeuda());
                    }
               
                }*/

                /*for (int i=0;i<clientes.Count;i++) 
                {
                    Cliente clienteConsulta = clientes[i];  
                    if (cedulaConsulta == clienteConsulta.Cedula) 
                    {
                        clienteConsulta.VerDeuda();
                    }
                }*/

                break;
        case "3":
                Console.WriteLine("Clientes:");
                foreach (Cliente clienteTemporal in clientes)
                {
                    Console.WriteLine(clienteTemporal.Nombre);
                }
                break;
        case "4":
                Console.WriteLine("Abonando deuda cliente:");
                string cedConsulta = Console.ReadLine();
                Console.WriteLine("Ingrese el monto a abonar");
                double montoAbono = double.Parse(Console.ReadLine());
                Cliente clienteAbono = clientes.Find(c => c.Cedula == cedConsulta);
                clienteAbono.AbonarDeuda(montoAbono);
                break;
        case "5":
                Console.WriteLine("Saliendo del sistema!");
                opcionMenu = false;
                break;

        default: Console.WriteLine("Seleccione una opcion del 1 al 5.");
                break;
    }

}
while (opcionMenu);



