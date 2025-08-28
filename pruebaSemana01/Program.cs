using System.Data;

namespace pruebaSemana01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int LIMITE_LISTA = 50; //Para limitar la cantidad de elementos en la lista
            bool continuar = true; //Controla si el usuario desea continuar creando listas

            while (continuar)
            {
                int cantidad;
                int opcion;

                // Elección del tipo de inserción
                while (true)
                {
                    Console.WriteLine("===============================================");
                    Console.WriteLine("¿Cómo deseas insertar los números en la lista?");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("1. Insertar al inicio");
                    Console.WriteLine("2. Insertar al final");
                    Console.WriteLine("3. Insertar en orden ascendente");
                    Console.WriteLine("-----------------------------------------------");
                    Console.Write("Elige una opción: ");
                    string? entradaOpcion = Console.ReadLine();
                    Console.WriteLine("-----------------------------------------------");

                    // Validando la opción ingresada para que no sea nula o vacía
                    if (string.IsNullOrWhiteSpace(entradaOpcion) || entradaOpcion == null)
                    {
                        Console.Clear();
                        Console.WriteLine("---- Debes elegir una opción válida. ----");
                        continue;
                    }

                    try
                    {
                        opcion = int.Parse(entradaOpcion); //Convirtiendo la entrada a entero
                        if (opcion < 1 || opcion > 3) //Validando que la opción esté dentro del rango permitido
                        {
                            Console.Clear();
                            Console.WriteLine("----- Solo puedes elegir 1, 2, 3. -----");
                            continue;
                        }
                        break; //Saliendo del ciclo si la opción es válida
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("---- No se acepta letras u símbolos diferentes. Por favor, ingresa 1, 2, 3. -----");
                    }
                }

                // Validación de cantidad de elementos
                while (true)
                {
                    Console.WriteLine($"¿Cuántos números deseas insertar en la lista? (Máximo {LIMITE_LISTA})");
                    string? entrada = Console.ReadLine();

                    // Validando que la entrada no sea nula o vacía
                    if (string.IsNullOrWhiteSpace(entrada) || entrada == null)
                    {
                        Console.Clear();
                        Console.WriteLine("--- No se acepta una lista vacía ---");
                        Console.WriteLine("====================================");
                        continue;
                    }

                    try
                    {
                        cantidad = int.Parse(entrada); //Convirtiendo la entrada a entero
                        if (cantidad == 0) // Validando que la cantidad no sea cero
                        {
                            Console.Clear();
                            Console.WriteLine("--- No se acepta una lista vacía ---");
                            Console.WriteLine("====================================");
                            continue;
                        }
                        if (cantidad > LIMITE_LISTA) // Validando no exceda el límite
                        {
                            Console.Clear();
                            Console.WriteLine($"--- No se puede crear una lista con más de {LIMITE_LISTA} elementos. ---");
                            Console.WriteLine("-----------------------------------------------------------------");
                            continue;
                        }
                        break; //Saliendo del ciclo si la cantidad es válida
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("No se acepta letras u símbolos diferentes. Por favor, ingresa un número entero.");
                        Console.WriteLine("===============================================================================");
                    }
                }

                List<int> valores = new List<int>(); //Lista para almacenar los valores ingresados
                for (int i = 0; i < cantidad; i++)
                {
                    while (true)
                    {
                        Console.Write($"Ingresa el valor #{i + 1}: ");
                        try
                        {
                            int valor = int.Parse(Console.ReadLine()!); //Solita y convirtiendo el valor a entero
                            valores.Add(valor); //Agregando el valor a la lista
                            break;
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("- No se aceptan: letras, escacio vacio u símbolos diferentes.");
                            Console.WriteLine("- Por favor, ingresa un número entero.");
                            Console.WriteLine("-------------------------------------------------------------------------------");
                        }
                    }
                }

                ListaSimple<int> lista = new ListaSimple<int>(); //Creando una nueva lista simple

                // Switch para elegir el método de inserción
                switch (opcion)
                {
                    case 1:
                        lista.InsertarVariosAlInicio(valores); //Insertando varios valores al inicio
                        Console.WriteLine("Valores insertados al inicio de la lista:");
                        break;
                    case 2:
                        foreach (var valor in valores)
                        {
                            lista.InsertarAlFinal(valor); //Insertando cada valor al final
                        }
                        Console.WriteLine("Valores insertados al final de la lista:");
                        break;
                    case 3:
                        foreach (var valor in valores)
                        {
                            lista.InsertarAscendente(valor); //Insertando cada valor en orden ascendente
                        }
                        Console.WriteLine("Valores insertados en orden ascendente:");
                        break;
                }

                // Haciendo una mejora visual en la consola
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===============================================");
                Console.WriteLine("           RESULTADO DE LA LISTA");
                Console.WriteLine("===============================================");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Elementos de la lista:");
                Console.ResetColor();

                Console.WriteLine("-----------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                lista.Mostrar();
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------------");

                Console.ForegroundColor = ConsoleColor.Magenta;
                // Mostrando resultados de los métodos adicionales (Contar,Sumar,Primer y Ultimo elemento)
                Console.WriteLine($"Cantidad de elementos: {lista.ContarElementos()}");
                Console.WriteLine($"Suma total de los elementos: {lista.SumarElementos()}");
                Console.WriteLine($"Primer elemento: {lista.ObtenerPrimero()}");
                Console.WriteLine($"Último elemento: {lista.ObtenerUltimo()}");
                Console.ResetColor();

                Console.WriteLine("===============================================");
                Console.WriteLine("¿Deseas crear otra lista? (s/n): ");
                string? respuesta = Console.ReadLine();
                if (respuesta == null || respuesta.Trim().ToLower() != "s")
                {
                    continuar = false; //Termina el programa si el usuario decide no continuar
                    Console.WriteLine("¡Gracias por usar el programa!");
                }
                Console.Clear();
            }
        }
    }
}
