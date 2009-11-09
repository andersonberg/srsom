using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOM
{
    public class Neuronio
    {
        private IList<double> pesos;

        public IList<double> Pesos
        {
            get { return pesos; }
            set { pesos = value; }
        }

        /// <summary>
        /// Inicializa o conjunto de pesos com valores aleatórios
        /// </summary>
        /// <param name="tamanho">tamanho do vetor de pesos</param>
        public void InicializarPesos(int tamanho)
        {
            Random random = new Random((int)DateTime.Now.TimeOfDay.TotalMilliseconds);

            for (int i = 0; i < tamanho; i++)
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
        public double CalcularDistanciaEclidiana(double entrada, double peso)
        {
            double diferenca = entrada - peso;
            double potencia = Math.Pow(diferenca, 2);

            return potencia;
        }
    }
}
