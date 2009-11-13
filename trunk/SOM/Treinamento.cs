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
            PadraoEntrada padrao1 = new PadraoEntrada();
            padrao1.Label = "galinha";
            padrao1.Caracteristicas.Add(-1.0);
            padrao1.Caracteristicas.Add(-1.0);
            padrao1.Caracteristicas.Add(1.0);

            PadraoEntrada padrao2 = new PadraoEntrada();
            padrao2.Label = "elefante";
            padrao2.Caracteristicas.Add(1.0);
            padrao2.Caracteristicas.Add(-1.0);
            padrao2.Caracteristicas.Add(1.0);

            PadraoEntrada padrao3 = new PadraoEntrada();
            padrao3.Label = "peixe";
            padrao3.Caracteristicas.Add(-1.0);
            padrao3.Caracteristicas.Add(-1.0);
            padrao3.Caracteristicas.Add(-1.0);

            PadraoEntrada padrao4 = new PadraoEntrada();
            padrao4.Label = "ornitorrinco";
            padrao4.Caracteristicas.Add(1.0);
            padrao4.Caracteristicas.Add(1.0);
            padrao4.Caracteristicas.Add(-1.0);

            PadraoEntrada padrao5 = new PadraoEntrada();
            padrao5.Label = "escorpião";
            padrao5.Caracteristicas.Add(-1.0);
            padrao5.Caracteristicas.Add(1.0);
            padrao5.Caracteristicas.Add(1.0);

            PadraoEntrada padrao6 = new PadraoEntrada();
            padrao6.Label = "baleia";
            padrao6.Caracteristicas.Add(1.0);
            padrao6.Caracteristicas.Add(-1.0);
            padrao6.Caracteristicas.Add(-1.0);

            this.padroesEntrada = new List<PadraoEntrada>();
            padroesEntrada.Add(padrao1);
            padroesEntrada.Add(padrao2);
            padroesEntrada.Add(padrao3);
            padroesEntrada.Add(padrao4);
            padroesEntrada.Add(padrao5);
            padroesEntrada.Add(padrao6);

            this.numeroPadroes = padroesEntrada.Count;

            this.mapa = new MapaSOM(this.numeroPadroes, this.padroesEntrada);
            this.saida = mapa.AlgoritmoAprendizado();
        }

        public StringBuilder Teste()
        {
            StringBuilder resultadoTeste = new StringBuilder();
            List<PadraoEntrada> padroesTeste = new List<PadraoEntrada>();

            PadraoEntrada padraoTeste = new PadraoEntrada();
            padraoTeste.Label = "equidna";
            padraoTeste.Caracteristicas = new List<double>();
            padraoTeste.Caracteristicas.Add(1.0);
            padraoTeste.Caracteristicas.Add(1.0);
            padraoTeste.Caracteristicas.Add(1.0);

            resultadoTeste.Append(" Padrão: " + padraoTeste.Label + " Neurônio: " + 
                (mapa.GetVencedor(padraoTeste.Caracteristicas)).Coordenadas.ToString() + "\n");

            padraoTeste.Label = "anaconda";
            padraoTeste.Caracteristicas = new List<double>();
            padraoTeste.Caracteristicas.Add(-1.0);
            padraoTeste.Caracteristicas.Add(1.0);
            padraoTeste.Caracteristicas.Add(-1.0);

            resultadoTeste.Append(" Padrão: " + padraoTeste.Label + " Neurônio: " +
                (mapa.GetVencedor(padraoTeste.Caracteristicas)).Coordenadas.ToString() + "\n");

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
                string[] padrao = line.Split('|');
            }

            //TODO: Implementar lógica de leitura do arquivo

            return padroes;
        }
    }
}
