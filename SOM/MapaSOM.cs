using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SOM
{
    public class MapaSOM
    {
        /// <summary>
        /// Lista com todos os padrões de entrada
        /// </summary>
        private List<PadraoEntrada> entradas;

        /// <summary>
        /// Matriz de neurônios
        /// </summary>
        private Neuronio[,] neuronios;

        /// <summary>
        /// Representa a quantidade de neurônios no mapa
        /// </summary>
        private int numeroNeuronios;

        /// <summary>
        /// Representa a quantidade de características de cada entrada.
        /// </summary>
        private int numeroEntradas;

        public MapaSOM(int tamanhoMapa, List<PadraoEntrada> padroesEntrada)
        {
            this.numeroNeuronios = tamanhoMapa;
            this.entradas = padroesEntrada;
            this.numeroEntradas = 7; //padroesEntrada[0].Caracteristicas.Count;
            PreencheMapa(this.numeroEntradas);
        }

        public List<PadraoEntrada> Entradas
        {
            get { return entradas; }
            set { entradas = value; }
        }

        public Neuronio[,] Neuronios
        {
            get { return neuronios; }
            set { neuronios = value; }
        }


        public List<double> NormalizaEntrada(List<double> entrada)
        {
            double nn = 0;
            for (int i = 0; i < entrada.Count; i++)
            {
                nn += (entrada[i] * entrada[i]);
            }
            nn = Math.Sqrt(nn);
            for (int i = 0; i < entrada.Count; i++)
            {
                entrada[i] /= nn;
            }

            return entrada;
        }

        /// <summary>
        /// Método que apresenta uma determinada entrada ao mapa e chama outros métodos para calcular a saída.
        /// </summary>
        /// <returns></returns>
        public StringBuilder AlgoritmoAprendizado()
        {
            StringBuilder saida = new StringBuilder();
            Neuronio vencedor;
            int iteracao = 1;
            //TODO: Substituir o valor 500 por uma variável que represente o número de ciclos
            while (iteracao < 500 * numeroNeuronios)
            {
                foreach (PadraoEntrada padraoEntrada in entradas)
                {
                    padraoEntrada.Caracteristicas = NormalizaEntrada(padraoEntrada.Caracteristicas);
                    //Neurônio que representa uma dada entrada
                    vencedor = GetVencedor(padraoEntrada.Caracteristicas);

                    if (iteracao == (500 * numeroNeuronios -1))
                    {
                        saida.Append("Iteração: " + iteracao.ToString() + " Padrão: " + padraoEntrada.Label + " Neurônio: " + vencedor.Coordenadas.ToString() + "\n");
                        padraoEntrada.Neuronio = vencedor;
                    }

                    foreach (Neuronio neuron in this.neuronios)
                    {
                        neuron.AtualizaPesos(padraoEntrada.Caracteristicas, vencedor.Coordenadas, iteracao);
                    }
                }
                iteracao++;
            }

            return saida;
        }

        /// <summary>
        /// Preenche o mapa com a quantidade de neurônios
        /// </summary>
        /// <param name="numeroEntradas">Quantidade de características das entradas para formar o vetor de pesos de um neurônio</param>
        public void PreencheMapa(int numeroEntradas)
        {
            this.neuronios = new Neuronio[numeroNeuronios, numeroNeuronios];
            DateTime agora = DateTime.Now;
            for (int i = 0; i < numeroNeuronios; i++)
            {
                for (int j = 0; j < numeroNeuronios; j++)
                {   
                    Random random = new Random((int)agora.TimeOfDay.TotalMilliseconds);
                    this.neuronios[i, j] = new Neuronio(i, j, numeroEntradas, 0.01, random, numeroNeuronios);
                    agora = agora.AddHours(1);
                }
            }
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
