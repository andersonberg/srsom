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

        private double vizinhancaInicial;

        /// <summary>
        /// Coordenadas do neurônio no mapa
        /// </summary>
        private Point coordenadas;

        /// <summary>
        /// Calcula o tamanho da vizinhança de um neurônio
        /// </summary>
        /// <param name="iteracao"></param>
        /// <returns></returns>
        private double Vizinhaca(int iteracao)
        {
            double valor = 1000 / Math.Log(vizinhancaInicial);
            double vizinhanca = vizinhancaInicial * Math.Exp(-iteracao / valor);
            return vizinhanca;
        }

        /// <summary>
        /// Coordenadas do neurônio no mapa
        /// </summary>
        public Point Coordenadas
        {
            get { return coordenadas; }
            set { coordenadas = value; }
        }

        public Neuronio(int entradas)
        {
            numeroEntradas = Math.Max(1, entradas);
            InicializarPesos();
        }

        public List<double> Pesos
        {
            get { return pesos; }
            set { pesos = value; }
        }

        /// <summary>
        /// Inicializa o conjunto de pesos com valores aleatórios
        /// </summary>
        public void InicializarPesos()
        {
            Random random = new Random((int)DateTime.Now.TimeOfDay.TotalMilliseconds);

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

        public void AtualizaPesos()
        {

        }

        public void Gaussiana(Point coordenadas)
        {

        }
    }
}
