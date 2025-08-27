namespace pruebaSemana01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int LIMITE_LISTA = 50;
            int cantidad;
            int opcion;

            // Elección del tipo de inserción
            while (true)
            {
                Console.WriteLine("¿Cómo deseas insertar los números en la lista?");
                Console.WriteLine("1. Insertar al inicio");
                Console.WriteLine("2. Insertar al final");
                Console.WriteLine("3. Insertar en orden ascendente");
                Console.Write("Elige una opción (1, 2 o 3): ");
                string? entradaOpcion = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entradaOpcion) || entradaOpcion == null)
                {
                    Console.WriteLine("Debes elegir una opción válida.");
                    continue;
                }

                try
                {
                    opcion = int.Parse(entradaOpcion);
                    if (opcion < 1 || opcion > 3)
                    {
                        Console.WriteLine("Solo puedes elegir 1, 2 o 3.");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("No se acepta letras u símbolos diferentes. Por favor, ingresa 1, 2 o 3.");
                }
            }

            // Validación de cantidad de elementos
            while (true)
            {
                Console.WriteLine($"¿Cuántos números deseas insertar en la lista? (Máximo {LIMITE_LISTA})");
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada) || entrada == null)
                {
                    Console.WriteLine("No se acepta una lista vacía");
                    continue;
                }

                try
                {
                    cantidad = int.Parse(entrada);
                    if (cantidad == 0)
                    {
                        Console.WriteLine("No se acepta una lista vacía");
                        continue;
                    }
                    if (cantidad > LIMITE_LISTA)
                    {
                        Console.WriteLine($"No se puede crear una lista con más de {LIMITE_LISTA} elementos.");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("No se acepta letras u símbolos diferentes. Por favor, ingresa un número entero.");
                }
            }

            List<int> valores = new List<int>();
            for (int i = 0; i < cantidad; i++)
            {
                while (true)
                {
                    Console.Write($"Ingresa el valor #{i + 1}: ");
                    try
                    {
                        int valor = int.Parse(Console.ReadLine()!);
                        valores.Add(valor);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("No se acepta letras u símbolos diferentes. Por favor, ingresa un número entero.");
                    }
                }
            }

            ListaSimple<int> lista = new ListaSimple<int>();

            // Switch para elegir el método de inserción
            switch (opcion)
            {
                case 1:
                    lista.InsertarVariosAlInicio(valores);
                    Console.WriteLine("Valores insertados al inicio de la lista:");
                    break;
                case 2:
                    foreach (var valor in valores)
                    {
                        lista.InsertarAlFinal(valor);
                    }
                    Console.WriteLine("Valores insertados al final de la lista:");
                    break;
                case 3:
                    foreach (var valor in valores)
                    {
                        lista.InsertarAscendente(valor);
                    }
                    Console.WriteLine("Valores insertados en orden ascendente:");
                    break;
            }

            lista.Mostrar();
        }
    }
}
