using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeira
{
    public class Menus
    {
        public Menus() { }

        private ContratoPessoaFisica cadPF = new();

        public Menus(ContratoPessoaFisica cadPF)
        {
            this.cadPF = cadPF;
        }

        private ContratoPessoaJuridica cadPJ = new();

        public Menus(ContratoPessoaJuridica cadPJ)
        {
            this.cadPJ = cadPJ;
        }

        static int inputMenu;
        static string input, tipo;
        static string txtMenu = @"

Escolha sua opção de cadastro:
1 - Pessoa Física (PF)
2 - Pessoa Jurídica (PJ)";

        public static void testeInput()
        {
            input = Console.ReadLine();
            if (!int.TryParse(input, out inputMenu))
            {
                Console.Clear();
                Console.WriteLine(@$"Opção inválida. {txtMenu}");
                testeInput();
            }

            switch (inputMenu)
            {
                case 1:
                    tipo = "PF";
                    break;
                case 2:
                    tipo = "PJ";
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(@$"Opção inválida. {txtMenu}");
                    testeInput();
                    break;
            }
        }

        public void MainMenu()
        {
            Console.WriteLine($@"Seja bem vindo à Let's Finance. {txtMenu}");
            testeInput();
            MenuCadastro();
        }

        public void MenuCadastro()
        {
            switch (tipo)
            {
                case "PF":
                    Console.WriteLine(tipo);
                    cadPF.cadastro();
                    cadPF.ExibirInfo();
                    break;
                case "PJ":
                    Console.WriteLine(tipo);
                    cadPJ.cadastro();
                    cadPJ.ExibirInfo();
                    break;
            }

        }
    }
}
