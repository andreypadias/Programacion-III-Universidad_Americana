using ClienteAPI;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

// Configuración y inicialización de HttpClient
using var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
httpClient.DefaultRequestHeaders.Accept.Clear();
httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

// Inicialización del servicio
var jsonPlaceholderService = new JsonPlaceholderService(httpClient);

bool mostrarMenu = true;
while (mostrarMenu)
{
    mostrarMenu = await MostrarMenu(jsonPlaceholderService);
}

static async Task<bool> MostrarMenu(JsonPlaceholderService service)
{
    Console.Clear();
    Console.WriteLine("Menú de Consumo de API - JSONPlaceholder");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("1) Ver todos los usuarios");
    Console.WriteLine("2) Ver un usuario por ID");
    Console.WriteLine("3) Salir");
    Console.Write("\nSeleccione una opción: ");

    switch (Console.ReadLine())
    {
        case "1":
            await VerTodosLosUsuarios(service);
            return true;
        case "2":
            await VerUsuarioPorId(service);
            return true;
        case "3":
            Console.WriteLine("\nSaliendo del programa...");
            return false;
        default:
            Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar.");
            Console.ReadKey();
            return true;
    }
}

static async Task VerTodosLosUsuarios(JsonPlaceholderService service)
{
    Console.Clear();
    Console.WriteLine("Cargando todos los usuarios...\n");
    var usuarios = await service.GetTodosUsuariosAsync();

    if (usuarios != null)
    {
        foreach (var user in usuarios)
        {
            Console.WriteLine($"ID: {user.Id}, Nombre: {user.Name}, Email: {user.Email}");
        }
    }

    Console.WriteLine("\nPresione cualquier tecla para volver al menú.");
    Console.ReadKey();
}

static async Task VerUsuarioPorId(JsonPlaceholderService service)
{
    Console.Clear();
    Console.Write("Ingrese el ID del usuario (1-10): ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("\nID no válido. Por favor, ingrese un número.");
        Console.ReadKey();
        return;
    }

    var usuario = await service.GetUsuarioPorIdAsync(id);

    if (usuario != null)
    {
        Console.Clear();
        Console.WriteLine("Detalles del usuario:");
        Console.WriteLine($"ID: {usuario.Id}");
        Console.WriteLine($"Nombre: {usuario.Name}");
        Console.WriteLine($"Nombre de Usuario: {usuario.Username}");
        Console.WriteLine($"Email: {usuario.Email}");
    }

    Console.WriteLine("\nPresione cualquier tecla para volver al menú.");
    Console.ReadKey();
}

