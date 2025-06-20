using System;

class Programa
{
    static void Main()
    {
        int[] notas = new int[100];
        int cantidadDeNotas = 0;
        // Ingresar las notas
        while (true){
            Console.Write("Ingrese la Nota N° " + cantidadDeNotas + 1);
            int notaIngresada = Convert.ToInt32(Console.ReadLine());
            if (notaIngresada == 0){
                break;
            }
            notas[cantidadDeNotas] = notaIngresada;
            cantidadDeNotas++;
        }
        // Ordenar las notas
        Array.Sort(notas);
        // Mostrar las notas
        for (int i = 0; i < cantidadDeNotas; i++)
        {
            Console.WriteLine(notas[i]);
        }
    }
}