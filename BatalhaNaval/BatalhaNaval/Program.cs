//Nome: Thiago Conceição da Silva Costa
//versão 1.2

#region Inicialização de variáveis
//using Regex
using System.Text.RegularExpressions;

//tabuleiros [linha, coluna]
string[,] tabuleiroBarcosJogador1 = new string[10, 10];
string[,] tabuleiroBarcosJogador2 = new string[10, 10];
string[,] campoDeBatalhaJogador1 = new string[10, 10];
string[,] campoDeBatalhaJogador2 = new string[10, 10];

//conversor de posições para as linhas
Dictionary<int, string> dicionarioPosicoes = new Dictionary<int, string>();
dicionarioPosicoes.Add(0, "A");
dicionarioPosicoes.Add(1, "B");
dicionarioPosicoes.Add(2, "C");
dicionarioPosicoes.Add(3, "D");
dicionarioPosicoes.Add(4, "E");
dicionarioPosicoes.Add(5, "F");
dicionarioPosicoes.Add(6, "G");
dicionarioPosicoes.Add(7, "H");
dicionarioPosicoes.Add(8, "I");
dicionarioPosicoes.Add(9, "J");

//dicionário de siglas válidas para os barcos, e seus respectivos tamanhos
Dictionary<string, int> dicionarioNavios = new Dictionary<string, int>();
dicionarioNavios.Add("SB", 2);
dicionarioNavios.Add("DS", 3);
dicionarioNavios.Add("NT", 4);
dicionarioNavios.Add("PS", 5);

//variáveis relacionadas aos jogadores
string nomeJogador1 = "", nomeJogador2 = "", input;
bool jogoMultiPlayer = true;
bool vezDoJogador1 = true;
var numJogadores = 0;
List<string> inputSeparado;

//quantidade máxima de barcos permitida
int qtdMaxSB = 4;
int qtdMaxDS = 3;
int qtdMaxNT = 2;
int qtdMaxPS = 1;

//váriáveis relacionadas aos tabuleiros
string linhaInicial, linhaFinal, linhaInputJogo;
int colunaInicial, colunaFinal, indexLinhaInicial, indexLinhaFinal,
    tamanhoBarco, colunaInputJogo, indexInputJogo;

//tamanho somado de todos os barcos no campo de batalha
int qtdBarcosJogador1 = 0, qtdBarcosJogador2 = 0;

#endregion

#region Armazenamento dos nomes dos jogadores (somente multiplayer)
void armazenaNomes()
{
    while (string.IsNullOrEmpty(nomeJogador1))
    {
        Console.WriteLine("Insira o nome do jogador 1:");
        nomeJogador1 = Console.ReadLine();
    }

    while (string.IsNullOrEmpty(nomeJogador2))
    {
        Console.WriteLine("Insira o nome do jogador 2:");
        nomeJogador2 = Console.ReadLine();
    }
}
#endregion

#region Estilo de jogo/número de jogadores
void verificaNumJogadores()
{
    Console.WriteLine("Selecione o estilo de jogo");
    Console.WriteLine("1: vs. CPU");
    Console.WriteLine("2: multiplayer");
    if (!int.TryParse(Console.ReadLine(), out numJogadores))
    {
        Console.WriteLine("Insira um número válido");
        verificaNumJogadores();
    }
    else
    {
        switch (numJogadores)
        {
            case 1:
                jogoMultiPlayer = false;
                Console.WriteLine("Versão contra CPU ainda não implementada. " +
                    "Por favor selecione a opção de 2 jogadores.");
                verificaNumJogadores();
                break;
            case 2:
                jogoMultiPlayer = true;
                armazenaNomes();
                break;
            default:
                Console.WriteLine("Escolha entre 1 e 2 jogadores.");
                verificaNumJogadores();
                break;
        }
    }
}
#endregion

#region Preenchimento dos tabuleiros
//insere o barco no tabuleiro
void posicionaBarco(string[,] tabuleiroBarcos)
{
    if (indexLinhaFinal == indexLinhaInicial)
    {
        for (int i = colunaInicial; i <= colunaFinal; i++)
            tabuleiroBarcos[indexLinhaFinal, i] = "B";
    }
    else if (colunaInicial == colunaFinal)
    {
        for (int i = indexLinhaInicial; i <= indexLinhaFinal; i++)
            tabuleiroBarcos[i, colunaInicial] = "B";
    }
    qtdBarcosJogador1 += tamanhoBarco;
}
#endregion

#region verificações gerais
//verifica se o input do usuário não está vazio
bool inputNaoEstaVazio()
{
    input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Valor de input não pode ser vazio.");
        return false;
    }
    return true;
}

//separa o input (tabuleiro)
void separaInput()
{
    //separa o input do usuário com o uso de um Regex
    inputSeparado = Regex.Split(input, "([a-z]+)|([0-9]+)").ToList();

    //O split gera um espaço vazio no final da lista, então é necessário fazer a remoção desse espaço
    inputSeparado.RemoveAt(inputSeparado.Count - 1);
}

//verificação se o input possui o(s) valor(es) de linha e coluna correto(s)
bool validaInput()
{
    int numTeste = 0;

    //verifica se o tamanho dos inputs da string está de acordo (2 para input do tiro, 4 para o input do barco)
    if (inputSeparado.Count != 2 && inputSeparado.Count != 4)
        return false;

    //quando [i] é par, o valor é uma string, quando é ímpar, é uma int
    for (int i = 0; i < inputSeparado.Count; i++)
    {
        if (i == 0 || i % 2 == 0)
        {
            //verifica se o valor da linha é valido (entre A e J)
            if (!dicionarioPosicoes.ContainsValue(inputSeparado[i]))
                return false;
        }
        else if (i % 2 != 0)
        {
            //testa se o valor é um inteiro, e se está entre 1 e 10
            if (!int.TryParse(inputSeparado[i], out numTeste))
                return false;
            if ((numTeste < 1 || numTeste > 10))
                return false;
        }
    }
    return true;
}
#endregion

#region Checagem da posição do barco no tabuleiro
//checa se o valor do barco já está ocupado
bool posicaoLivre(string[,] tabuleiroBarcos)
{
    if (indexLinhaFinal == indexLinhaInicial)
    {
        for (int i = colunaInicial; i <= colunaFinal; i++)
        {
            if (tabuleiroBarcos[indexLinhaFinal, i] != null)
                return false;
        }
    }
    else if (colunaInicial == colunaFinal)
    {
        for (int i = indexLinhaInicial; i <= indexLinhaFinal; i++)
        {
            if (tabuleiroBarcos[i, colunaInicial] != null)
                return false;
        }
    }
    return true;
}
#endregion

#region Verificação do input do barco do usuário
//valida se o input da posição do barco é válido
void validaInputBarco(string siglaBarco)
{
    //declaração de variáveis locais do objeto
    bool inputValido = false;
    dicionarioNavios.TryGetValue(siglaBarco, out tamanhoBarco);

    //loop de validação do input do usuário (o loop só é quebrado quando o input é válido)
    while (inputValido == false)
    {
        Console.WriteLine("Qual a sua posição?");
        Console.WriteLine("Exemplo de formato válido: G1H1");

        if (!inputNaoEstaVazio())
            continue;

        separaInput();

        //checa se o formato do input está correto, e armazena seus valores se estiverem corretos
        if (validaInput())
        {
            colunaInicial = int.Parse(inputSeparado[1]) - 1;
            colunaFinal = int.Parse(inputSeparado[3]) - 1;
            linhaInicial = inputSeparado[0];
            linhaFinal = inputSeparado[2];
            //salva o index das linhas, para as próximas verificações
            indexLinhaInicial = dicionarioPosicoes.First(x => x.Value == linhaInicial).Key;
            indexLinhaFinal = dicionarioPosicoes.First(x => x.Value == linhaFinal).Key;
        }
        else
        {
            Console.WriteLine("Digite um formato válido.");
            continue;
        }

        //checa se o barco está na mesma linha ou coluna
        if ((colunaFinal != colunaInicial) && (indexLinhaFinal != indexLinhaInicial))
        {
            Console.WriteLine("Barco precisa estar na mesma linha ou coluna.");
            continue;
        }

        //checa se o tamanho do barco é compatível com o tamanho posto pelo input do usuário
        if ((colunaFinal - colunaInicial != tamanhoBarco - 1) && (indexLinhaFinal - indexLinhaInicial != tamanhoBarco - 1))
        {
            Console.WriteLine("Tamanho inválido para o barco selecionado.");
            continue;
        }

        //checa se a posição do barco está livre, e, se estiver, chama a função de posicionamento do barco
        switch (vezDoJogador1)
        {
            case true:
                if (!posicaoLivre(tabuleiroBarcosJogador1))
                {
                    Console.WriteLine("Uma ou mais posições do barco já estão ocupadas.");
                    continue;
                }
                else
                    posicionaBarco(tabuleiroBarcosJogador1);
                break;
            case false:
                if (!posicaoLivre(tabuleiroBarcosJogador2))
                {
                    Console.WriteLine("Uma ou mais posições do barco já estão ocupadas.");
                    continue;
                }
                else
                    posicionaBarco(tabuleiroBarcosJogador2);
                break;
        }

        //valida o input do usuário como válido, e continua o programa
        inputValido = true;
        Console.Clear();
        Console.WriteLine("Barco inserido com sucesso.");
        Console.WriteLine("");
    }
}
#endregion

#region Controlador de barcos e de tabuleiro
//recebe os tipos de barcos e controla quantos barcos o usuário já inseriu
void preencheTabuleiro()
{
    int qtdSB = qtdMaxSB;
    int qtdDS = qtdMaxDS;
    int qtdNT = qtdMaxNT;
    int qtdPS = qtdMaxPS;
    int barcosRestantes = qtdSB + qtdDS + qtdNT + qtdPS;
    Console.Clear();

    switch (vezDoJogador1)
    {
        case true:
            Console.WriteLine($"É a vez do jogador {nomeJogador1} posicionar os barcos!");
            Console.WriteLine("");
            break;
        case false:
            Console.WriteLine($"É a vez do jogador {nomeJogador2} posicionar os barcos!");
            Console.WriteLine("");
            break;
    }

    while (barcosRestantes != 0)
    {
        Console.WriteLine("Selecione o tipo de embarcação.");
        Console.WriteLine("");
        Console.WriteLine("Barcos disponíveis:");
        Console.WriteLine($"SB = Submarino (2 de tamanho; {qtdSB} disponíveis.");
        Console.WriteLine($"DS = Destroyers (3 de tamanho; {qtdDS} disponíveis.");
        Console.WriteLine($"NT = Navio-Tanque (4 de tamanho; {qtdNT} disponíveis.");
        Console.WriteLine($"PS = Porta-Aviões (5 de tamanho; {qtdPS} disponíveis.");
        if (!inputNaoEstaVazio())
            continue;
        if (!dicionarioNavios.ContainsKey(input))
            Console.WriteLine("Digite uma embarcação válida");
        else
        {
            switch (input)
            {
                case "SB":
                    if (qtdSB == 0)
                        Console.WriteLine("Não há mais embarcações deste tipo disponíveis");
                    else
                    {
                        validaInputBarco(input);
                        qtdSB--;
                        barcosRestantes--;
                    }
                    break;
                case "DS":
                    if (qtdDS == 0)
                        Console.WriteLine("Não há mais embarcações deste tipo disponíveis");
                    else
                    {
                        validaInputBarco(input);
                        qtdDS--;
                        barcosRestantes--;
                    }
                    break;
                case "NT":
                    if (qtdNT == 0)
                        Console.WriteLine("Não há mais embarcações deste tipo disponíveis");
                    else
                    {
                        validaInputBarco(input);
                        qtdNT--;
                        barcosRestantes--;
                    }
                    break;
                case "PS":
                    if (qtdPS == 0)
                        Console.WriteLine("Não há mais embarcações deste tipo disponíveis");
                    else
                    {
                        validaInputBarco(input);
                        qtdPS--;
                        barcosRestantes--;
                    }
                    break;
            }
        }
    }
}
#endregion

#region Inialização do campo do jogo
void inicializaJogo(string[,] campo)
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
            campo[i, j] = "M";
    }
}
#endregion

#region Impressão do campo do jogo
void imprimeMapa(string[,] campo)
{
    Console.WriteLine("------------------------------");
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
            Console.Write($"|{campo[i, j]}|");
        Console.WriteLine("");
        Console.WriteLine("------------------------------");
    }
}
#endregion

#region Validação do input do tiro do usuário
void validaInputTiro()
{
    bool inputValido = false;
    while (inputValido == false)
    {
        Console.WriteLine("Tente acertar uma posição.");
        Console.WriteLine("Exemplo de formato válido: D2, onde 'D' é a linha e '2' é a coluna desejada");

        //verifica se o input do usuário não está vazio
        if (!inputNaoEstaVazio())
            continue;

        //separa o input
        separaInput();

        //checa se o formato do input está correto, e armazena seus valores se estiverem corretos
        if (validaInput())
        {
            linhaInputJogo = inputSeparado[0];
            indexInputJogo = dicionarioPosicoes.First(x => x.Value == linhaInputJogo).Key;
            colunaInputJogo = int.Parse(inputSeparado[1]) - 1;
        }
        else
        {
            Console.WriteLine("Digite uma posição válida.");
            continue;
        }

        //checa se a posição do barco está livre, e, se estiver, chama a função de posicionamento do barco
        switch (vezDoJogador1)
        {
            case true:
                if (!registraTiro(campoDeBatalhaJogador2, tabuleiroBarcosJogador2))
                {
                    Console.WriteLine("Posição já utilizada. Tente Outra!");
                    continue;
                }
                break;
            case false:
                if (!registraTiro(campoDeBatalhaJogador1, tabuleiroBarcosJogador1))
                {
                    Console.WriteLine("Posição já utilizada. Tente Outra!");
                    continue;
                }
                break;
        }
        inputValido = true;
    }
}
#endregion

#region Registro do tiro do usuário
bool registraTiro(string[,] campoDeBatalha, string[,] tabuleiroBarcos)
{
    if (campoDeBatalha[indexInputJogo, colunaInputJogo] == "M")
    {
        if (tabuleiroBarcos[indexInputJogo, colunaInputJogo] == "B")
        {
            campoDeBatalha[indexInputJogo, colunaInputJogo] = "X";
            qtdBarcosJogador1--;
        }
        else
            campoDeBatalha[indexInputJogo, colunaInputJogo] = "A";
        return true;
    }
    else
        return false;
}
#endregion

#region Menu de batalha do jogo
void menuBatalha(string jogadorAtivo, string jogadorOponente, int barcosOponente, string[,] campoOponente)
{
    Console.Clear();
    Console.WriteLine($"É a vez do jogador {jogadorAtivo}. " +
        $"O jogador {jogadorOponente} possui {barcosOponente} posição(ões) não atingida(s).");
    imprimeMapa(campoOponente);
    Console.WriteLine("Legenda:");
    Console.WriteLine("M = mar (posição ainda não atingida)");
    Console.WriteLine("A = posição vazia");
    Console.WriteLine("X = posição de barco acertada");
    Console.WriteLine("");
    validaInputTiro();
}
#endregion

#region Mensagem de vitória
void vitoria(string[,] campoOponente, string nomeJogador)
{
    Console.Clear();
    imprimeMapa(campoOponente);
    Console.WriteLine("");
    Console.WriteLine($"Parabéns {nomeJogador}. Você venceu!");
}
#endregion

#region Jogo principal
void jogo()
{
    inicializaJogo(campoDeBatalhaJogador1);
    inicializaJogo(campoDeBatalhaJogador2);

    while (qtdBarcosJogador1 != 0 && qtdBarcosJogador2 != 0)
    {
        switch (vezDoJogador1)
        {
            case true:
                menuBatalha(nomeJogador1, nomeJogador2, qtdBarcosJogador2, campoDeBatalhaJogador2);
                vezDoJogador1 = false;
                break;
            case false:
                menuBatalha(nomeJogador2, nomeJogador1, qtdBarcosJogador1, campoDeBatalhaJogador1);
                vezDoJogador1 = true;
                break;
        }
    }
    if (qtdBarcosJogador1 == 0)
        vitoria(campoDeBatalhaJogador1, nomeJogador2);
    if (qtdBarcosJogador2 == 0)
        vitoria(campoDeBatalhaJogador2, nomeJogador1);
}

#endregion

#region Main
verificaNumJogadores();

preencheTabuleiro();
if (jogoMultiPlayer)
{
    vezDoJogador1 = false;
    preencheTabuleiro();
}

vezDoJogador1 = true;
jogo();
#endregion