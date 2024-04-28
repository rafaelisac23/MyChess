﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei( Cor cor, Tabuleiro tab , PartidaDeXadrez partida) : base(cor, tab)
        {
              this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }
        private bool podeMover(Posicao pos)
        {
            Peca p =Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);

            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
            }
            // nordeste
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // direita
            pos.definirValores(Posicao.Linha, Posicao.Coluna+1);

            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // sudeste
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // abaixo
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);

            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // sudoeste
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // esquerda
            pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);

            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // noroeste
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            if (Tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // # jogadaespecial roque

            if(QteMovimentos==0 && !partida.xeque)
            {
                // jogadaespecial roquepequeno
                Posicao PosT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);

                if (testeTorreParaRoque(PosT1))
                {

                    Posicao p1 = new Posicao(Posicao.Linha,Posicao.Coluna+1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tab.peca(p1)==null && Tab.peca(p2) == null ) 
                    {
                        mat[Posicao.Linha,Posicao.Coluna+2] = true;
                    }
                }
                // jogadaespecial roquegrande
                Posicao PosT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);

                if (testeTorreParaRoque(PosT2))
                {

                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return mat;

        }
    }
}
