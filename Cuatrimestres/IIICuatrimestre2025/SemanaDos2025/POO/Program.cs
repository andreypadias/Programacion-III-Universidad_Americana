// See https://aka.ms/new-console-template for more information
using POO;

List<Producto> Productos = new List<Producto>();

bool menu = true;

do
{
    // mostrar menu
    MostrarMenu();

    menu = ProcesarOpcionMenu();


} while (menu);

static void MostrarMenu()
{
    Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
    Console.WriteLine("1. Añadir nuevo producto");
    Console.WriteLine("2. Ver todos los productos");
    Console.WriteLine("3. Actualizar cantidad de producto");
    Console.WriteLine("4. Calcular valor total del inventario");
    Console.WriteLine("5. Salir");
    Console.Write("\nSeleccione una opción (1-5): ");

}

bool ProcesarOpcionMenu() 
{
    try
    {
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                AñadirNuevoProducto();
                break;
            case 2:
                MostrarTodosLosProductos();
                break;
            case 3:
                ActualizarCantidadProducto();
                break;
            case 4:
                MostrarValorTotalInventario();
                break;
            case 5:
                return false;
            default:
                Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 5.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ha ocurrido un error. Error: "+ex.Message);
       
    }

    return true;
}


// Método para añadir un nuevo producto
void AñadirNuevoProducto()
{
    Console.WriteLine("\n=== AÑADIR NUEVO PRODUCTO ===");

    try
    {
        Console.Write("Ingrese la cantidad en stock: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el precio del producto: $");
        decimal precio = decimal.Parse(Console.ReadLine());



        Producto nuevoProducto = new Producto(nombre, precio, cantidad);
        Productos.Add(nuevoProducto);
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Por favor, ingrese valores numéricos válidos para el precio y la cantidad.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error de validación: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
    }
}

//Metodo para mostros los productos
void MostrarTodosLosProductos()
{
    Console.WriteLine("\n=== LISTA DE PRODUCTOS ===");

    if (Productos.Count == 0)
    {
        Console.WriteLine("No hay productos en el inventario.");
        return;
    }

    foreach (var producto in Productos)
    {
        Console.WriteLine(producto.DetallesProducto());
    }
}

//Metodo mostrar valor total inventario
void MostrarValorTotalInventario()
{
    Console.WriteLine("\n=== VALOR TOTAL DEL INVENTARIO ===");

    decimal valorTotal = 0;
    foreach (var producto in Productos)
    {
        // Acceder a los atributos privados mediante reflexión
        var cantidadProp = producto.Cantidad;
        var precioProp = producto.Precio;

        if (cantidadProp > 0 && precioProp > 0)
        {
            valorTotal += cantidadProp * precioProp;
        }
    }

    Console.WriteLine($"El valor total del inventario es: ₡{valorTotal}");
}

//Metodo actualizar cantidad producto
void ActualizarCantidadProducto()
{
    Console.WriteLine("\n=== ACTUALIZAR CANTIDAD DE PRODUCTO ===");

    if (Productos.Count == 0)
    {
        Console.WriteLine("No hay productos en el inventario para actualizar.");
        return;
    }

    Console.Write("Ingrese el nombre del producto a actualizar: ");
    string nombreProducto = Console.ReadLine();

    var producto = Productos.Find(p => p.DetallesProducto().Contains(nombreProducto));

    if (producto == null)
    {
        Console.WriteLine("Producto no encontrado.");
        return;
    }

    try
    {
        Console.Write("Ingrese la nueva cantidad en stock: ");
        int nuevaCantidad = int.Parse(Console.ReadLine());
        producto.ValidarCantidad(nuevaCantidad);
        Console.WriteLine("Cantidad actualizada exitosamente.");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Por favor, ingrese un número válido para la cantidad.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error de validación: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
    }
}

void EjemploFor() 
{
    //FOR
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(i);
    }

    //FOREACH
    foreach (Producto producto in Productos)
    {
        Console.WriteLine(producto.DetallesProducto());
    }
}