using System;

class NumerosPares
{
    static void Main(string[] args)
    {
        Console.WriteLine("Números pares entre 1 y 50:");

        // Empezamos en 2 (el primer número par) y avanzamos de 2 en 2
        // i += 2 equivale a: i = i + 2
        for (int i = 2; i <= 50; i += 2)
        {
            Console.Write(i + "  ");
        }

        Console.WriteLine(); // salto de línea al final
    }
}