namespace CalculadoraIR.Services
{
    public interface ITaxCalculator
    {
        double TaxCalculator(double value);
        double Aliquota(double value);
        double Taxa(double value);
    }
}
