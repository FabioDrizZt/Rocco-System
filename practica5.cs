using System;

class Programa
{
    static void Main()
    {
        int[] notas = new int[100];
        int cantidadDeNotas = 0;
        // Ingresar las notas
        while (true)
        {
            Console.Write("\nIngrese la Nota N° " + (cantidadDeNotas + 1) + " (ingrese 0 para terminar): ");
            string entrada = Console.ReadLine();
            int notaIngresada;

            if (int.TryParse(entrada, out notaIngresada))
            {
                if (notaIngresada == 0)
                {
                    break;
                }
                if (notaIngresada >= 1 && notaIngresada <= 10)
                {
                    notas[cantidadDeNotas] = notaIngresada;
                    cantidadDeNotas++;
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingrese una nota entre 1 y 10.");
                }
            }
            else
            {
                Console.WriteLine("Error: Entrada inválida. Por favor, ingrese un número.");
            }
        }

        // Ordenar las notas utilizando el algoritmo Bubble Sort
        for (int i = 0; i < cantidadDeNotas - 1; i++)
        {
            for (int j = 0; j < cantidadDeNotas - i - 1; j++)
            {
                if (notas[j] > notas[j + 1])
                {
                    // Intercambiar notas[j] y notas[j + 1]
                    int aux = notas[j];
                    notas[j] = notas[j + 1];
                    notas[j + 1] = aux;
                }
            }
        }
        
        // Mostrar las notas ordenadas
        Console.WriteLine("\n--- Notas ordenadas de menor a mayor ---");
        for (int i = 0; i < cantidadDeNotas; i++)
        {
            Console.WriteLine(notas[i]);
        }
    }
}
