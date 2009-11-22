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
        private int genero;
        private int locacoes;

        public PadraoEntrada()
        {
            this.label = string.Empty;
            this.Caracteristicas = new List<double>();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Genero
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
