using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SOM
{
    public class MapaSOM
    {
        private Neuronio neuronio;
        private List<PadraoEntrada> entradas;
        private double[,] distancias;
        private Neuronio[,] neuronios;
        private int numeroNeuronios;

        public MapaSOM(int tamanhoMapa)
        {
            this.numeroNeuronios = tamanhoMapa;
        }

        public Neuronio[,] Neuronios
        {
            get { return neuronios; }
            set { neuronios = value; }
        }

        public int GetVencedor()
        {
            double min = distancias[0,0];
            int indexMin = 0;
            for (int i = 0; i < numeroNeuronios; i++)
            {
                
                if (distancias[0] < min)
                {
                    min = distancias[0];
                    indexMin = i;
                }
            }

            return indexMin;
        }

        /// <summary>
        /// Obtém as distâncias entre o padrão de entrada e cada neurônio do mapa
        /// </summary>
        /// <param name="entrada">Conjunto de características de um PadraoEntrada</param>
        /// <returns>Lista com todas as distâncias</returns>
        public double[,] ComputarSaida(List<double> entrada)
        {
            for (int i = 0; i < numeroNeuronios; i++)
            {
                for (int j = 0; j < numeroNeuronios; j++)
                {
                    distancias[i, j] = neuronios[i, j].CalcularDistanciaEclidiana(entrada);
                }
            }

            return distancias;
        }

        public List<List<double>> LerArquivo(string arquivo)
        {
            List<List<double>> padroes = new List<List<double>>();

            StreamReader stream = new StreamReader(arquivo);

            //TODO: Implementar lógica de leitura do arquivo

            return padroes;
        }
    }
}
