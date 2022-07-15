using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraIR.Services
{
    public interface ITaxCalculator
    {
        double TaxCalculator(double value);
        double Aliquota(double value);
        double Taxa(double value);
    }
}
