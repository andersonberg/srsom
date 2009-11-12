using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SOM
{
    public class Treinamento
    {
        //MapaSOM mapa = new MapaSOM();

        public List<List<double>> LerArquivo(string arquivo)
        {
            List<List<double>> padroes = new List<List<double>>();

            StreamReader stream = new StreamReader(arquivo);

            //TODO: Implementar lógica de leitura do arquivo

            return padroes;
        }
    }
}
