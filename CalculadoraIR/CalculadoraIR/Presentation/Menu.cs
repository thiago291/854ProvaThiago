using CalculadoraIR.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraIR.Presentation
{
    public class Menu : IScreen
    {
        /*private readonly ITaxCalculator _taxCalculator;
        private readonly MenuMessages _menuMessages;
        private readonly DataManipulation _dataManipulation;
        public Menu(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }
        public Menu(MenuMessages menuMessages)
        {
            _menuMessages = menuMessages;
        }
        public Menu(DataManipulation dataManipulation)
        {
            _dataManipulation = dataManipulation;
        }
        public Menu()
        {
        }*/

        private readonly DataManipulation dm = new();
        //private readonly TaxCalculation tx = new();

        public void MainMenu()
        {
            Console.WriteLine(MenuMessages.msgBoasVindas);
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine(MenuMessages.msgInput);
                var input = Console.ReadLine();
                double valorImposto;
                dm.InputNulo(input);
                if (dm.InputValido(input))
                {
                    TaxCalculation tx = new();
                    valorImposto = tx.TaxCalculator(double.Parse(input));
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
