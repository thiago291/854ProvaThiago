using CalculadoraIR.Services;

namespace CalculadoraIR.Presentation
{
    public class Menu : IScreen
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly MenuMessages _menuMessages;
        private readonly DataManipulation _dataManipulation;
        public Menu(MenuMessages menuMessages)
        {
            _menuMessages = menuMessages;
        }
        public Menu(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }
        public Menu(DataManipulation dataManipulation)
        {
            _dataManipulation = dataManipulation;
        }

        public void MainMenu()
        {
            MenuFlow();
        }
        public void MenuFlow()
        {
            Console.WriteLine(MenuMessages.msgBoasVindas);
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine(MenuMessages.msgInput);
                var input = Console.ReadLine();
                double valorImposto;
                _dataManipulation.InputNulo(input);
                if (_dataManipulation.InputValido(input))
                {
                    valorImposto = _taxCalculator.TaxCalculator(double.Parse(input));
                    if (valorImposto > 0)
                        Console.WriteLine(MenuMessages.msgValor + valorImposto.ToString("N2"));
                    else
                        Console.WriteLine(MenuMessages.msgIsento);
                    valid = true;
                }
                else
                    Console.WriteLine(MenuMessages.msgInvalida);
            }
        }

        
    }
}
