
using System;
using tabuleiro;
using xadrez;



namespace MeuXadrez
{
    internal class Program
    {
        static void Main(string[] args)


        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.Tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();

                    //imprimindo denovo com as posições possiveis marcadas

                    bool[,] posicoesPossiveis=partida.Tab.peca(origem).movimentosPossiveis();
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.Tab,posicoesPossiveis);

                    // fim
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }

                Tela.imprimirTabuleiro(partida.Tab);
            }

            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();

        }

       
    }
}
