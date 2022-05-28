﻿//Nome: Thiago Conceição da Silva Costa

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

//variáveis relacionadas ao jogadores
string nomeJogador1 = "", nomeJogador2 = "";
bool jogoMultiPlayer = true;
bool inputJogador1 = true;
var numJogadores = 0;

//quantidade máxima de barcos permitida
int qtdMaxSB = 4;
int qtdMaxDS = 3;
int qtdMaxNT = 2;
int qtdMaxPS = 1;

//váriáveis relacionadas aos tabuleiros
string linhaInicial, linhaFinal, linhaInputJogo;
int colunaInicial, colunaFinal, indexLinhaInicial, indexLinhaFinal, tamanhoBarco, colunaInputJogo, indexInputJogo;

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
void posicionaBarco()
{
    switch (inputJogador1)
    {
        case true:
            if (indexLinhaFinal == indexLinhaInicial)
            {
                for (int i = colunaInicial; i <= colunaFinal; i++)
                    tabuleiroBarcosJogador1[indexLinhaFinal, i] = "B";
            }
            else if (colunaInicial == colunaFinal)
            {
                for (int i = indexLinhaInicial; i <= indexLinhaFinal; i++)
                    tabuleiroBarcosJogador1[i, colunaInicial] = "B";
            }
            qtdBarcosJogador1 += tamanhoBarco;
            break;
        case false:
            if (indexLinhaFinal == indexLinhaInicial)
            {
                for (int i = colunaInicial; i <= colunaFinal; i++)
                    tabuleiroBarcosJogador2[indexLinhaFinal, i] = "B";
            }
            else if (colunaInicial == colunaFinal)
            {
                for (int i = indexLinhaInicial; i <= indexLinhaFinal; i++)
                    tabuleiroBarcosJogador2[i, colunaInicial] = "B";
            }
            qtdBarcosJogador2 += tamanhoBarco;
            break;
    }
}
#endregion

#region Checagem da posição do barco no tabuleiro
//checa se o valor do barco já está ocupado
bool checaPosicaoBarco()
{
    switch (inputJogador1)
    {
        case true:
            if (indexLinhaFinal == indexLinhaInicial)
            {
                for (int i = colunaInicial; i <= colunaFinal; i++)
                {
                    if (tabuleiroBarcosJogador1[indexLinhaFinal, i] != null)
                        return false;
                }
            }
            else if (colunaInicial == colunaFinal)
            {
                for (int i = indexLinhaInicial; i <= indexLinhaFinal; i++)
                {
                    if (tabuleiroBarcosJogador1[i, colunaInicial] != null)
                        return false;
                }
            }
            return true;

        case false:
            if (indexLinhaFinal == indexLinhaInicial)
            {
                for (int i = colunaInicial; i <= colunaFinal; i++)
                {
                    if (tabuleiroBarcosJogador2[indexLinhaFinal,i] != null)
                        return false;
                }
            }
            else if (colunaInicial == colunaFinal)
            {
                for (int i = indexLinhaInicial; i <= indexLinhaFinal; i++)
                {
                    if (tabuleiroBarcosJogador2[i, colunaInicial] != null)
                        return false;
                }
            }
            return true;
    }
}
#endregion

#region Verificação do input do barco do usuário
//valida se o input da posição do barco é válido
void validaInputBarco(string siglaBarco)
{
    //declaração de variáveis do objeto
    string input;
    bool inputValido = false;
    List<string> inputSeparado;
    dicionarioNavios.TryGetValue(siglaBarco, out tamanhoBarco);

    while (inputValido == false)
    {
        Console.WriteLine("Qual a sua posição?");
        Console.WriteLine("Exemplo de formato válido: G1H1");
        input = Console.ReadLine();

        //verifica se o input do usuário não está vazio
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Valor de input não pode ser vazio.");
            continue;
        }

        //separa o input do usuário com o uso de um Regex
        inputSeparado = Regex.Split(input, "([a-z]+)|([0-9]+)").ToList();

        //O split gera um espaço vazio no final da lista, então é necessário fazer a remoção desse espaço
        inputSeparado.RemoveAt(inputSeparado.Count - 1);

        //verifica se o tamanho dos inputs da string está de acordo (2 colunas e 2 linhas)
        if (inputSeparado.Count != 4)
        {
            Console.WriteLine("Digite um valor com formato válido");
            continue;
        }

        //verifica se os valores das colunas são números inteiros
        if (!int.TryParse(inputSeparado[1], out colunaInicial) || !int.TryParse(inputSeparado[3], out colunaFinal))
        {
            Console.WriteLine("Digite um valor com formato válido");
            continue;
        }

        //verifica se os valores das colunas dentro do campo de batalha (1 - 10)
        if (colunaInicial < 1 || colunaInicial > 10 || colunaFinal < 1 || colunaFinal > 10)
        {
            Console.WriteLine("Digite um valor com formato válido");
            continue;
        }

        //converte o valor das colunas para o valor da matriz
        colunaFinal--;
        colunaInicial--;

        //verifica se os valores das linhas dentro do campo de batalha (A - J)
        if (dicionarioPosicoes.ContainsValue(inputSeparado[0]) && dicionarioPosicoes.ContainsValue(inputSeparado[2]))
        {
            linhaInicial = inputSeparado[0];
            linhaFinal = inputSeparado[2];
        }
        else
        {
            Console.WriteLine("Digite um valor com formato válido");
            continue;
        }

        //salva o index das linhas, para as próximas verificações
        indexLinhaInicial = dicionarioPosicoes.First(x => x.Value == linhaInicial).Key;
        indexLinhaFinal = dicionarioPosicoes.First(x => x.Value == linhaFinal).Key;

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
        if (!checaPosicaoBarco())
        {
            Console.WriteLine("Uma ou mais posições do barco já estão ocupadas.");
            continue;
        }
        else
            posicionaBarco();

        //valida o input do usuário como válido, e continua o programa
        inputValido = true;
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
    string input;
    Console.Clear();

    switch (inputJogador1)
    {
        case true:
            Console.WriteLine($"É a vez do {nomeJogador1} posicionar os barcos!");
            break;
        case false:
            Console.WriteLine($"É a vez do {nomeJogador2} posicionar os barcos!");
            break;

    }

    while (barcosRestantes != 0)
    {
        Console.WriteLine("Qual o tipo de embarcação?");
        input = Console.ReadLine();
        if (!dicionarioNavios.ContainsKey(input))
        {
            Console.WriteLine("Digite uma embarcação válida");
        }
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
        {
            campo[i, j] = "M";
        }
    }

}
#endregion

#region Impressão do campo do jogo
void imprimeMapa(string[,] campo)
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            Console.Write(campo[i, j]);
        }
        Console.WriteLine();
    }

}
#endregion

#region Validação do input do tiro do usuário
void validaInputTiro()
{
    bool inputValido = false;
    List<string> inputSeparado;
    //dicionarioNavios.TryGetValue(siglaBarco, out tamanhoBarco);
    string input;

    while (inputValido == false)
    {
        Console.WriteLine("Tente acertar uma posição.");
        Console.WriteLine("Exemplo de formato válido: D4, onde 'D' é a linha e '4' é a coluna desejada");
        input = Console.ReadLine();

        //verifica se o input do usuário não está vazio
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Valor de input não pode ser vazio.");
            continue;
        }

        //separa o input do usuário com o uso de um Regex
        inputSeparado = Regex.Split(input, "([a-z]+)|([0-9]+)").ToList();

        //O split gera um espaço vazio no final da lista, então é necessário fazer a remoção desse espaço
        inputSeparado.RemoveAt(inputSeparado.Count - 1);

        //verifica se o tamanho dos inputs da string está de acordo (linha e coluna)
        if (inputSeparado.Count != 2)
        {
            Console.WriteLine("Digite um valor com formato válido");
            continue;
        }

        //verifica se os valor da coluna é um número inteiro
        if (!int.TryParse(inputSeparado[1], out colunaInputJogo))
        {
            Console.WriteLine("Digite um valor com formato válido");
            continue;
        }

        //verifica se o valor da coluna está dentro do campo de batalha (1 - 10)
        if (colunaInputJogo < 1 || colunaInputJogo > 10)
        {
            Console.WriteLine("Digite um valor com formato válido");
            continue;
        }

        //verifica se o valor da linha está dentro do campo de batalha (A - J)
        if (dicionarioPosicoes.ContainsValue(inputSeparado[0]))
            linhaInputJogo = inputSeparado[0];
        else
        {
            Console.WriteLine("Digite um valor com formato válido");
            continue;
        }

        //converte o valor da coluna para o valor da matriz
        colunaInputJogo--;

        //salva o index das linhas, para as próximas verificações
        indexInputJogo = dicionarioPosicoes.First(x => x.Value == linhaInputJogo).Key;

        //checa se a posição do barco está livre, e, se estiver, chama a função de posicionamento do barco
        if (!registraTiro())
        {
            Console.WriteLine("Posição já utilizada. Tente Outra!");
            continue;
        }
        //valida o input do usuário como válido, e continua o programa
        inputValido = true;
    }
}
#endregion

#region Registro do tiro do usuário
bool registraTiro()
{
    switch (inputJogador1)
    {
        case false:
            if (campoDeBatalhaJogador1[indexInputJogo, colunaInputJogo] == "M")
            {
                if (tabuleiroBarcosJogador1[indexInputJogo, colunaInputJogo] == "B")
                {
                    campoDeBatalhaJogador1[indexInputJogo, colunaInputJogo] = "X";
                    qtdBarcosJogador1--;
                }
                else
                    campoDeBatalhaJogador1[indexInputJogo, colunaInputJogo] = "A";
                return true;
            }
            else
                return false;
        case true:
            if (campoDeBatalhaJogador2[indexInputJogo, colunaInputJogo] == "M")
            {
                if (tabuleiroBarcosJogador2[indexInputJogo, colunaInputJogo] == "B")
                {
                    campoDeBatalhaJogador2[indexInputJogo, colunaInputJogo] = "X";
                    qtdBarcosJogador2--;
                }
                else
                    campoDeBatalhaJogador2[indexInputJogo, colunaInputJogo] = "A";
                return true;
            }
            else
                return false;
    }
}
#endregion

#region Jogo principal
void jogo()
{
    inicializaJogo(campoDeBatalhaJogador1);
    inicializaJogo(campoDeBatalhaJogador2);
    while (qtdBarcosJogador1 != 0 && qtdBarcosJogador2 != 0)
    {
        switch (inputJogador1)
        {
            case true:
                Console.Clear();
                Console.WriteLine($"É a vez do jogador {nomeJogador1}");
                Console.WriteLine("");
                Console.WriteLine($"O jogador {nomeJogador2} possui {qtdBarcosJogador2} posição(ões) não atingida(s).");
                Console.WriteLine("");
                imprimeMapa(campoDeBatalhaJogador2);
                Console.WriteLine("");
                Console.WriteLine("Legenda:");
                Console.WriteLine("M = mar (posição ainda não atingida)");
                Console.WriteLine("A = posição vazia");
                Console.WriteLine("X = posição de barco acertada");
                Console.WriteLine("");
                validaInputTiro();
                inputJogador1 = false;
                break;
            case false:
                Console.Clear();
                Console.WriteLine($"É a vez do jogador {nomeJogador2}");
                Console.WriteLine("");
                Console.WriteLine($"O jogador {nomeJogador1} possui {qtdBarcosJogador1} posição(ões) não atingida(s).");
                Console.WriteLine("");
                imprimeMapa(campoDeBatalhaJogador1);
                Console.WriteLine(""); 
                Console.WriteLine("Legenda:");
                Console.WriteLine("M = mar (posição ainda não atingida)");
                Console.WriteLine("A = posição vazia");
                Console.WriteLine("X = posição de barco acertada");
                Console.WriteLine("");
                validaInputTiro();
                inputJogador1 = true;
                break;
        }
    }
    if (qtdBarcosJogador1 == 0)
    {
        Console.Clear();
        imprimeMapa(campoDeBatalhaJogador1);
        Console.WriteLine("");
        Console.WriteLine($"Parabéns {nomeJogador2}. Você venceu!");
    }
    if (qtdBarcosJogador2 == 0)
    {
        Console.Clear();
        imprimeMapa(campoDeBatalhaJogador2);
        Console.WriteLine("");
        Console.WriteLine($"Parabéns {nomeJogador1}. Você venceu!");
    }
}

#endregion

#region Main
verificaNumJogadores();

preencheTabuleiro();
if (jogoMultiPlayer)
{
    inputJogador1 = false;
    preencheTabuleiro();
}

inputJogador1 = true;
jogo();
#endregion