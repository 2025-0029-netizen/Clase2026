using System;

class MayorMenor
{
    static void Main(string[] args)
    {
        int[] numeros = new int[10];

        Console.WriteLine("Ingrese 10 números:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros[i] = int.Parse(Console.ReadLine());
        }

        // Iniciamos mayor y menor con el primer elemento como punto de comparación
        int mayor = numeros[0];
        int menor = numeros[0];

        // Recorremos desde el índice 1 porque el 0 ya fue tomado como referencia
        for (int i = 1; i < numeros.Length; i++)
        {
            if (numeros[i] > mayor)
                mayor = numeros[i]; // encontramos un número más grande

            if (numeros[i] < menor)
                menor = numeros[i]; // encontramos un número más chico
        }

        Console.WriteLine($"Número mayor: {mayor}");
        Console.WriteLine($"Número menor: {menor}");
    }
}