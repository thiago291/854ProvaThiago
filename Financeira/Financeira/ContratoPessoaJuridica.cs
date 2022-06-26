using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeira
{
    public class ContratoPessoaJuridica : Contrato
    {
        private decimal CNPJ { get; set; }
        private decimal InscricaoEstadual { get; set; }

        public decimal cnpj, inscricaoEstadual;

        public override void cadastro()
        {
            Console.Clear();
            cnpj = TestesEValidacoes.testeCPFouCNPJouIE("PJ");
            inscricaoEstadual = TestesEValidacoes.testeCPFouCNPJouIE("IE");
            base.cadastro();
            calcularPrestacao();
        }

        public ContratoPessoaJuridica()
        {
            this.CNPJ = cnpj;
            this.InscricaoEstadual = inscricaoEstadual;
        }

        public override void calcularPrestacao()
        {
            base.calcularPrestacao();
            valorPrestacao += 3;
        }

        public override void ExibirInfo()
        {
            Console.Clear();
            Console.WriteLine(@$"======================INFORMAÇÕES======================
Nome do contratante: {contratante}
CNPJ do contratante: {cnpj}
Inscrição estadual do contratante: {inscricaoEstadual}");
            base.ExibirInfo();
        }
    }
}
