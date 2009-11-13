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

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        public PadraoEntrada()
        {
            this.Caracteristicas = new List<double>();
        }

        public List<double> Caracteristicas
        {
            get { return caracteristicas; }
            set { caracteristicas = value; }
        }
    }
}
