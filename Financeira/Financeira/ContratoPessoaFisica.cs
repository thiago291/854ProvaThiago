using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeira
{
    public class ContratoPessoaFisica : Contrato
    {
        private int Idade { get; set; }
        private DateTime DataDeNascimento { get; set; }
        private decimal CPF { get; set; }

        public decimal cpf;
        public DateTime dataDeNascimento;
        public int idade;

        public ContratoPessoaFisica() {
            this.CPF = cpf;
            this.DataDeNascimento = dataDeNascimento;
            this.Idade = idade;
        }

        public override void cadastro()
        {
            Console.Clear();
            cpf = TestesEValidacoes.testeCPFouCNPJouIE("PF");
            base.cadastro();
            dataDeNascimento = TestesEValidacoes.testeData();
            idade = TestesEValidacoes.calculaIdade(dataDeNascimento);
            calcularPrestacao();
        }

        public override void calcularPrestacao()
        {
            base.calcularPrestacao();
            if (idade <= 30)
                valorPrestacao += 1;
            else if (idade <= 40)
                valorPrestacao += 2;
            else if (idade <= 50)
                valorPrestacao += 3;
            else 
                valorPrestacao += 4;
        }

        public override void ExibirInfo()
        {
            Console.Clear();
            Console.WriteLine(@$"======================INFORMAÇÕES======================
Nome do contratante: {contratante}
CPF do contratante: {cpf}
Idade do contratante: {idade}");
            base.ExibirInfo();
        }
    }
}
