using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string nombreUsuario = PromptUserName();
        int numeroFavorito = PromptUserNumber();
        int numeroAlCuadrado = SquareNumber(numeroFavorito);

        DisplayResult(nombreUsuario, numeroAlCuadrado);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string nombreUsuario = Console.ReadLine();
        return nombreUsuario;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string entradaUsuario = Console.ReadLine();
        int numeroFavorito = int.Parse(entradaUsuario);
        return numeroFavorito;
    }

    static int SquareNumber(int numero)
    {
        int resultado = numero * numero;
        return resultado;
    }

    static void DisplayResult(string nombreUsuario, int numeroAlCuadrado)
    {
        Console.WriteLine($"{nombreUsuario}, the square of your number is {numeroAlCuadrado}");
    }
}