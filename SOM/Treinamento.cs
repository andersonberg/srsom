using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SOM
{
    public class Treinamento
    {
        private int numeroPadroes;
        private List<PadraoEntrada> padroesEntrada;

        public Treinamento()
        {
            MapaSOM mapa = new MapaSOM(this.numeroPadroes);

            Neuronio vencedor;
            int iteracao = 1;
            while (iteracao < 1000)
            {
                foreach (PadraoEntrada padraoEntrada in padroesEntrada)
                {
                    mapa.PreencheMapa(padraoEntrada.Caracteristicas.Count);
                    vencedor = mapa.GetVencedor(padraoEntrada.Caracteristicas);
                    vencedor.AtualizaPesos(padraoEntrada.Caracteristicas, vencedor.Coordenadas, iteracao);
                }
                iteracao++;
            }
        }

        public List<PadraoEntrada> LerArquivo(string arquivo)
        {
            List<PadraoEntrada> padroes = new List<PadraoEntrada>();

            StreamReader stream = new StreamReader(arquivo);

            //TODO: Implementar lógica de leitura do arquivo

            return padroes;
        }
    }
}
