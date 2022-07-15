using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeira
{
    public class Contrato
    {
        private Guid IdContrato { get => Guid.NewGuid(); }
        private string Contratante { get; set; }
        private decimal Valor { get; set; }
        private int Prazo { get; set; }

        public Guid idContrato;
        public int prazo;
        public decimal valor, valorPrestacao = 0;
        public string contratante;
        public string input;


        public Contrato()
        {
            idContrato = IdContrato;
            this.Contratante = contratante;
            this.Valor = valor;
            this.Prazo = prazo;
        }

        public virtual void cadastro()
        {
            contratante = TestesEValidacoes.testeContratante();
            valor = TestesEValidacoes.testeValor();
            prazo = TestesEValidacoes.testePrazo();
        }

        public virtual void CalcularPrestacao() => valorPrestacao = valor / prazo;

        public virtual void ExibirInfo()
        {
            Console.WriteLine(@$"Valor do contrato: {valor}
Prazo do contrato: {prazo}
Valor da prestação: R$ {valorPrestacao:0.00}");
        }
    }
}
