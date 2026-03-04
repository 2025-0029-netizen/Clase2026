using System;

class BusquedaArreglo
{
    static void Main(string[] args)
    {
        int[] numeros = { 15, 42, 7, 83, 29, 61, 4, 98, 36, 55 };

        Console.WriteLine("Arreglo: 15, 42, 7, 83, 29, 61, 4, 98, 36, 55");
        Console.Write("Número a buscar: ");
        int buscar = int.Parse(Console.ReadLine());

        bool encontrado = false;
        int posicion = -1; // -1 significa "no encontrado" aún

        for (int i = 0; i < numeros.Length; i++)
        {
            if (numeros[i] == buscar)
            {
                encontrado = true;
                posicion = i;
                break; // detenemos el ciclo en cuanto encontramos el número
            }
        }

        if (encontrado)
            Console.WriteLine($"Número encontrado en la posición [{posicion}]");
        else
            Console.WriteLine("El número NO fue encontrado en el arreglo.");
    }
}