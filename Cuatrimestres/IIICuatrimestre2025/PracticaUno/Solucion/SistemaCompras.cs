using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    public class SistemaCompras
    {
        private List<Proveedor> proveedores;
        private List<Producto> productos;
        private List<OrdenCompra> ordenes;
        private Inventario inventario;
        private int siguienteIdProveedor;
        private int siguienteIdProducto;
        private int siguienteNumeroOrden;

        public SistemaCompras()
        {
            proveedores = new List<Proveedor>();
            productos = new List<Producto>();
            ordenes = new List<OrdenCompra>();
            inventario = new Inventario();
            siguienteIdProveedor = 1;
            siguienteIdProducto = 1;
            siguienteNumeroOrden = 1000;

            // Datos de ejemplo
            InicializarDatosEjemplo();
        }

        private void InicializarDatosEjemplo()
        {
            // Proveedores de ejemplo
            proveedores.Add(new Proveedor(siguienteIdProveedor++, "Construmax S.A.", "12345678-9", "Juan Pérez - 2555-1234"));
            proveedores.Add(new Proveedor(siguienteIdProveedor++, "Limpieza Total Ltda.", "98765432-1", "María González - 2666-5678"));

            // Productos de ejemplo
            productos.Add(new Producto(siguienteIdProducto++, "Cemento Portland", "Cemento de alta calidad 50kg", 8500, "Materiales de Construcción"));
            productos.Add(new Producto(siguienteIdProducto++, "Detergente Industrial", "Detergente concentrado 5L", 2300, "Productos de Limpieza"));
            productos.Add(new Producto(siguienteIdProducto++, "Arena Fina", "Arena fina por m³", 12000, "Materiales de Construcción"));
        }

        public void MostrarMenu()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("=== SISTEMA DE COMPRAS ===");
                    Console.WriteLine("1. Registrar nuevo proveedor");
                    Console.WriteLine("2. Registrar nuevo producto");
                    Console.WriteLine("3. Crear orden de compra");
                    Console.WriteLine("4. Ver todas las órdenes de compra");
                    Console.WriteLine("5. Marcar orden como recibida (actualizar inventario)");
                    Console.WriteLine("6. Ver inventario actual");
                    Console.WriteLine("7. Ver proveedores");
                    Console.WriteLine("8. Ver productos");
                    Console.WriteLine("9. Salir");
                    Console.WriteLine("===============================================");
                    Console.Write("Seleccione una opción (1-9): ");

                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            RegistrarProveedor();
                            break;
                        case "2":
                            RegistrarProducto();
                            break;
                        case "3":
                            CrearOrdenCompra();
                            break;
                        case "4":
                            VerOrdenes();
                            break;
                        case "5":
                            MarcarOrdenRecibida();
                            break;
                        case "6":
                            inventario.MostrarInventario(productos);
                            break;
                        case "7":
                            MostrarProveedores();
                            break;
                        case "8":
                            MostrarProductos();
                            break;
                        case "9":
                            Console.WriteLine("¡Gracias por usar el sistema! ¡Hasta pronto!");
                            return;
                        default:
                            Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar.");
                            break;
                    }

                    if (opcion != "9")
                    {
                        Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private void RegistrarProveedor()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== REGISTRAR NUEVO PROVEEDOR ===");

                Console.Write("Nombre del proveedor: ");
                string nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                    return;
                }

                Console.Write("Número fiscal: ");
                string numeroFiscal = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(numeroFiscal))
                {
                    Console.WriteLine("El número fiscal no puede estar vacío.");
                    return;
                }

                Console.Write("Contacto (nombre y teléfono): ");
                string contacto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(contacto))
                {
                    Console.WriteLine("El contacto no puede estar vacío.");
                    return;
                }

                var nuevoProveedor = new Proveedor(siguienteIdProveedor++, nombre, numeroFiscal, contacto);
                proveedores.Add(nuevoProveedor);

                Console.WriteLine($"✓ Proveedor '{nombre}' registrado exitosamente con ID: {nuevoProveedor.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar proveedor: {ex.Message}");
            }
        }

        private void RegistrarProducto()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== REGISTRAR NUEVO PRODUCTO ===");

                Console.Write("Nombre del producto: ");
                string nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                    return;
                }

                Console.Write("Descripción: ");
                string descripcion = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    descripcion = "Sin descripción";
                }

                Console.Write("Precio por unidad: $");
                if (!decimal.TryParse(Console.ReadLine(), out decimal precio) || precio <= 0)
                {
                    Console.WriteLine("Precio inválido. Debe ser un número mayor a cero.");
                    return;
                }

                Console.WriteLine("Categorías disponibles:");
                Console.WriteLine("1. Materiales de Construcción");
                Console.WriteLine("2. Productos de Limpieza");
                Console.WriteLine("3. Otros");
                Console.Write("Seleccione categoría (1-3): ");

                string categoria = Console.ReadLine() switch
                {
                    "1" => "Materiales de Construcción",
                    "2" => "Productos de Limpieza",
                    "3" => "Otros",
                    _ => "Otros"
                };

                var nuevoProducto = new Producto(siguienteIdProducto++, nombre, descripcion, precio, categoria);
                productos.Add(nuevoProducto);

                Console.WriteLine($"✓ Producto '{nombre}' registrado exitosamente con ID: {nuevoProducto.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar producto: {ex.Message}");
            }
        }

        private void CrearOrdenCompra()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== CREAR ORDEN DE COMPRA ===");

                if (proveedores.Count == 0)
                {
                    Console.WriteLine("No hay proveedores registrados. Registre un proveedor primero.");
                    return;
                }

                if (productos.Count == 0)
                {
                    Console.WriteLine("No hay productos registrados. Registre un producto primero.");
                    return;
                }

                // Seleccionar proveedor
                Console.WriteLine("Proveedores disponibles:");
                foreach (var proveedor in proveedores)
                {
                    Console.WriteLine(proveedor);
                }

                Console.Write("ID del proveedor: ");
                if (!int.TryParse(Console.ReadLine(), out int proveedorId))
                {
                    Console.WriteLine("ID de proveedor inválido.");
                    return;
                }

                var proveedorSeleccionado = proveedores.FirstOrDefault(p => p.Id == proveedorId);
                if (proveedorSeleccionado == null)
                {
                    Console.WriteLine("Proveedor no encontrado.");
                    return;
                }

                // Crear la orden
                var orden = new OrdenCompra(siguienteNumeroOrden++, proveedorSeleccionado);

                // Agregar productos
                bool agregarMasProductos = true;
                while (agregarMasProductos)
                {
                    Console.WriteLine("\nProductos disponibles:");
                    foreach (var producto in productos)
                    {
                        Console.WriteLine(producto);
                    }

                    Console.Write("ID del producto a agregar: ");
                    if (!int.TryParse(Console.ReadLine(), out int productoId))
                    {
                        Console.WriteLine("ID de producto inválido.");
                        continue;
                    }

                    var productoSeleccionado = productos.FirstOrDefault(p => p.Id == productoId);
                    if (productoSeleccionado == null)
                    {
                        Console.WriteLine("Producto no encontrado.");
                        continue;
                    }

                    Console.Write($"Cantidad de '{productoSeleccionado.Nombre}': ");
                    if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
                    {
                        Console.WriteLine("Cantidad inválida. Debe ser un número mayor a cero.");
                        continue;
                    }

                    orden.AgregarItem(productoSeleccionado, cantidad);
                    Console.WriteLine($"✓ Agregado: {productoSeleccionado.Nombre} x {cantidad}");

                    Console.Write("¿Desea agregar otro producto? (s/n): ");
                    string respuesta = Console.ReadLine()?.ToLower();
                    agregarMasProductos = respuesta == "s" || respuesta == "si" || respuesta == "sí";
                }

                ordenes.Add(orden);
                Console.WriteLine($"\n✓ Orden de compra #{orden.NumeroOrden} creada exitosamente!");
                Console.WriteLine($"Total de la orden: ${orden.Total:F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear orden: {ex.Message}");
            }
        }

        private void VerOrdenes()
        {
            Console.Clear();
            Console.WriteLine("=== TODAS LAS ÓRDENES DE COMPRA ===");

            if (ordenes.Count == 0)
            {
                Console.WriteLine("No hay órdenes de compra registradas.");
                return;
            }

            foreach (var orden in ordenes.OrderBy(o => o.NumeroOrden))
            {
                Console.WriteLine(orden);
            }
        }

        private void MarcarOrdenRecibida()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== MARCAR ORDEN COMO RECIBIDA ===");

                var ordenesPendientes = ordenes.Where(o => !o.Recibida).ToList();
                if (ordenesPendientes.Count == 0)
                {
                    Console.WriteLine("No hay órdenes pendientes.");
                    return;
                }

                Console.WriteLine("Órdenes pendientes:");
                foreach (var orden in ordenesPendientes)
                {
                    Console.WriteLine($"#{orden.NumeroOrden} - {orden.Proveedor.Nombre} - ${orden.Total:F2}");
                }

                Console.Write("Número de orden a marcar como recibida: ");
                if (!int.TryParse(Console.ReadLine(), out int numeroOrden))
                {
                    Console.WriteLine("Número de orden inválido.");
                    return;
                }

                var ordenSeleccionada = ordenesPendientes.FirstOrDefault(o => o.NumeroOrden == numeroOrden);
                if (ordenSeleccionada == null)
                {
                    Console.WriteLine("Orden no encontrada o ya fue recibida.");
                    return;
                }

                // Actualizar inventario
                foreach (var item in ordenSeleccionada.Items)
                {
                    inventario.ActualizarStock(item.Producto.Id, item.Cantidad);
                }

                ordenSeleccionada.Recibida = true;
                Console.WriteLine($"✓ Orden #{numeroOrden} marcada como recibida.");
                Console.WriteLine("Inventario actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al marcar orden: {ex.Message}");
            }
        }

        private void MostrarProveedores()
        {
            Console.Clear();
            Console.WriteLine("=== PROVEEDORES REGISTRADOS ===");

            if (proveedores.Count == 0)
            {
                Console.WriteLine("No hay proveedores registrados.");
                return;
            }

            foreach (var proveedor in proveedores)
            {
                Console.WriteLine(proveedor);
            }
        }

        private void MostrarProductos()
        {
            Console.Clear();
            Console.WriteLine("=== PRODUCTOS REGISTRADOS ===");

            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                return;
            }

            var productosPorCategoria = productos.GroupBy(p => p.Categoria);
            foreach (var grupo in productosPorCategoria)
            {
                Console.WriteLine($"\n--- {grupo.Key} ---");
                foreach (var producto in grupo)
                {
                    Console.WriteLine($"  {producto}");
                }
            }
        }
    }
}
