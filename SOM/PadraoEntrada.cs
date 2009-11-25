using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOM
{
    public class PadraoEntrada
    {
        private List<double> caracteristicas;
        private string label;
        private Neuronio neuronio;
        private int id;
        private List<int> genero;
        private int locacoes;

        public PadraoEntrada()
        {
            this.label = string.Empty;
            this.Caracteristicas = new List<double>();
            this.genero = new List<int>();
        }

        public override string ToString()
        {
            string padrao;
            StringBuilder generos = new StringBuilder();

            for (int i = 0; i < this.genero.Count; i++)
            {
                if (this.genero[i] == 1)
                {
                    generos.Append(Treinamento.generosFilmes[i] + " ");
                }
            }

            padrao = "Título: " + this.label + " Gêneros: " + generos + " Número de locações: " + locacoes + 
                " Neurônio: " + this.neuronio.Coordenadas;

            return padrao;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public List<int> Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public int Locacoes
        {
            get { return locacoes; }
            set { locacoes = value; }
        }

        public Neuronio Neuronio
        {
            get { return neuronio; }
            set { neuronio = value; }
        }

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        public List<double> Caracteristicas
        {
            get { return caracteristicas; }
            set { caracteristicas = value; }
        }
    }
}
