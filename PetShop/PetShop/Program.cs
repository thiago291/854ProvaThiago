using PetShop.Classes;
using PetShop.Enums;

/*Animal pet = new Animal();

Console.WriteLine("Qual o nome do seu pet?");
pet.Nome = Console.ReadLine();

Console.WriteLine(@"Qual a especie do seu pet? Digite 1 para cachorro ou 2 para gato");
pet.Especie = Enum.Parse<Especie>(Console.ReadLine());
var escolhaEspecie = pet.Especie.ToString();
while (escolhaEspecie != "Cachorro" && escolhaEspecie != "Gato" || string.IsNullOrWhiteSpace(escolhaEspecie))
{
    Console.WriteLine("Opção inválida, tente novamente: ");
    pet.Especie = (Especie)Convert.ToInt32(Console.ReadLine());
    escolhaEspecie = pet.Especie.ToString();
}

Console.WriteLine("Qual a raça do seu pet?");
pet.Raca = Console.ReadLine();
Console.WriteLine("Qual a cor do seu pet?");
pet.Cor = Console.ReadLine();

Console.WriteLine(@"Qual o porte do seu pet? Digite 1 para pequeno ou 2 para grande");
pet.Porte = Enum.Parse<Porte>(Console.ReadLine());
var escolhaPorte = pet.Porte.ToString();
while (escolhaPorte != "Pequeno" && escolhaPorte != "Grande" || string.IsNullOrWhiteSpace(escolhaPorte))
{
    Console.WriteLine("Opção inválida, tente novamente: ");
    pet.Porte = (Porte)Convert.ToInt32(Console.ReadLine());
    escolhaPorte = pet.Porte.ToString();
}

Console.WriteLine("Qual o peso do seu pet?");
pet.Peso = decimal.Parse(Console.ReadLine());

Console.WriteLine("Qual a data de nascimento do seu pet?");
pet.Nascimento = DateTime.Parse(Console.ReadLine());

//pet.AdicionarDoencasAlergias

Console.WriteLine(@"Seu pet é agressivo? Digite 1 para sim ou 2 para não");

var agressividade = Console.ReadLine();
while (agressividade != "1" && agressividade != "2" || string.IsNullOrWhiteSpace(agressividade))
{
    Console.WriteLine("Opção inválida, tente novamente: ");
    agressividade = Console.ReadLine();
}
if (agressividade == "1")
{
    pet.Agressivo = true;
}
else
{
    pet.Agressivo = false;
}
Console.WriteLine(@"Qual o sexo do seu pet? Digite M para macho ou F para femêa");

pet.Sexo = Convert.ToChar(Console.ReadLine().ToUpper());

while (pet.Sexo != 'F' && pet.Sexo != 'M' || char.IsWhiteSpace(pet.Sexo))
{
    Console.WriteLine("Opção inválida, tente novamente: ");
    agressividade = Console.ReadLine();
}

pet.Castrado = true;

pet.ImprimirAnimal();*/
/*
string input;
decimal inputConv;
Caixa caixaDoDia = new Caixa();
caixaDoDia.AbrirCaixa();
Console.WriteLine($"Caixa aberto em {caixaDoDia.DataCaixa}");
Console.WriteLine($"Saldo do dia: {caixaDoDia.Saldo}");

Console.WriteLine("Digite o valor total do serviço:");
input = Console.ReadLine();
while (!decimal.TryParse(input,System.Globalization.NumberStyles.AllowDecimalPoint,System.Globalization.CultureInfo.InvariantCulture, out inputConv))
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
*/

Animal pet = new Animal();
pet.Nome = "Charlie";
Console.WriteLine(pet.Nome);
Console.WriteLine(pet.DataCadastrado);
Console.WriteLine(pet.Codigo);