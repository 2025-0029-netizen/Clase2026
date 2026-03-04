using System;

class FrecuenciaValores
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

        // contado[i] = true significa que numeros[i] ya fue procesado antes
        // Lo usamos para no contar el mismo número dos veces
        bool[] contado = new bool[n];

        Console.WriteLine("\nFrecuencia de cada número:");
        for (int i = 0; i < n; i++)
        {
            // Solo procesamos este elemento si todavía no fue contado
            if (!contado[i])
            {
                int frecuencia = 1; // el propio elemento ya cuenta como una aparición

                // Comparamos numeros[i] con todos los elementos que vienen después
                for (int j = i + 1; j < n; j++)
                {
                    if (numeros[j] == numeros[i])
                    {
                        frecuencia++;
                        contado[j] = true; // lo marcamos para no volver a contarlo
                    }
                }

                Console.WriteLine($"  {numeros[i]} -> aparece {frecuencia} vez/veces");
            }
        }
    }
}