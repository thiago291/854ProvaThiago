using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculadoraIR.Domain;

namespace CalculadoraIR.Services
{
    public class ClientType2 : Data, ITaxCalculator
    {
        public double Aliquota
        {
            get
            {
                return aliquota;
            }
            set
            {
                aliquota = 0.075;
            }
        }

        public double Taxa
        {
            get
            {
                return taxa;
            }
            set
            {
                taxa = 1713.58;
            }
        }
        public double TaxCalculation(double value)
        {
            return (value * aliquota) - taxa;
        }
    }
}
