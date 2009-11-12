using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOM
{
    public class PadraoEntrada
    {
        private List<double> caracteristicas;

        public List<double> Caracteristicas
        {
            get { return caracteristicas; }
            set { caracteristicas = value; }
        }
    }
}
