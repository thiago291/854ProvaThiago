using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Enums;
using PetShop.Classes;

public class Animal : DadosCadastro
{
    
    public string Nome { get; set; }
    public Especie Especie { get; set; }
    public string _raca;

    public string Raca { 
        get => _raca;
        private set
        {
            if (_raca.Contains(value)) //alterar para classe _racasAnimal
                _raca = value;
        };
    }
    public string Cor { get; set; }
    public Porte Porte { get; set; }
    private decimal _peso;
    public decimal Peso { 
        get => _peso;
        set
        {
            _peso = value;
        } 
    }
    public int Idade { get { return IdadeCompleta(); } }
    public DateTime Nascimento { get; set; }
    public List<string> DoencasAlergias { get; private set; } = new();
    public bool Agressivo { get; set; }
    public char Sexo { get; set; }
    public bool Castrado { get; set; }

    private int IdadeCompleta()
    {
        if (Nascimento.Month > DateTime.Now.Month)
        {
            return (DateTime.Now.Year - Nascimento.Year) - 1;
        }
        else if (Nascimento.Month < DateTime.Now.Month)
        {
            return (DateTime.Now.Year - Nascimento.Year);
        }
        else
        {
            if (Nascimento.Day < DateTime.Now.Day)
            {
                return (DateTime.Now.Year - Nascimento.Year);
            }
            else
            {
                return (DateTime.Now.Year - Nascimento.Year) - 1;
            }
        }
    }

    public List<string> ObterNecessidadesEespeciais()
    {
        return DoencasAlergias;
    }

    public bool NecessidadesEspeciais()
    {
        return DoencasAlergias.Any();
    }

    public void RegistrarNascimento(int ano, int mes, int dia = 1)
    {
        Nascimento = new DateTime(ano, mes, dia);
    }
    public void AdicionarDoencasAlergias(string doencaAlergia) //Precisa adicionar ao código
    {
        DoencasAlergias.Add(doencaAlergia);
    }

    public void ImprimirAnimal()
    {
        Console.Clear();
        Console.WriteLine("Imprimindo Pet\n");
        Console.WriteLine($"Codigo do Pet: {Codigo}");
        Console.WriteLine($"{nameof(Nome)}:{Nome}"); //Colocando o nome da propriedade com o nameof.
        Console.WriteLine(Especie);
        Console.WriteLine(Raca);
        Console.WriteLine(Cor);
        Console.WriteLine(Porte);
        Console.WriteLine(Peso);
        Console.WriteLine(Nascimento);
        Console.WriteLine(Idade);
        Console.WriteLine(NecessidadesEspeciais());
        if (NecessidadesEspeciais())
        {
            Console.WriteLine("Doenças e Alergias:");
            foreach (string doencaalergia in DoencasAlergias)
            {
                Console.WriteLine(doencaalergia);
            }
        }
        Console.WriteLine(Agressivo);
        Console.WriteLine(Sexo);
        Console.WriteLine(Castrado);
        Console.WriteLine(DataCadastrado);
        Console.WriteLine("");
    }
}
