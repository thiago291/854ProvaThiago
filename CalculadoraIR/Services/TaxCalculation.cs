namespace CalculadoraIR.Services
{
    public class TaxCalculation : ITaxCalculator
    {
        private double aliquota, taxa;
        public double Aliquota(double value)
        {
            if (value >= 0 && value <= 22847.76)
                aliquota = 0;
            else if (value >= 22847.76 && value <= 33919.80)
                aliquota = 0.075;
            else if (value >= 33919.81 && value <= 45012.60)
                aliquota = 0.150;
            else if (value >= 45012.61 && value <= 55976.16)
                aliquota = 0.225;
            else if (value >= 55976.17)
                aliquota = 0.275;
            return aliquota;
        }

        public double Taxa(double value)
        {
            if (value >= 0 && value <= 22847.76)
                taxa = 0;
            else if (value >= 22847.76 && value <= 33919.80)
                taxa = 1713.58;
            else if (value >= 33919.81 && value <= 45012.60)
                taxa = 4257.57;
            else if (value >= 45012.61 && value <= 55976.16)
                taxa = 7633.51;
            else if (value >= 55976.17)
                taxa = 10432.32;
            return taxa;
        }

        public double TaxCalculator(double value)
        {
            Aliquota(value);
            Taxa(value);
            return (value * aliquota) - taxa;
        }
    }
}
