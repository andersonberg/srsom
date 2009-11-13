using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SOM
{
    public class Treinamento
    {
        private int numeroPadroes;
        private List<PadraoEntrada> padroesEntrada;
        private StringBuilder saida;
        private MapaSOM mapa;

        public StringBuilder Saida
        {
            get { return saida; }
            set { saida = value; }
        }

        public Treinamento()
        {
            this.padroesEntrada = this.LerArquivo(@"E:\srsom\wine\wine_treina.data");

            this.numeroPadroes = padroesEntrada.Count;

            double raiz = Math.Ceiling(Math.Sqrt((double)this.numeroPadroes));
            int inteiro = Convert.ToInt32(raiz);

            this.mapa = new MapaSOM(inteiro, this.padroesEntrada);
            this.saida = mapa.AlgoritmoAprendizado();
        }

        public StringBuilder Teste()
        {
            StringBuilder resultadoTeste = new StringBuilder();
            List<PadraoEntrada> padroesTeste = new List<PadraoEntrada>();

            padroesTeste = this.LerArquivo(@"E:\srsom\wine\wine_testa.data");

            foreach (PadraoEntrada padraoTeste in padroesTeste)
            {
                resultadoTeste.Append(" Padrão: " + padraoTeste.Label + " Neurônio: " +
                (mapa.GetVencedor(padraoTeste.Caracteristicas)).Coordenadas.ToString() + "\n");
            }

            return resultadoTeste;
        }

        public List<PadraoEntrada> LerArquivo(string arquivo)
        {
            List<PadraoEntrada> padroes = new List<PadraoEntrada>();

            FileStream file = File.Open(arquivo, FileMode.Open, FileAccess.Read); 

            StreamReader stream = new StreamReader(file);

            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine();
                string[] padraoString = line.Split(',');
                PadraoEntrada padraoEntrada = new PadraoEntrada();
                padraoEntrada.Label = padraoString[0];

                for (int i = 1; i < padraoString.Length; i++)
                {
                    padraoEntrada.Caracteristicas.Add(Convert.ToDouble(padraoString[i]));
                }

                padroes.Add(padraoEntrada);
            }

            stream.Close();
            file.Close();

            return padroes;
        }

        public void EscreveArquivo(StringBuilder texto)
        {
            File.WriteAllText(@"E:\srsom\wine\wine_result.data", texto.ToString());
        }
    }
}
