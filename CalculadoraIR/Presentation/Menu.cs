using CalculadoraIR.Domain;
using CalculadoraIR.Services;

namespace CalculadoraIR.Presentation
{
    public class Menu : IScreen
    {
        private readonly ITaxCalculator _taxCalculator;
        //private readonly MenuMessages _menuMessages;
        private readonly IData _data;
        //MenuMessages menuMessages
        public Menu( ITaxCalculator taxCalculator, IData data)
        {
            //_menuMessages = menuMessages;
            _taxCalculator = taxCalculator;
            _data = data;
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
                if (_data.InputNulo(input))
                    Console.WriteLine(MenuMessages.msgNulo);
                else if (_data.InputValido(input))
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
