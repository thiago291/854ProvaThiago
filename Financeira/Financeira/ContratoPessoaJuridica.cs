using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeira
{
    public class ContratoPessoaJuridica : Contrato
    {
        private string CNPJ { get; set; }
        private string InscricaoEstadual { get; set; }

        public string cnpj, inscricaoEstadual;

        public override void cadastro()
        {
            Console.Clear();
            cnpj = TestesEValidacoes.testeCPFouCNPJouIE("PJ");
            inscricaoEstadual = TestesEValidacoes.testeCPFouCNPJouIE("IE");
            base.cadastro();
            CalcularPrestacao();
        }

        public ContratoPessoaJuridica()
        {
            this.CNPJ = cnpj;
            this.InscricaoEstadual = inscricaoEstadual;
        }

        public override void CalcularPrestacao()
        {
            base.CalcularPrestacao();
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
