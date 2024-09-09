namespace Buffet_Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcionIngresada = 0;

            //Creo la fila de clientes usando una Queue de strings
            Queue<string> filaClientes = new Queue<string>();
            filaClientes.Enqueue("Miguel");
            filaClientes.Enqueue("Santiago");
            filaClientes.Enqueue("Emmanuel");
            filaClientes.Enqueue("Federico");
            filaClientes.Enqueue("Ornella");
            filaClientes.Enqueue("Candela");
            filaClientes.Enqueue("Emilia");
            filaClientes.Enqueue("Luciana");

            //Creo la lista de productos para el buffet
            List<Producto> mesaBuffet = new List<Producto>();

            //Creo los productos
            Producto productoPizza = new Producto("Pizza", 600, 5);
            Producto productoHamburguesa = new Producto("Hamburguesa", 500, 2);
            Producto productoFideos = new Producto("Fideos", 450, 1);
            Producto productoMilanesa = new Producto("Milanesa", 400, 3);
            Producto productoPancho = new Producto("Pancho", 350, 1);
            Producto productoAgua = new Producto("Agua", 200, 2);
            Producto productoGaseosa = new Producto("Gaseosa", 250, 3);
            Producto productoJugo = new Producto("Jugo", 300, 3);
            Producto productoCerveza = new Producto("Cerveza", 400, 2);
            Producto productoSoda = new Producto("Soda", 250, 2);

            //Le agrego los productos a la lista del Buffet
            #region Productos agregados
            mesaBuffet.Add(productoPizza);
            mesaBuffet.Add(productoHamburguesa);
            mesaBuffet.Add(productoFideos);
            mesaBuffet.Add(productoMilanesa);
            mesaBuffet.Add(productoPancho);
            mesaBuffet.Add(productoAgua);
            mesaBuffet.Add(productoGaseosa);
            mesaBuffet.Add(productoJugo);
            mesaBuffet.Add(productoCerveza);
            mesaBuffet.Add(productoSoda);
            #endregion

            //Creo una lista de los productos que va seleccionando cada cliente
            List<Producto> listaPedidoDelCliente = new List<Producto>();

            while (mesaBuffet.Count > 0 && filaClientes.Count > 0)
            {
                string? datoIngresadoString = "";
                string clienteActual = filaClientes.Peek();
                int acumulador = 0;

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"El cliente actual es {clienteActual} y atrás hay {filaClientes.Count - 1} personas más\n");
                Console.ResetColor();

                while (datoIngresadoString != "s" && datoIngresadoString != "S" && mesaBuffet.Count > 0)
                {
                    int indice = 1;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("   *****   Menú   *****");
                    Console.ResetColor();
                    foreach (Producto itemProducto in mesaBuffet)
                    {
                        Console.WriteLine($"{indice}. {itemProducto.Nombre} (${itemProducto.Precio}) " +
                            $"[x{itemProducto.Cantidad}]");
                        indice++;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nElija el producto que quiere agregar al pedido o ingrese 'S' para finalizar la compra: ");
                    Console.ResetColor();

                    datoIngresadoString = Console.ReadLine();

                    if (int.TryParse(datoIngresadoString, out opcionIngresada) &&
                        (opcionIngresada > 0 && opcionIngresada < mesaBuffet.Count + 1))
                    {
                        Producto productoSeleccionado = mesaBuffet[opcionIngresada - 1];

                        listaPedidoDelCliente.Add(productoSeleccionado);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\n{clienteActual} eligió los siguientes productos: \n");
                        acumulador = 0;
                        foreach (Producto producto in listaPedidoDelCliente)
                        {
                            acumulador += producto.Precio;
                            Console.WriteLine($"- {producto.Nombre} (${producto.Precio})");
                        }
                        Console.WriteLine($"\nTotal: ${acumulador}\n\n");

                        productoSeleccionado.Cantidad--;
                        Console.ResetColor();
                        if (productoSeleccionado.Cantidad == 0)
                        {
                            mesaBuffet.Remove(productoSeleccionado);
                        }
                    }
                    else if (datoIngresadoString != "s" && datoIngresadoString != "S")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error, esa opción no es válida");
                        Console.ForegroundColor = ConsoleColor.White;
                        datoIngresadoString = Console.ReadLine();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\n\nTerminó el turno de {clienteActual}. Su pedido acumuló un total de ${acumulador}\n\n");
                Console.ForegroundColor = ConsoleColor.White;

                listaPedidoDelCliente.Clear();
                filaClientes.Dequeue();

                if (filaClientes.Count == 0)
                {
                    datoIngresadoString = "";
                    Console.WriteLine("\nLlegamos al final de la fila, ya no quedan clientes.");

                    while (datoIngresadoString != "S" && datoIngresadoString != "s")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Ingrese el nombre de un nuevo cliente para agregarlo a la fila, o 'S' para salir: ");
                        Console.ResetColor();
                        datoIngresadoString = Console.ReadLine();

                        while (datoIngresadoString != null && Validadora.ValidarStringNombre(datoIngresadoString))
                        {
                            Console.WriteLine("Error, ingrese un nombre correcto: ");
                            datoIngresadoString = Console.ReadLine();
                        }

                        if (datoIngresadoString != null && datoIngresadoString != "S" && datoIngresadoString != "s")
                        {
                            filaClientes.Enqueue(datoIngresadoString);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nEl cliente {datoIngresadoString} fue agregado a la fila\n");
                            Console.ResetColor();
                        }
                    }
                }
            }

            if (mesaBuffet.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Se terminaron todos los productos!\n");
                Console.ResetColor();
            }

            Console.WriteLine("Gracias por usar Buffet\n");
        }
    }
}
