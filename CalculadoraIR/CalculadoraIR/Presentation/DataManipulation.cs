using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculadoraIR.Domain;

namespace CalculadoraIR.Presentation
{
    public class DataManipulation : Data
    {
        public override bool InputNulo(string input) {
            return string.IsNullOrWhiteSpace(input);
        }

        public override bool InputValido(string input)
        {
            double conv = 0;
            if (double.TryParse(input, out conv))
                return true; 
            else
                return false;
        }
    }
}
