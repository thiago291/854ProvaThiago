using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula5_LetsCode
{
    public class Caixa
    {
        public DateTime DataCaixa { get; private set; }
        public decimal Saldo { get; private set; }
        public decimal TotalValorServico { get; private set; }
        public decimal ValorPago { get; private set; }
        public decimal TrocoCliente { get; private set; }
        public void AbrirCaixa(decimal saldoInicial = 0)
        {
            DataCaixa = DateTime.Now;
            Saldo = saldoInicial;
        }
        public void Deposita(decimal valor)
        {
            Saldo += valor;
        }
        public void Saque(decimal valor)
        {
            if (Saldo >= valor)
                Saldo -= valor;
            else
            {
                Console.WriteLine("Saldo insuficiente");
                Console.WriteLine($"O saldo atual é de R$ {Saldo}");
            }
        }

        public void AdicionaValorServico(decimal valor)
        {
            TotalValorServico += valor;
        }
        public void AdicionaValorPago(decimal valor)
        {
            ValorPago += valor;
        }

        public void CalcularTroco()
        {
            if (ValorPago <= 0 || TotalValorServico <= 0)
                Console.WriteLine("Valor de serviço ou de pagamento inválidos.");
            else if (TotalValorServico > ValorPago)
                Console.WriteLine("Valor pago menor que o serviço prestado.");
            else
            {
                TrocoCliente = ValorPago - TotalValorServico;
                DevolverTroco();
            }
        }

        public void DevolverTroco()
        {
            Console.WriteLine($"O troco do cliente é de {TrocoCliente.ToString("0.00")}"); ;
            Saldo += TotalValorServico;
            Console.WriteLine($"O novo saldo é de {Saldo.ToString("0.00")}");
        }
    }
}

