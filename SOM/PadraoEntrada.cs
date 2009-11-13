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

        public PadraoEntrada()
        {
            this.label = string.Empty;
            this.Caracteristicas = new List<double>();
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
