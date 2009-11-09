using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOM
{
    public class MapaSOM
    {
        private PadraoEntrada entrada;
        private Neuronio neuronio;
        private IList<PadraoEntrada> entradas;
        private IList<IList<Neuronio>> mapa;

        public Neuronio BestMatchingNeuron(PadraoEntrada entrada)
        {
            double menorDistancia = Double.PositiveInfinity;
            Neuronio bestMatchingNeuron = new Neuronio();

            foreach (double entradaAtual in entrada.Caracteristicas)
            {
                foreach (IList<IList<Neuronio>> linhaNeuronios in mapa)
                {
                    foreach (Neuronio neuronio in linhaNeuronios)
                    {
                        double distancia = neuronio.CalcularDistanciaEclidiana(entradaAtual, 
                            neuronio.Pesos[entrada.Caracteristicas.IndexOf(entradaAtual)]);

                        if (distancia < menorDistancia)
                        {
                            menorDistancia = distancia;
                            bestMatchingNeuron = neuronio;
                        }
                    }
                }
            }

            return bestMatchingNeuron;
        }

        public void Treinar()
        {

        }
    }
}
