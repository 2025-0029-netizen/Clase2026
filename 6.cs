using System;

class ArregloNumeros
{
    static void Main(string[] args)
    {
        // Declaramos un arreglo de 5 enteros (las posiciones van de 0 a 4)
        int[] numeros = new int[5];

        // Ciclo for para cargar los valores ingresados por el usuario
        Console.WriteLine("Ingrese 5 números:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"numeros[{i}]: ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        // Ciclo foreach para mostrar los valores
        // foreach recorre cada elemento del arreglo automáticamente, sin índice
        Console.WriteLine("\nValores almacenados:");
        foreach (int num in numeros)
        {
            Console.WriteLine(num);
        }
    }
}