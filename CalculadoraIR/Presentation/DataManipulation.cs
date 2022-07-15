using CalculadoraIR.Domain;

namespace CalculadoraIR.Presentation
{
    public class DataManipulation : IData
    {
        public bool InputNulo(string input) {
            return string.IsNullOrWhiteSpace(input);
        }

        public bool InputValido(string input)
        {
            if (double.TryParse(input, out double _))
                return true;
            else
                return false;
        }
    }
}
