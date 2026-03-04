using System;

class ContadorSignos
{
    static void Main(string[] args)
    {
        Console.Write("¿Cuántos números? ");
        int n = int.Parse(Console.ReadLine());
        int[] numeros = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        int positivos = 0, negativos = 0, ceros = 0;

        // foreach recorre cada elemento sin necesitar un índice
        foreach (int num in numeros)
        {
            if (num > 0)
                positivos++;
            else if (num < 0)
                negativos++;
            else
                ceros++;
        }

        Console.WriteLine($"Positivos: {positivos}");
        Console.WriteLine($"Negativos: {negativos}");
        Console.WriteLine($"Ceros:     {ceros}");
    }
}