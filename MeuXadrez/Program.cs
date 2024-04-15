using System;
using tabuleiro;
namespace MeuXadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Posicao P;

            P = new(3, 4);

            Console.WriteLine("posi: "+P);

            Console.ReadLine();
        }
    }
}
