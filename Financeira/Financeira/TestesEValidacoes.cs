using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Financeira
{
    public class TestesEValidacoes
    {
        static string input;
        public static void inputNaoNulo()
        {
            bool inputValido = false;
            while (!inputValido)
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Valor não pode ser vazio.");
                    Console.WriteLine("Digite um valor válido:");
                }
                else
                    inputValido = true;
            }
        }

        public static bool inputSemLetras(string input)
        {
            if (input.Any(x => char.IsLetter(x)))
                return false;
            else
                return true;
        }

        public static decimal testeCPFouCNPJouIE(string tipo)
        {
            bool inputValido = false;
            string inputLimpo = "";
            while (!inputValido)
            {
                switch (tipo)
                {
                    case "PF":
                        Console.WriteLine("Insira o CPF do contratante:");
                        break;
                    case "PJ":
                        Console.WriteLine("Insira o CNPJ do contratante");
                        break;
                    case "IE":
                        Console.WriteLine("Insira a Inscrição Estadual do contratante");
                        break;
                }

                inputNaoNulo();

                if (!inputSemLetras(input))
                {
                    Console.WriteLine("Por favor, digite somente números e símbolos válidos.");
                    continue;
                }

                inputLimpo = Regex.Replace(input, @"[^\d]", "");

                switch (tipo)
                {
                    case "PF":
                        if (inputLimpo.Length != 11)
                        {
                            Console.WriteLine("Tamanho do CPF inválido");
                            continue;
                        }
                        break;
                    case "PJ":
                        if (inputLimpo.Length != 14)
                        {
                            Console.WriteLine("Tamanho do CNPJ inválido");
                            continue;
                        }
                        break;
                    case "IE":
                        if (inputLimpo.Length != 9)
                        {
                            Console.WriteLine("Tamanho da Inscrição Estadual inválido");
                            continue;
                        }
                        break;
                }
                inputValido = true;
            }
            return Convert.ToDecimal(inputLimpo);
        }

        public static string testeContratante()
        {
            Console.WriteLine("Digite o nome do contratante:");
            inputNaoNulo();
            return input;
        }

        public static decimal testeValor()
        {
            bool inputValido = false;
            decimal inputValor = 0;
            while (!inputValido)
            {
                Console.WriteLine("Digite o valor do contrato:");
                inputNaoNulo();
                if (!decimal.TryParse(input, out inputValor))
                    Console.WriteLine("Por favor, digite um valor válido.");
                else
                    inputValido = true;
            }
            return inputValor;
        }
        public static int testePrazo()
        {
            bool inputValido = false;
            int inputInt = 0;
            while (!inputValido)
            {
                Console.WriteLine("Digite o prazo do contrato:");
                inputNaoNulo();
                if (!int.TryParse(input, out inputInt))
                    Console.WriteLine("Por favor, digite um valor válido.");
                else
                    inputValido = true;
            }
            return inputInt;
        }

        public static DateTime testeData()
        {
            bool inputValido = false;
            DateTime inputDT = DateTime.Now;
            while (!inputValido)
            {
                Console.WriteLine("Digite sua data de nascimento no formato DD/MM/AAAA:");
                inputNaoNulo();
                if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out inputDT))
                    Console.WriteLine("Data inválida. Digite a data em um formato válido.");
                else if (inputDT > DateTime.Now)
                    Console.WriteLine("Data de nascimento não pode ser superior à data de hoje.");
                else
                    inputValido = true;
            }
            return inputDT;
        }

        public static int calculaIdade(DateTime dataDeNascimento)
        {
            int dataAtual = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dataNascimento = int.Parse(dataDeNascimento.ToString("yyyyMMdd"));
            int idade = (dataAtual - dataNascimento) / 10000;
            return idade;
        }
    }
}
