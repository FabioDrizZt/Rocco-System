
class Programa
{
    static void Main()
    {
        int[] notas = new int[100];
        int cantidadDeNotas = 0;
        //   (5, 10, 15, 20, 25, 30, 35, 40, 45, 50)
        //    0  1    2  3    4   5   6   7   8   9
        Console.WriteLine("Ingrese las notas de un examen: ");
        do {
            Console.Write("Ingrese la Nota N° " + cantidadDeNotas + 1);
            int notaIngresada = Convert.ToInt32(Console.ReadLine());
            notas[cantidadDeNotas] = notaIngresada;
            cantidadDeNotas++;
        } while (notaIngresada = -1)
        // Mostrar las notas
        for (int i = 0; i < notas.; i++)
        {
            Console.WriteLine(notas[i]);
        }
    }
}