using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOM
{
    public class MapaSOM
    {
        private Neuronio neuronio;
        private List<double> entrada;
        private IList<double> saida;
        private IList<Neuronio> neuronios;
        private int numeroNeuronios;

        public int GetVencedor()
        {
            double min = saida[0];
            int indexMin = 0;
            for (int i = 0; i < saida.Count(); i++)
            {
                if (saida[0] < min)
                {
                    min = saida[0];
                    indexMin = i;
                }
            }

            return indexMin;
        }

        public List<double> ComputarSaida()
        {
            for (int i = 0; i < numeroNeuronios; i++)
            {
                saida[i] = neuronios[i].CalcularDistanciaEclidiana(entrada);
            }

            return saida.ToList();
        }
    }
}
