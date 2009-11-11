using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOM
{
    public class Neuronio
    {
        /// <summary>
        /// Vetor de pesos do neurônio
        /// </summary>
        private IList<double> pesos;

        /// <summary>
        /// Número de entradas de um neurônio
        /// </summary>
        private int numeroEntradas;

        public Neuronio(int entradas)
        {
            numeroEntradas = Math.Max(1, entradas);
            InicializarPesos();
        }


        public IList<double> Pesos
        {
            get { return pesos; }
            set { pesos = value; }
        }

        /// <summary>
        /// Inicializa o conjunto de pesos com valores aleatórios
        /// </summary>
        /// <param name="tamanho">tamanho do vetor de pesos</param>
        public void InicializarPesos()
        {
            Random random = new Random((int)DateTime.Now.TimeOfDay.TotalMilliseconds);

            for (int i = 0; i < this.numeroEntradas; i++)
            {
                double peso = random.NextDouble();

                this.pesos.Add(peso);
            }
        }

        /// <summary>
        /// Calcula a distância euclidiana entre uma entrada e um peso
        /// </summary>
        /// <param name="entrada">valor de uma entrada no conjunto de entradas</param>
        /// <param name="peso">valor de um peso no conjunto de pesos</param>
        /// <returns>valor da distância entre entrada e peso</returns>
        public double CalcularDistanciaEclidiana(List<double> entrada)
        {
            double distancia = 0.0;

            for (int i = 0; i < numeroEntradas; i++)
            {
                distancia += Math.Abs(pesos[i] - entrada[i]);
            }

            return distancia;
        }
    }
}
