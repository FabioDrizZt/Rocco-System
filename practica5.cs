using System;

class Programa
{
    static void Main()
    {
        int[] notas = new int[100];
        int cantidadDeNotas = 0;
        // Ingresar las notas
        while (true){
            Console.Write("\nIngrese la Nota N° " + cantidadDeNotas + ": ");
            int notaIngresada = Convert.ToInt32(Console.ReadLine());
            if (notaIngresada == 0){
                break;
            }
            notas[cantidadDeNotas] = notaIngresada;
            cantidadDeNotas++;
        }
        // Ordenar las notas
        bool swapped;
    
       while (true) {
            swapped = false;
            for (int j = 0; j < cantidadDeNotas - i - 1; j++) {
                if (notas[j] > notas[j + 1]) {
                    int aux = notas[j];
                    notas[j] = notas[j + 1];
                    notas[j + 1] = aux;
                    swapped = true;
                }
            }
        
            // If no two elements were swapped, then break
            if (!swapped)
                break;
        }
}        // Mostrar las notas
        for (int i = 0; i < cantidadDeNotas; i++)
        {
            Console.WriteLine(notas[i]);
        }
    }
}
