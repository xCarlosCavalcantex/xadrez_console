using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();

            while (!partida.terminada)
            {
                try
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + partida.turno);
                    Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoOrigem(origem);

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDestino(origem, destino);

                    //partida.executarMovimento(origem, destino);

                    partida.realizaJogada(origem, destino);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }

            Tela.imprimirTabuleiro(partida.tab);
        }
    }
}
