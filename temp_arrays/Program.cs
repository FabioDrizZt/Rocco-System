using System;

class ProgramaArrays
{
    static void Main()
    {
        int[] notas = new int[100];
        int cantidadDeNotas = 0;
        
        Console.WriteLine("Ingrese las notas de un examen (escriba -1 para finalizar):");

        while (cantidadDeNotas < notas.Length)
        {
            Console.Write($"Ingrese la Nota N° {cantidadDeNotas + 1}: ");
            int notaIngresada;
            if (!int.TryParse(Console.ReadLine(), out notaIngresada))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
                continue;
            }

            if (notaIngresada == -1)
            {
                break;
            }
            
            notas[cantidadDeNotas] = notaIngresada;
            cantidadDeNotas++;
        }
        
        Console.WriteLine("\n--- Notas ingresadas ---");
        for (int i = 0; i < cantidadDeNotas; i++)
        {
            Console.WriteLine(notas[i]);
        }
    }
}