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
            if (double.TryParse(input, out double _))
                return true;
            else
                return false;
        }
    }
}
