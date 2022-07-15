using CalculadoraIR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraIR.Services
{
    public class ClientType5 : Data, ITaxCalculator
    {
        public double Aliquota
        {
            get
            {
                return aliquota;
            }
            set
            {
                aliquota = 0.275;
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
                taxa = 10432.32;
            }
        }
        public double TaxCalculation(double value)
        {
            return (value * aliquota) - taxa;
        }
    }
}
