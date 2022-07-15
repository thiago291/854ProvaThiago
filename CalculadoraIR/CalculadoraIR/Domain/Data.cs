using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraIR.Domain
{
    public abstract class Data
    { 
        public abstract bool InputNulo(string input);
        public abstract bool InputValido(string input);
    }
}
