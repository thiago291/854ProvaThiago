using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculadoraIR.Domain;

namespace CalculadoraIR.Services
{
    public class ClientType3 : Data, ITaxCalculator
    {
        public double Aliquota
        {
            get
            {
                return aliquota;
            }
            set
            {
                aliquota = 0.15;
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
                taxa = 4257.57;
            }
        }
        public double TaxCalculation(double value)
        {
            return (value * aliquota) - taxa;
        }
    }
}
