using GestionDeIncidentes;

 List<Incidente> incidentes = new List<Incidente>();
 List<Tecnico> tecnicos = new List<Tecnico>();
 List<Usuario> usuarios = new List<Usuario>();

    InicializarDatos();

    int opcion = 0;

    do
    {
        try
        {
            MostrarMenuPrincipal();
            Console.Write("Seleccione una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarIncidente();
                    break;
                case 2:
                    AsignarTecnicoAIncidente();
                    break;
                case 3:
                    ActualizarEstadoIncidente();
                    break;
                case 4:
                    MostrarIncidentes();
                    break;
                case 5:
                    GenerarReporte();
                    break;
                case 6:
                    MostrarTecnicos();
                    break;
                case 7:
                    Console.WriteLine("\nSaliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("\nOpcion no valida. Intente nuevamente.");
                    break;
            }

            if (opcion != 7)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Debe ingresar un numero valido.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError inesperado: {ex.Message}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

    } while (opcion != 7);


 void InicializarDatos()
{
    // Crear tecnicos
    tecnicos.Add(new Tecnico("Juan Perez", "T001", "juan@empresa.com", "Hardware"));
    tecnicos.Add(new Tecnico("Maria Lopez", "T002", "maria@empresa.com", "Software"));
    tecnicos.Add(new Tecnico("Carlos Ruiz", "T003", "carlos@empresa.com", "Redes"));
    tecnicos.Add(new Tecnico("Ana Torres", "T004", "ana@empresa.com", "Hardware"));

    // Crear usuarios
    usuarios.Add(new Usuario("Pedro Gomez", "U001", "Ventas"));
    usuarios.Add(new Usuario("Laura Martinez", "U002", "Contabilidad"));
    usuarios.Add(new Usuario("Roberto Silva", "U003", "Recursos Humanos"));
}

static void MostrarMenuPrincipal()
{
    Console.Clear();
    Console.WriteLine("========================================");
    Console.WriteLine("   SISTEMA DE GESTION DE INCIDENTES");
    Console.WriteLine("========================================");
    Console.WriteLine("1. Registrar nuevo incidente");
    Console.WriteLine("2. Asignar tecnico a incidente");
    Console.WriteLine("3. Actualizar estado de incidente");
    Console.WriteLine("4. Ver todos los incidentes");
    Console.WriteLine("5. Generar reporte");
    Console.WriteLine("6. Ver tecnicos disponibles");
    Console.WriteLine("7. Salir");
    Console.WriteLine("========================================");
}

 void RegistrarIncidente()
{
    try
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR NUEVO INCIDENTE ===\n");

        // Mostrar usuarios disponibles
        Console.WriteLine("Usuarios disponibles:");
        for (int i = 0; i < usuarios.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {usuarios[i].Nombre} - {usuarios[i].Departamento}");
        }

        Console.Write("\nSeleccione el numero de usuario: ");
        int numUsuario = int.Parse(Console.ReadLine());

        if (numUsuario < 1 || numUsuario > usuarios.Count)
        {
            Console.WriteLine("Usuario no valido.");
            return;
        }

        Usuario usuarioSeleccionado = usuarios[numUsuario - 1];

        Console.Write("\nDescripcion del incidente: ");
        string descripcion = Console.ReadLine();

        Console.WriteLine("\nCategorias disponibles:");
        Console.WriteLine("1. Hardware");
        Console.WriteLine("2. Software");
        Console.WriteLine("3. Redes");
        Console.WriteLine("4. Instalacion");
        Console.Write("Seleccione la categoria: ");
        int catNum = int.Parse(Console.ReadLine());

        string categoria = "";
        switch (catNum)
        {
            case 1:
                categoria = "Hardware";
                break;
            case 2:
                categoria = "Software";
                break;
            case 3:
                categoria = "Redes";
                break;
            case 4:
                categoria = "Instalacion";
                break;
            default:
                categoria = "Otros";
                break;
        }

        Incidente nuevoIncidente = new Incidente(descripcion, categoria, usuarioSeleccionado);
        incidentes.Add(nuevoIncidente);

        Console.WriteLine($"\nIncidente #{nuevoIncidente.Id} registrado exitosamente!");
    }
    catch (FormatException)
    {
        Console.WriteLine("\nError: Debe ingresar numeros validos.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError al registrar incidente: {ex.Message}");
    }
}

     void AsignarTecnicoAIncidente()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("=== ASIGNAR TECNICO A INCIDENTE ===\n");

            if (incidentes.Count == 0)
            {
                Console.WriteLine("No hay incidentes registrados.");
                return;
            }

            // Mostrar incidentes sin asignar
            Console.WriteLine("Incidentes sin asignar:");
            bool hayIncidentesSinAsignar = false;

            for (int i = 0; i < incidentes.Count; i++)
            {
                if (incidentes[i].TecnicoAsignado == null)
                {
                    Console.WriteLine($"ID: {incidentes[i].Id} | {incidentes[i].Descripcion} | Categoria: {incidentes[i].Categoria}");
                    hayIncidentesSinAsignar = true;
                }
            }

            if (!hayIncidentesSinAsignar)
            {
                Console.WriteLine("Todos los incidentes tienen tecnico asignado.");
                return;
            }

            Console.Write("\nIngrese el ID del incidente: ");
            int idIncidente = int.Parse(Console.ReadLine());

            Incidente incidente = null;
            for (int i = 0; i < incidentes.Count; i++)
            {
                if (incidentes[i].Id == idIncidente)
                {
                    incidente = incidentes[i];
                    break;
                }
            }

            if (incidente == null)
            {
                Console.WriteLine("Incidente no encontrado.");
                return;
            }

            if (incidente.TecnicoAsignado != null)
            {
                Console.WriteLine("Este incidente ya tiene un tecnico asignado.");
                return;
            }

            // Mostrar tecnicos disponibles con la especialidad adecuada
            Console.WriteLine($"\nTecnicos disponibles para categoria '{incidente.Categoria}':");
            bool hayTecnicosDisponibles = false;

            for (int i = 0; i < tecnicos.Count; i++)
            {
                if (tecnicos[i].Disponible && tecnicos[i].Especialidad == incidente.Categoria)
                {
                    Console.WriteLine($"{i + 1}. {tecnicos[i].Nombre} - {tecnicos[i].Especialidad}");
                    hayTecnicosDisponibles = true;
                }
            }

            if (!hayTecnicosDisponibles)
            {
                Console.WriteLine("No hay tecnicos disponibles con esa especialidad.");
                return;
            }

            Console.Write("\nSeleccione el numero del tecnico: ");
            int numTecnico = int.Parse(Console.ReadLine());

            if (numTecnico < 1 || numTecnico > tecnicos.Count)
            {
                Console.WriteLine("Tecnico no valido.");
                return;
            }

            Tecnico tecnicoSeleccionado = tecnicos[numTecnico - 1];

            if (!tecnicoSeleccionado.Disponible)
            {
                Console.WriteLine("El tecnico seleccionado no esta disponible.");
                return;
            }

            incidente.AsignarTecnico(tecnicoSeleccionado);
            tecnicoSeleccionado.Disponible = false;

            Console.WriteLine($"\nTecnico {tecnicoSeleccionado.Nombre} asignado al incidente #{incidente.Id}");
            Console.WriteLine($"Estado del incidente actualizado a: {incidente.Estado}");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Debe ingresar numeros validos.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al asignar tecnico: {ex.Message}");
        }
    }

    void ActualizarEstadoIncidente()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR ESTADO DE INCIDENTE ===\n");

            if (incidentes.Count == 0)
            {
                Console.WriteLine("No hay incidentes registrados.");
                return;
            }

            Console.WriteLine("Lista de incidentes:");
            for (int i = 0; i < incidentes.Count; i++)
            {
                Console.WriteLine($"ID: {incidentes[i].Id} | {incidentes[i].Descripcion} | Estado: {incidentes[i].Estado}");
            }

            Console.Write("\nIngrese el ID del incidente: ");
            int idIncidente = int.Parse(Console.ReadLine());

            Incidente incidente = null;
            for (int i = 0; i < incidentes.Count; i++)
            {
                if (incidentes[i].Id == idIncidente)
                {
                    incidente = incidentes[i];
                    break;
                }
            }

            if (incidente == null)
            {
                Console.WriteLine("Incidente no encontrado.");
                return;
            }

            Console.WriteLine($"\nEstado actual: {incidente.Estado}");
            Console.WriteLine("\nNuevos estados disponibles:");
            Console.WriteLine("1. Abierto");
            Console.WriteLine("2. En Proceso");
            Console.WriteLine("3. Resuelto");
            Console.WriteLine("4. Cerrado");
            Console.Write("Seleccione el nuevo estado: ");
            int estadoNum = int.Parse(Console.ReadLine());

            string nuevoEstado = "";
            switch (estadoNum)
            {
                case 1:
                    nuevoEstado = "Abierto";
                    break;
                case 2:
                    nuevoEstado = "En Proceso";
                    break;
                case 3:
                    nuevoEstado = "Resuelto";
                    break;
                case 4:
                    nuevoEstado = "Cerrado";
                    if (incidente.TecnicoAsignado != null)
                    {
                        incidente.TecnicoAsignado.Disponible = true;
                    }
                    break;
                default:
                    Console.WriteLine("Estado no valido.");
                    return;
            }

            incidente.ActualizarEstado(nuevoEstado);
            Console.WriteLine($"\nEstado actualizado exitosamente a: {nuevoEstado}");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Debe ingresar numeros validos.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al actualizar estado: {ex.Message}");
        }
    }

     void MostrarIncidentes()
    {
        Console.Clear();
        Console.WriteLine("=== LISTA DE INCIDENTES ===\n");

        if (incidentes.Count == 0)
        {
            Console.WriteLine("No hay incidentes registrados.");
            return;
        }

        for (int i = 0; i < incidentes.Count; i++)
        {
            incidentes[i].MostrarInformacion();
        }
    }

    void GenerarReporte()
    {
        Console.Clear();
        Administrador admin = new Administrador("Sistema Admin", "A001", "admin@empresa.com");
        admin.GenerarReporte(incidentes);

        Console.WriteLine("\n--- INCIDENTES PENDIENTES ---");
        int pendientes = 0;
        for (int i = 0; i < incidentes.Count; i++)
        {
            if (incidentes[i].Estado == "Abierto" || incidentes[i].Estado == "En Proceso")
            {
                Console.WriteLine($"ID: {incidentes[i].Id} | {incidentes[i].Descripcion} | Estado: {incidentes[i].Estado}");
                pendientes++;
            }
        }
        if (pendientes == 0)
        {
            Console.WriteLine("No hay incidentes pendientes.");
        }

        Console.WriteLine("\n--- INCIDENTES RESUELTOS ---");
        int resueltos = 0;
        for (int i = 0; i < incidentes.Count; i++)
        {
            if (incidentes[i].Estado == "Resuelto" || incidentes[i].Estado == "Cerrado")
            {
                Console.WriteLine($"ID: {incidentes[i].Id} | {incidentes[i].Descripcion} | Estado: {incidentes[i].Estado}");
                resueltos++;
            }
        }
        if (resueltos == 0)
        {
            Console.WriteLine("No hay incidentes resueltos.");
        }
    }

    void MostrarTecnicos()
    {
        Console.Clear();
        Console.WriteLine("=== LISTA DE TECNICOS ===\n");

        for (int i = 0; i < tecnicos.Count; i++)
        {
            tecnicos[i].MostrarInformacion();
        }
    }