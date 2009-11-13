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

        public List<PadraoEntrada> Entradas
        {
            get { return entradas; }
            set { entradas = value; }
        }
        private Neuronio[,] neuronios;
        private int numeroNeuronios;
        private int numeroEntradas;

        public MapaSOM(int tamanhoMapa, List<PadraoEntrada> padroesEntrada)
        {
            this.numeroNeuronios = tamanhoMapa;
            this.entradas = padroesEntrada;
            PreencheMapa(entradas.Count);
        }

        public StringBuilder AlgoritmoAprendizado()
        {
            StringBuilder saida = new StringBuilder();
            Neuronio vencedor;
            int iteracao = 1;
            while (iteracao < 500)
            {
                foreach (PadraoEntrada padraoEntrada in entradas)
                {
                    vencedor = GetVencedor(padraoEntrada.Caracteristicas);

                    saida.Append("Iteração: " + iteracao.ToString() + " Padrão: " + padraoEntrada.Label + " Neurônio: " + vencedor.Coordenadas.ToString() + "\n");

                    foreach (Neuronio neuron in this.neuronios)
                    {
                        neuron.AtualizaPesos(padraoEntrada.Caracteristicas, vencedor.Coordenadas, iteracao);
                    }
                }
                iteracao++;
            }

            return saida;
        }

        public void PreencheMapa(int numeroEntradas)
        {
            this.neuronios = new Neuronio[numeroNeuronios, numeroNeuronios];
            DateTime agora = DateTime.Now;
            for (int i = 0; i < numeroNeuronios; i++)
            {
                for (int j = 0; j < numeroNeuronios; j++)
                {   
                    Random random = new Random((int)agora.TimeOfDay.TotalMilliseconds);
                    //TODO: Passar o numero de caracteristicas de cada entrada
                    this.neuronios[i, j] = new Neuronio(i, j, 3, 0.01, random);
                    agora = agora.AddHours(1);
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
