using System;

class PromedioNotas
{
    static void Main(string[] args)
    {
        Console.Write("¿Cuántas notas desea ingresar? ");
        int cantidad = int.Parse(Console.ReadLine());

        // Validación: evitamos dividir por cero si el usuario ingresa 0 o negativo
        if (cantidad <= 0)
        {
            Console.WriteLine("La cantidad de notas debe ser mayor a 0.");
            return; // termina el programa
        }

        double suma = 0;

        for (int i = 1; i <= cantidad; i++)
        {
            Console.Write($"Nota {i}: ");
            double nota = double.Parse(Console.ReadLine());
            suma += nota;
        }

        // Dividimos la suma total entre la cantidad de notas para obtener el promedio
        double promedio = suma / cantidad;
        Console.WriteLine($"Promedio final: {promedio:F2}"); // :F2 muestra 2 decimales
    }
}