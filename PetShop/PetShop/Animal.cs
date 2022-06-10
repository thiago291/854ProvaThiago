using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Enums;

public class Animal
{
    public Guid Codigo { get; private set; }
    public string Nome { get; set; }
    public Especie Especie { get; set; }
    public string Raca { get; set; }
    public string Cor { get; set; }
    public Porte Porte { get; set; }
    public decimal Peso { get; set; }
    //public int Idade { get { return DateTime.Now.Year - Nascimento.Year; } } // calculo só com ano
    public int Idade { get { return IdadeCompleta(); } } //calculo só com meses e ano
    public DateTime Nascimento { get; set; }
    private List<string> DoencasAlergias { get; set; } = new(); //analisar posteriormente
    public bool Agressivo { get; set; }
    public char Sexo { get; set; }
    public bool Castrado { get; set; }
    private DateTime DataCadastrado { get { return DateTime.Now; } }

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

    public void SetarCodigo(Guid codigo)
    {
        this.Codigo = codigo;
    }

    public DateTime ObterDataCadastro()
    {
        return DataCadastrado;
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
