using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOM
{
    public class PadraoEntrada
    {
        private IList<double> caracteristicas;

        public IList<double> Caracteristicas
        {
            get { return caracteristicas; }
            set { caracteristicas = value; }
        }
    }
}
