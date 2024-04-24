using System.Collections.Generic;
using tabuleiro;
namespace xadrez
{
    internal class PartidaDeXadrez
    {

        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }

        public Cor JogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;


        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            terminada = false;
            pecas=new HashSet<Peca>();//tem que ser antes de instanciar colocarPecas();
            capturadas =new HashSet<Peca>();//tem que ser antes de instanciar colocarPecas();
            colocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);

            Tab.ColocarPeca(p, destino);

            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            mudaJogador();

        }

        private void mudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;

            }
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.peca(pos)==null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }

            if(JogadorAtual != Tab.peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua !");
            }
            if (!Tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDestino(Posicao origem,Posicao destino)
        {
            if (!Tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posicao de destino inválida!!!");
            }
        }

       
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca>aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;

        }

        public void colocarNovaPeca(char coluna,int linha,Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }
        private void colocarPecas()
        {
            //Branca
            colocarNovaPeca('c', 1, new Torre(Cor.Branca, Tab));
            colocarNovaPeca('c', 2, new Torre(Cor.Branca, Tab));
            colocarNovaPeca('d', 2, new Torre(Cor.Branca, Tab));
            colocarNovaPeca('e', 2, new Torre(Cor.Branca, Tab));
            colocarNovaPeca('e', 1, new Torre(Cor.Branca, Tab));
            colocarNovaPeca('d', 1, new Rei(Cor.Branca, Tab));

            //Preta
            colocarNovaPeca('c', 7, new Torre(Cor.Preta, Tab));
            colocarNovaPeca('c', 8, new Torre(Cor.Preta, Tab));
            colocarNovaPeca('d', 7, new Torre(Cor.Preta, Tab));
            colocarNovaPeca('e', 7, new Torre(Cor.Preta, Tab));
            colocarNovaPeca('e', 8, new Torre(Cor.Preta, Tab));
            colocarNovaPeca('d', 8, new Rei(Cor.Preta, Tab));


        }
    }
}
