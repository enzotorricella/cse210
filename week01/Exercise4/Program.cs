using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int numeroIngresado = -1;

        while (numeroIngresado != 0)
        {
            Console.Write("Enter number: ");
            numeroIngresado = int.Parse(Console.ReadLine());

            if (numeroIngresado != 0)
            {
                numeros.Add(numeroIngresado);
            }
        }

        int suma = 0;

        foreach (int numero in numeros)
        {
            suma += numero;
        }

        Console.WriteLine($"The sum is: {suma}");

        double promedio = (double)suma / numeros.Count;
        Console.WriteLine($"The average is: {promedio}");

        int numeroMayor = numeros[0];

        foreach (int numero in numeros)
        {
            if (numero > numeroMayor)
            {
                numeroMayor = numero;
            }
        }

        Console.WriteLine($"The largest number is: {numeroMayor}");
    }
}
