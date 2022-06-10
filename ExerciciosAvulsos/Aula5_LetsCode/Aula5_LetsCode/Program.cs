using Aula5_LetsCode;

string input;
decimal inputConv;
Caixa caixaDoDia = new Caixa();
caixaDoDia.AbrirCaixa();
Console.WriteLine($"Caixa aberto em {caixaDoDia.DataCaixa}");
Console.WriteLine($"Saldo do dia: {caixaDoDia.Saldo}");

Console.WriteLine("Digite o valor total do serviço:");
input = Console.ReadLine();
while (!decimal.TryParse(input, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out inputConv))
{
    Console.WriteLine("Valor inválido");
    Console.WriteLine("Digite o valor total do serviço:");
    input = Console.ReadLine();
}
caixaDoDia.AdicionaValorServico(inputConv);

Console.WriteLine("");
Console.WriteLine("Digite o valor do pagamento do usuário:");
input = Console.ReadLine();
while (!decimal.TryParse(input, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out inputConv))
{
    Console.WriteLine("Valor inválido");
    Console.WriteLine("Digite o valor do pagamento do usuário:");
    input = Console.ReadLine();
}
caixaDoDia.AdicionaValorPago(inputConv);

caixaDoDia.CalcularTroco();