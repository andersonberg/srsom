using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SOM
{
    public class Neuronio
    {
        /// <summary>
        /// Vetor de pesos do neurônio
        /// </summary>
        private List<double> pesos;

        /// <summary>
        /// Número de entradas de um neurônio
        /// </summary>
        private int numeroEntradas;

        private double sigmaInicial;

        private double taxaAprendizadoInicial;

        private string movies;

        private bool teste;

        public bool Teste
        {
            get { return teste; }
            set { teste = value; }
        }

        /// <summary>
        /// Coordenadas do neurônio no mapa
        /// </summary>
        private Point coordenadas;

        /// <summary>
        /// Calcula o tamanho da vizinhança de um neurônio
        /// </summary>
        /// <param name="iteracao"></param>
        /// <returns></returns>
        private double Sigma(int iteracao)
        {
            double valor = 1000 / Math.Log(sigmaInicial);
            double sigma = sigmaInicial * Math.Exp(-iteracao / valor);
            return sigma;
        }

        private double TaxaAprendizado(int iteracao)
        {
            double valor = 0.9 * (1 - ((double)iteracao / 1000));
            if (valor < taxaAprendizadoInicial)
            {
                valor = taxaAprendizadoInicial;
            }
            return valor;
        }

        /// <summary>
        /// Coordenadas do neurônio no mapa
        /// </summary>
        public Point Coordenadas
        {
            get { return coordenadas; }
            set { coordenadas = value; }
        }

        public string Movies
        {
            get { return movies; }
            set { movies = value; }
        }

        public Neuronio()
        {
            //this.movies = string.Empty;
        }

        public Neuronio(int x, int y, int entradas, double taxaAprendizado, Random random, int numeroNeuroniosMapa)
        {
            this.pesos = new List<double>();
            coordenadas.X = x;
            coordenadas.Y = y;
            numeroEntradas = Math.Max(1, entradas);
            this.taxaAprendizadoInicial = taxaAprendizado;
            this.sigmaInicial = 0.6 * numeroNeuroniosMapa * 2;
            InicializarPesos(random);
        }

        public List<double> Pesos
        {
            get { return pesos; }
            set { pesos = value; }
        }

        /// <summary>
        /// Inicializa o conjunto de pesos com valores aleatórios
        /// </summary>
        public void InicializarPesos(Random random)
        {
            //A dimensão do vetor de pesos de um neurônio é igual ao número de características dos padrões de entrada
            for (int i = 0; i < this.numeroEntradas; i++)
            {
                //Os pesos são inicializados com valores aleatórios
                double peso = random.NextDouble();

                //Array de pesos do neurônio
                this.pesos.Add(peso);
            }
        }

        /// <summary>
        /// Calcula a distância euclidiana entre uma entrada os pesos de um neurônio
        /// </summary>
        /// <param name="entrada">lista com padrões de uma entrada</param>
        /// <returns>valor da distância entre entrada e peso</returns>
        public double CalcularDistanciaEclidiana(List<double> entrada)
        {
            double distancia = 0.0;

            for (int i = 0; i < numeroEntradas; i++)
            {
                distancia += Math.Pow(this.pesos[i] - entrada[i], 2);
            }
            distancia = Math.Sqrt(distancia);

            return distancia;
        }

        public void AtualizaPesos(List<double> entrada, Point coordenadasVencedor, int iteracao)
        {
            double novoPeso = 0;
            for (int i = 0; i < pesos.Count(); i++)
            {
                novoPeso = taxaAprendizadoInicial * Gaussiana(coordenadasVencedor, iteracao) * (entrada[i] - pesos[i]);
                pesos[i] += novoPeso;
            }
        }

        public double Gaussiana(Point coordenadasVencedor, int iteracao)
        {
            double distancia = 0;
            double resultado = 0;
            distancia = Math.Sqrt(Math.Pow((coordenadasVencedor.X - coordenadas.X), 2) + Math.Pow((coordenadasVencedor.Y - coordenadas.Y), 2));
            resultado = Math.Exp(-(distancia * distancia) / (Math.Pow(Sigma(iteracao), 2)));

            return resultado;
        }
    }
}
