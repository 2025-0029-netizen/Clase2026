using System;

class TablaMultiplicar
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese un número: ");

        // int.TryParse intenta convertir el texto a entero de forma segura
        // Si falla (ej: el usuario escribe letras), devuelve false y no lanza error
        if (!int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.WriteLine("Valor inválido. Se usará el número 1 por defecto.");
            numero = 1;
        }

        Console.WriteLine($"\nTabla del {numero}:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numero} x {i} = {numero * i}");
        }
    }
}