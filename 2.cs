using System;

class SumaNumeros
{
    static void Main(string[] args)
    {
        int suma = 0;
        int numero = 1;

        // El ciclo while se repite mientras la condición sea verdadera
        while (numero <= 100)
        {
            suma += numero;  // equivale a: suma = suma + numero
            numero++;        // equivale a: numero = numero + 1
        }

        Console.WriteLine("La suma de los primeros 100 números naturales es: " + suma);
    }
}