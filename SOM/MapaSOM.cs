using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SOM
{
    public class MapaSOM
    {
        private List<PadraoEntrada> entradas;
        private Neuronio[,] neuronios;
        private int numeroNeuronios;
        private int numeroEntradas;

        public MapaSOM(int tamanhoMapa)
        {
            this.numeroNeuronios = tamanhoMapa;
            this.neuronios = new Neuronio[tamanhoMapa, tamanhoMapa];
        }

        public void PreencheMapa(int numeroEntradas)
        {
            for (int i = 0; i < numeroNeuronios; i++)
            {
                for (int j = 0; j < numeroNeuronios; j++)
                {
                    this.neuronios[i, j] = new Neuronio(i, j, numeroEntradas, 0.01);
                }
            }
        }

        public Neuronio[,] Neuronios
        {
            get { return neuronios; }
            set { neuronios = value; }
        }

        /// <summary>
        /// Busca o neurônio com a menor distância para um PadraoEntrada
        /// </summary>
        /// <param name="entrada">Conjunto de características de um PadraoEntrada</param>
        /// <returns>Neurônio vencedor</returns>
        public Neuronio GetVencedor(List<double> entrada)
        {
            double min = neuronios[0, 0].CalcularDistanciaEclidiana(entrada);
            double distancia;
            Neuronio vencedor = neuronios[0,0];

            for (int i = 0; i < numeroNeuronios; i++)
            {
                for (int j = 0; j < numeroNeuronios; j++)
                {
                    distancia = neuronios[i, j].CalcularDistanciaEclidiana(entrada);
                    if (distancia < min)
                    {
                        min = distancia;
                        vencedor = neuronios[i, j];
                    }
                }
            }

            return vencedor;
        }
    }
}
