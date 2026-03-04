using System;

class ContadorSimple
{
    static void Main(string[] args)
    {
        Console.WriteLine("Números del 1 al 10:");

        // Estructura del for: (valor inicial; condición para continuar; incremento)
        // i empieza en 1, el ciclo continúa mientras i <= 10, y suma 1 en cada vuelta
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("Número: " + i);
        }
    }
}