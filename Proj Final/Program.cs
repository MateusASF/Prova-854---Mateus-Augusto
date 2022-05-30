
#region Declarações

#region Montagem do tabuleiro

#region Dicionário de Frota
Dictionary<string, int> frotaEmbarcacoes = new Dictionary<string, int>();
frotaEmbarcacoes.Add("PS", 5);
frotaEmbarcacoes.Add("NT", 4);
frotaEmbarcacoes.Add("DS", 3);
frotaEmbarcacoes.Add("SB", 2);
#endregion

#region dicionário de linhas 
Dictionary<char, int> posicao = new Dictionary<char, int>();
posicao.Add('A', 0);
posicao.Add('B', 1);
posicao.Add('C', 2);
posicao.Add('D', 3);
posicao.Add('E', 4);
posicao.Add('F', 5);
posicao.Add('G', 6);
posicao.Add('H', 7);
posicao.Add('I', 8);
posicao.Add('J', 9);
#endregion

#region Indices do tabuleiro
int[] indiceColunas = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
string[] letrasDoIndiceDeLinhas = new string[] { " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
#endregion region

#region Campos dos Jogadores
string[,] campoDeJogoJogador01 = new string[11, 21];
string[,] campoDeJogoJogador02 = new string[11, 21];
string[,] campoDePosicionamentoJogador01 = new string[11, 21];
string[,] campoDePosicionamentoJogador02 = new string[11, 21];
int ContagemColunas = 1;
#endregion

#endregion region

#region Declarações Iniciais dos Jogadores

#region Campo dos Jogadores
string[,] campoJogador01 = new string[10, 10];
string[,] campoJogador02 = new string[10, 10];
#endregion region

#region Marcação dos tiros dos Jogadores
List<string> tentativsTiroJogador01 = new List<string>();
List<string> tentativsTiroJogador02 = new List<string>();
#endregion

#endregion

#region Declarções para o jogo
string NomeJogador01 = "";
string NomeJogador02 = "";
string posicaoNavio = "";
string escolhaNavio = "";
string posicaoInvalida = "A posição desejada não atende as regras, por favor, tente novamente: ";
string estoqueDeEmbarcacoes = "Essa embarcação não aceita novos posicionamentos, experimente outro tipo de embarcação!";
string localDoTiro;
string sLinhaDoTiro = "*";
string sColunaDoTiro = "*";


bool espacoComEmbarcacao = false;
bool validacaoColunaInicial = true;
bool validacaoColunaFinal = true;
bool validacaoLinhaInicial = true;
bool validacaoLinhaFinal = true;
bool espacoLivre = true;


char linhaInicial = ' ';
char linhaFinal = ' ';

int[,] mapaDeTiros = new int[10, 10];
int colunaInicial = 0;
int colunaFinal = 0;
int espaco = 0;
int quantidadePortaAvioes = 1;
int quantidadeNaviosTanque = 2;
int quantidadeDestroyer = 3;
int quantidadeSubmarino = 4;
int iLinhaDoTiro = 0;
int iColunaDoTiro = 0;
int acertosJogador01 = 0;
int acertosJogador02 = 0;
int jogoInicial = 0;
int totalDeNaviosEscolhidos = 10;


List<string> LocalDeTirosJoggador01 = new List<string>();
List<string> LocalDeTirosJogador02 = new List<string>();
#endregion

#endregion

#region Métodos

#region Métodos Gerais
void JogoMultiplayer()
{
    #region Nomes dos Comandantes
    Console.Write(@"  
  ___         _                 _                  ___                                  _                 _         
 | _ \  _ _  (_)  _ __    ___  (_)  _ _   ___     / __|  ___   _ __    __ _   _ _    __| |  __ _   _ _   | |_   ___ 
 |  _/ | '_| | | | '  \  / -_) | | | '_| / _ \   | (__  / _ \ | '  \  / _` | | ' \  / _` | / _` | | ' \  |  _| / -_)
 |_|   |_|   |_| |_|_|_| \___| |_| |_|   \___/    \___| \___/ |_|_|_| \__,_| |_||_| \__,_| \__,_| |_||_|  \__| \___|

Informe o nome do primeiro comandante: ");
    NomeJogador01 = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(NomeJogador01))
    {
        Console.Write("O nome não pode ser vazio marujo, escreva seu nome para ser o comandate adversário nessa batalha: ");
        NomeJogador01 = Console.ReadLine();
    }
    Console.Clear();

    Console.Write(@"
  ___                                 _            ___                                  _                 _         
 / __|  ___   __ _   _  _   _ _    __| |  ___     / __|  ___   _ __    __ _   _ _    __| |  __ _   _ _   | |_   ___ 
 \__ \ / -_) / _` | | || | | ' \  / _` | / _ \   | (__  / _ \ | '  \  / _` | | ' \  / _` | / _` | | ' \  |  _| / -_)
 |___/ \___| \__, |  \_,_| |_||_| \__,_| \___/    \___| \___/ |_|_|_| \__,_| |_||_| \__,_| \__,_| |_||_|  \__| \___|
             |___/                 

Informe o nome do segundo comandante: ");
    NomeJogador02 = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(NomeJogador02))
    {
        Console.Write("O nome não pode ser vazio marujo, escreva seu nome para ser o comandate adversário nessa batalha: ");
        NomeJogador02 = Console.ReadLine();
    }
    Console.Clear();
    #endregion

    #region Montando os Quadros de Jogo
    for (int i = 0; i < 11; i++)
    {
        for (int j = 0; j <= 20; j++)
        {
            if (i == 0 && j % 2 == 0 && j > 0)
            {
                campoDeJogoJogador01[i, j] = $"{ContagemColunas.ToString()}";
                campoDeJogoJogador02[i, j] = $"{ContagemColunas.ToString()}";
                campoDePosicionamentoJogador01[i, j] = $"{ContagemColunas.ToString()}";
                campoDePosicionamentoJogador02[i, j] = $"{ContagemColunas.ToString()}";
                ContagemColunas++;
            }
            else
            {
                campoDeJogoJogador01[i, j] = " ";
                campoDeJogoJogador02[i, j] = " ";
                campoDePosicionamentoJogador01[i, j] = " ";
                campoDePosicionamentoJogador02[i, j] = " ";
            }

            if (j == 0)
            {
                campoDeJogoJogador01[i, j] = letrasDoIndiceDeLinhas[i];
                campoDeJogoJogador02[i, j] = letrasDoIndiceDeLinhas[i];
                campoDePosicionamentoJogador01[i, j] = letrasDoIndiceDeLinhas[i];
                campoDePosicionamentoJogador02[i, j] = letrasDoIndiceDeLinhas[i];
            }
        }
    }
    #endregion

    Console.Clear();

    ///////////////////////////////////
    #region Escolha da embarcação jogador 01 //


    for (int i = 0; i < totalDeNaviosEscolhidos; i++)
    {
        if (i != 0)
        {
            naviosEscolhidos();
        }

        Console.WriteLine(@$"
  ___                   _   _                  _            ___           _                                     __          
 | __|  ___  __   ___  | | | |_    __ _     __| |  __ _    | __|  _ __   | |__   __ _   _ _   __   __ _   __   __ _   ___ 
 | _|  (_-< / _| / _ \ | | | ' \  / _` |   / _` | / _` |   | _|  | '  \  | '_ \ / _` | | '_| / _| / _` | / _| / _` | / _ \
 |___| /__/ \__| \___/ |_| |_||_| \__,_|   \__,_| \__,_|   |___| |_|_|_| |_.__/ \__,_| |_|   \__| \__,_| \__| \__,_| \___/
                                                                                                          /
   Comandante {NomeJogador01}");

        ExibibePosicionamentoJogador01();

        Console.WriteLine(@$"  
Escolha o tipo de Embarcação desejada e escreve sua sigla (Exemplo de Escolha: NT)
PS - Porta Aviões (5 quadrantes) - Você tem {quantidadePortaAvioes} disponível
NT - Navio Tanque (4 quadrantes) - Você tem {quantidadeNaviosTanque} disponível
DS - Destroyer    (3 quadrantes) - Você tem {quantidadeDestroyer} disponível
SB - Submarino    (2 quadrantes) - Você tem {quantidadeSubmarino} disponível");
        escolhaNavio = Console.ReadLine().ToUpper();
        while (!frotaEmbarcacoes.ContainsKey(escolhaNavio) || string.IsNullOrWhiteSpace(escolhaNavio))
        {
            Console.WriteLine("Este Navio não existe, tente novamente");
            escolhaNavio = Console.ReadLine().ToUpper();
        }

        EmbarcaçõesColocadasEmBatalha();

        Console.WriteLine("Qual a posição inicial e final da sua embarcação? (escreva tudo junto ex: C3F3)");
        PosicionamentoJogador01();

        while (!validacaoLinhaInicial || !validacaoLinhaFinal || !validacaoLinhaInicial || !validacaoLinhaFinal || espaco != frotaEmbarcacoes[escolhaNavio])
        {
            Console.Write(posicaoInvalida);
            PosicionamentoJogador01();
        }
        Console.Clear();
    }

    #endregion////
    ///////////////////////////////////

    quantidadePortaAvioes = 1;
    quantidadeNaviosTanque = 2;
    quantidadeDestroyer = 3;
    quantidadeSubmarino = 4;

    ///////////////////////////////////
    #region Escolha da embarcação jogador 02 //

    for (int i = 0; i < totalDeNaviosEscolhidos; i++)
    {
        if (i != 0)
        {
            naviosEscolhidos();
        }

        Console.WriteLine(@$"
  ___                   _   _                  _            ___           _                                     __          
 | __|  ___  __   ___  | | | |_    __ _     __| |  __ _    | __|  _ __   | |__   __ _   _ _   __   __ _   __   __ _   ___ 
 | _|  (_-< / _| / _ \ | | | ' \  / _` |   / _` | / _` |   | _|  | '  \  | '_ \ / _` | | '_| / _| / _` | / _| / _` | / _ \
 |___| /__/ \__| \___/ |_| |_||_| \__,_|   \__,_| \__,_|   |___| |_|_|_| |_.__/ \__,_| |_|   \__| \__,_| \__| \__,_| \___/
                                                                                                          /
   Comandante {NomeJogador02}");

        ExibibePosicionamentoJogador02();

        Console.WriteLine(@$"  
Escolha o tipo de Embarcação desejada e escreve sua sigla (Exemplo de Escolha: NT)
PS - Porta Aviões (5 quadrantes) - Você tem {quantidadePortaAvioes} disponível
NT - Navio Tanque (4 quadrantes) - Você tem {quantidadeNaviosTanque} disponível
DS - Destroyer    (3 quadrantes) - Você tem {quantidadeDestroyer} disponível
SB - Submarino    (2 quadrantes) - Você tem {quantidadeSubmarino} disponível");
        escolhaNavio = Console.ReadLine().ToUpper();
        while (!frotaEmbarcacoes.ContainsKey(escolhaNavio) || string.IsNullOrWhiteSpace(escolhaNavio))
        {
            Console.WriteLine("Este Navio não existe, tente novamente");
            escolhaNavio = Console.ReadLine().ToUpper();
        }

        EmbarcaçõesColocadasEmBatalha();

        Console.WriteLine("Qual a posição inicial e final da sua embarcação? (escreva tudo junto ex: C3F3)");
        PosicionamentoJogador02();

        while (!validacaoColunaInicial || !validacaoColunaFinal
        || !validacaoLinhaInicial || !validacaoLinhaFinal || espaco != frotaEmbarcacoes[escolhaNavio])
        {
            Console.Write(posicaoInvalida);
            PosicionamentoJogador02();
        }

        Console.Clear();
    }
    #endregion////
    ///////////////////////////////////


    while (acertosJogador01 != 30 || acertosJogador02 != 30)
    {
        HoraDaBatalha();
    }

    MelhorComandante();

}//Fim do Método JogoMultiplayer

void MelhorComandante()
{
    if (acertosJogador01 == 30)
    {
        Console.Clear();
        Console.WriteLine(@$"
:::::::::      :::     :::::::::      :::     :::::::::  :::::::::: ::::    :::  ::::::::          ::::::::   ::::::::  ::::    ::::      :::     ::::    ::: :::::::::      :::     ::::    ::: ::::::::::: ::::::::::   ::: 
:+:    :+:   :+: :+:   :+:    :+:   :+: :+:   :+:    :+: :+:        :+:+:   :+: :+:    :+:        :+:    :+: :+:    :+: +:+:+: :+:+:+   :+: :+:   :+:+:   :+: :+:    :+:   :+: :+:   :+:+:   :+:     :+:     :+:          :+: 
+:+    +:+  +:+   +:+  +:+    +:+  +:+   +:+  +:+    +:+ +:+        :+:+:+  +:+ +:+               +:+        +:+    +:+ +:+ +:+:+ +:+  +:+   +:+  :+:+:+  +:+ +:+    +:+  +:+   +:+  :+:+:+  +:+     +:+     +:+          +:+ 
+#++:++#+  +#++:++#++: +#++:++#:  +#++:++#++: +#++:++#+  +#++:++#   +#+ +:+ +#+ +#++:++#++        +#+        +#+    +:+ +#+  +:+  +#+ +#++:++#++: +#+ +:+ +#+ +#+    +:+ +#++:++#++: +#+ +:+ +#+     +#+     +#++:++#     +#+ 
+#+        +#+     +#+ +#+    +#+ +#+     +#+ +#+    +#+ +#+        +#+  +#+#+#        +#+        +#+        +#+    +#+ +#+       +#+ +#+     +#+ +#+  +#+#+# +#+    +#+ +#+     +#+ +#+  +#+#+#     +#+     +#+          +#+ 
#+#        #+#     #+# #+#    #+# #+#     #+# #+#    #+# #+#        #+#   #+#+# #+#    #+#        #+#    #+# #+#    #+# #+#       #+# #+#     #+# #+#   #+#+# #+#    #+# #+#     #+# #+#   #+#+#     #+#     #+#              
###        ###     ### ###    ### ###     ### #########  ########## ###    ####  ########          ########   ########  ###       ### ###     ### ###    #### #########  ###     ### ###    ####     ###     ##########   ### 

Hoje o(a) {NomeJogador01} foi o(a) melhor na batalha, afundando todos as embarcações do(da) comandatente {NomeJogador02}!!!");
    }
    else if (acertosJogador02 == 30)
    {
        Console.Clear();
        Console.WriteLine(@$"
:::::::::      :::     :::::::::      :::     :::::::::  :::::::::: ::::    :::  ::::::::          ::::::::   ::::::::  ::::    ::::      :::     ::::    ::: :::::::::      :::     ::::    ::: ::::::::::: ::::::::::   ::: 
:+:    :+:   :+: :+:   :+:    :+:   :+: :+:   :+:    :+: :+:        :+:+:   :+: :+:    :+:        :+:    :+: :+:    :+: +:+:+: :+:+:+   :+: :+:   :+:+:   :+: :+:    :+:   :+: :+:   :+:+:   :+:     :+:     :+:          :+: 
+:+    +:+  +:+   +:+  +:+    +:+  +:+   +:+  +:+    +:+ +:+        :+:+:+  +:+ +:+               +:+        +:+    +:+ +:+ +:+:+ +:+  +:+   +:+  :+:+:+  +:+ +:+    +:+  +:+   +:+  :+:+:+  +:+     +:+     +:+          +:+ 
+#++:++#+  +#++:++#++: +#++:++#:  +#++:++#++: +#++:++#+  +#++:++#   +#+ +:+ +#+ +#++:++#++        +#+        +#+    +:+ +#+  +:+  +#+ +#++:++#++: +#+ +:+ +#+ +#+    +:+ +#++:++#++: +#+ +:+ +#+     +#+     +#++:++#     +#+ 
+#+        +#+     +#+ +#+    +#+ +#+     +#+ +#+    +#+ +#+        +#+  +#+#+#        +#+        +#+        +#+    +#+ +#+       +#+ +#+     +#+ +#+  +#+#+# +#+    +#+ +#+     +#+ +#+  +#+#+#     +#+     +#+          +#+ 
#+#        #+#     #+# #+#    #+# #+#     #+# #+#    #+# #+#        #+#   #+#+# #+#    #+#        #+#    #+# #+#    #+# #+#       #+# #+#     #+# #+#   #+#+# #+#    #+# #+#     #+# #+#   #+#+#     #+#     #+#              
###        ###     ### ###    ### ###     ### #########  ########## ###    ####  ########          ########   ########  ###       ### ###     ### ###    #### #########  ###     ### ###    ####     ###     ##########   ### 

Hoje o(a) {NomeJogador02} foi o(a) melhor na batalha, afundando todos as embarcações do(da) comandatente {NomeJogador01}!!!");

        Console.WriteLine();

        Console.WriteLine("------- Digite Qualquer Tecla Para  -------");
        Console.ReadKey();

        Environment.Exit(0);
    }
}

void naviosEscolhidos()
{
    if (escolhaNavio == "PS" && quantidadePortaAvioes > 0)
    {
        quantidadePortaAvioes--;
    }
    else if (escolhaNavio == "NT" && quantidadeNaviosTanque > 0)
    {
        quantidadeNaviosTanque--;
    }
    else if (escolhaNavio == "DS" && quantidadeDestroyer > 0)
    {
        quantidadeDestroyer--;
    }
    else if (escolhaNavio == "SB" && quantidadeSubmarino > 0)
    {
        quantidadeSubmarino--;
    }
    Console.Clear();
}

void EmbarcaçõesColocadasEmBatalha()
{
    while ((escolhaNavio == "PS" && quantidadePortaAvioes == 0) || (escolhaNavio == "NT" && quantidadeNaviosTanque == 0)
            || (escolhaNavio == "DS" && quantidadeDestroyer == 0) || (escolhaNavio == "SB" && quantidadeSubmarino == 0))
    {
        Console.Write(estoqueDeEmbarcacoes);
        escolhaNavio = Console.ReadLine().ToUpper();

    }
}

void HoraDaBatalha()
{
    #region Vez do Jogador 01
    Console.Clear();
    Console.WriteLine(@"
          _______  _______  _______     ______   _______     ______   _______ _________ _______  _                 _______ 
|\     /|(  ___  )(  ____ )(  ___  )   (  __  \ (  ___  )   (  ___ \ (  ___  )\__   __/(  ___  )( \      |\     /|(  ___  )
| )   ( || (   ) || (    )|| (   ) |   | (  \  )| (   ) |   | (   ) )| (   ) |   ) (   | (   ) || (      | )   ( || (   ) |
| (___) || |   | || (____)|| (___) |   | |   ) || (___) |   | (__/ / | (___) |   | |   | (___) || |      | (___) || (___) |
|  ___  || |   | ||     __)|  ___  |   | |   | ||  ___  |   |  __ (  |  ___  |   | |   |  ___  || |      |  ___  ||  ___  |
| (   ) || |   | || (\ (   | (   ) |   | |   ) || (   ) |   | (  \ \ | (   ) |   | |   | (   ) || |      | (   ) || (   ) |
| )   ( || (___) || ) \ \__| )   ( |   | (__/  )| )   ( |   | )___) )| )   ( |   | |   | )   ( || (____/\| )   ( || )   ( |
|/     \|(_______)|/   \__/|/     \|   (______/ |/     \|   |/ \___/ |/     \|   )_(   |/     \|(_______/|/     \||/     \|                                                                                                             
");
    Console.WriteLine($"Comandante {NomeJogador01} você irá atacar agora, digite a posição de seu alvo! (Ex: F4");

    ExibeCampoJogador02();

    Console.WriteLine(@"
  ___   _                                 _            ___          _            _   _           
 | _ \ | |  __ _   __   __ _   _ _     __| |  __ _    | _ )  __ _  | |_   __ _  | | | |_    __ _ 
 |  _/ | | / _` | / _| / _` | | '_|   / _` | / _` |   | _ \ / _` | |  _| / _` | | | | ' \  / _` |
 |_|   |_| \__,_| \__| \__,_| |_|     \__,_| \__,_|   |___/ \__,_|  \__| \__,_| |_| |_||_| \__,_|                                                                                            
");


    Console.Write(@$"
Comandate {NomeJogador01} acertou {acertosJogador01}
Comandate {NomeJogador02} acertou {acertosJogador02}");
    Console.WriteLine();
    Console.WriteLine("Posição desejada: ");
    posicaoNavio = Console.ReadLine().ToUpper();

    while (LocalDeTirosJoggador01.Contains(posicaoNavio))
    {
        Console.WriteLine(posicaoInvalida);
        Console.WriteLine("Posição: ");
        posicaoNavio = Console.ReadLine().ToUpper();
    }

    LocalDeTirosJoggador01.Add(posicaoNavio);

    LocalDoTiro();

    Jogador01Acerta02();

    Console.WriteLine("Pressione qualquer tecla para continuar a batalha");
    Console.ReadKey();
    #endregion

    Console.Clear();

    #region Vez do Jogador 02
    Console.WriteLine(@"
          _______  _______  _______     ______   _______     ______   _______ _________ _______  _                 _______ 
|\     /|(  ___  )(  ____ )(  ___  )   (  __  \ (  ___  )   (  ___ \ (  ___  )\__   __/(  ___  )( \      |\     /|(  ___  )
| )   ( || (   ) || (    )|| (   ) |   | (  \  )| (   ) |   | (   ) )| (   ) |   ) (   | (   ) || (      | )   ( || (   ) |
| (___) || |   | || (____)|| (___) |   | |   ) || (___) |   | (__/ / | (___) |   | |   | (___) || |      | (___) || (___) |
|  ___  || |   | ||     __)|  ___  |   | |   | ||  ___  |   |  __ (  |  ___  |   | |   |  ___  || |      |  ___  ||  ___  |
| (   ) || |   | || (\ (   | (   ) |   | |   ) || (   ) |   | (  \ \ | (   ) |   | |   | (   ) || |      | (   ) || (   ) |
| )   ( || (___) || ) \ \__| )   ( |   | (__/  )| )   ( |   | )___) )| )   ( |   | |   | )   ( || (____/\| )   ( || )   ( |
|/     \|(_______)|/   \__/|/     \|   (______/ |/     \|   |/ \___/ |/     \|   )_(   |/     \|(_______/|/     \||/     \|                                                                                                             
");
    Console.WriteLine($"Comandante {NomeJogador02} você irá atacar agora, digite a posição de seu alvo! (Ex: F4");

    ExibeCampoJogador01();

    Console.WriteLine(@"
  ___   _                                 _            ___          _            _   _           
 | _ \ | |  __ _   __   __ _   _ _     __| |  __ _    | _ )  __ _  | |_   __ _  | | | |_    __ _ 
 |  _/ | | / _` | / _| / _` | | '_|   / _` | / _` |   | _ \ / _` | |  _| / _` | | | | ' \  / _` |
 |_|   |_| \__,_| \__| \__,_| |_|     \__,_| \__,_|   |___/ \__,_|  \__| \__,_| |_| |_||_| \__,_|                                                                                            
");


    Console.Write(@$"
Comandate {NomeJogador01} acertou {acertosJogador01}
Comandate {NomeJogador02} acertou {acertosJogador02}");
    Console.WriteLine();
    Console.WriteLine("Posição desejada: ");
    posicaoNavio = Console.ReadLine().ToUpper();

    while (LocalDeTirosJogador02.Contains(posicaoNavio))
    {
        Console.WriteLine(posicaoInvalida);
        Console.Write("Posição: ");
        posicaoNavio = Console.ReadLine().ToUpper();
    }

    LocalDeTirosJogador02.Add(posicaoNavio);

    LocalDoTiro();

    Jogador02Acerta01();

    Console.WriteLine("Pressione qualquer tecla para continuar a batalha");
    Console.ReadKey();
    #endregion
}

void SubstingsInput()
{
    while (string.IsNullOrWhiteSpace(posicaoNavio) || (posicaoNavio.Length < 4 || posicaoNavio.Length > 6))
    {
        Console.WriteLine(posicaoInvalida);
        posicaoNavio = Console.ReadLine();
    }

    if (posicaoNavio.Length == 6)
    {
        validacaoLinhaInicial = char.TryParse(posicaoNavio.Substring(0, 1), out linhaInicial);
        validacaoColunaInicial = int.TryParse(posicaoNavio.Substring(1, 2), out colunaInicial);
        validacaoLinhaFinal = char.TryParse(posicaoNavio.Substring(3, 1), out linhaFinal);
        validacaoColunaFinal = int.TryParse(posicaoNavio.Substring(4, 2), out colunaFinal);
    }
    else if (posicaoNavio.Length == 4)
    {
        validacaoLinhaInicial = char.TryParse(posicaoNavio.Substring(0, 1), out linhaInicial);
        validacaoColunaInicial = int.TryParse(posicaoNavio.Substring(1, 1), out colunaInicial);
        validacaoLinhaFinal = char.TryParse(posicaoNavio.Substring(2, 1), out linhaFinal);
        validacaoColunaFinal = int.TryParse(posicaoNavio.Substring(3, 1), out colunaFinal);
    }
    else if (posicaoNavio.Length == 5)
    {
        validacaoLinhaInicial = char.TryParse(posicaoNavio.Substring(0, 1), out linhaInicial);
        validacaoColunaInicial = int.TryParse(posicaoNavio.Substring(1, 2), out colunaInicial);
        validacaoLinhaFinal = char.TryParse(posicaoNavio.Substring(3, 1), out linhaFinal);
        validacaoColunaFinal = int.TryParse(posicaoNavio.Substring(4, 1), out colunaFinal);

        if (colunaInicial != 10)
        {
            validacaoLinhaInicial = char.TryParse(posicaoNavio.Substring(0, 1), out linhaInicial);
            validacaoColunaInicial = int.TryParse(posicaoNavio.Substring(1, 1), out colunaInicial);
            validacaoLinhaFinal = char.TryParse(posicaoNavio.Substring(2, 1), out linhaFinal);
            validacaoColunaFinal = int.TryParse(posicaoNavio.Substring(3, 2), out colunaFinal);
        }
    }
}
#endregion

#region Métodos Para o Jogador 01

void AdicionarEmbarcaçãoJogador01()
{
    int linhaIcialOcpada = posicao[linhaInicial];
    int linhaFinalOcpada = posicao[linhaFinal];
    int colunaInicialOcpada = colunaInicial * 2;
    int colunaFinalOcpada = colunaFinal * 2;
    int auxColuna;
    int auxLinha;

    if (linhaInicial == linhaFinal)
    {
        for (auxColuna = colunaInicial; auxColuna <= colunaFinal; auxColuna++)
        {
            campoJogador01[linhaIcialOcpada, auxColuna] = escolhaNavio;
        }

        for (auxColuna = colunaInicialOcpada; auxColuna <= colunaFinalOcpada; auxColuna++)
        {
            if (auxColuna % 2 == 0)
            {
                campoDePosicionamentoJogador01[linhaIcialOcpada + 1, auxColuna + 2] = "*";
            }
        }
    }
    else if (colunaInicial == colunaFinal)
    {
        for (auxLinha = linhaIcialOcpada; auxLinha <= linhaFinalOcpada; auxLinha++)
        {
            campoJogador01[auxLinha, colunaInicial] = escolhaNavio;
        }

        for (auxLinha = (linhaIcialOcpada + 1); auxLinha <= (linhaFinalOcpada + 1); auxLinha++)
        {
            campoDePosicionamentoJogador01[auxLinha, colunaFinalOcpada + 2] = "*";
        }

    }
}

void PosicionamentoJogador01()
{
    posicaoNavio = Console.ReadLine().ToUpper();
    SubstingsInput();

    var LinhaInicialExiste = posicao.ContainsKey(linhaInicial);
    var LinhaFinalExiste = posicao.ContainsKey(linhaFinal);
    var ColunaInicialExiste = Array.Exists(indiceColunas, apoioL => apoioL == colunaInicial - 1);
    var ColunaFinalExiste = Array.Exists(indiceColunas, apoioL => apoioL == colunaFinal - 1);


    if (!LinhaInicialExiste || !LinhaFinalExiste || !ColunaInicialExiste || !ColunaFinalExiste)
    {
        Console.WriteLine(posicaoInvalida);
        posicaoNavio = Console.ReadLine().ToUpper();
        SubstingsInput();
    }


    espacoComEmbarcacao = false;

    colunaInicial--;
    colunaFinal--;

    ValidaçãoEspaçoOcupadoJogador01();

    AdicionarEmbarcaçãoJogador01();
}

void ValidaçãoEspaçoOcupadoJogador01()
{
    if (linhaInicial == linhaFinal)
    {

        espaco = colunaFinal - colunaInicial + 1;
        while (espaco != frotaEmbarcacoes[escolhaNavio])
        {
            Console.WriteLine("Número de quadrantes é inválido, tente novamente: ");
            posicaoNavio = Console.ReadLine().ToUpper();
            SubstingsInput();
        }


        for (int auxColuna = colunaInicial; auxColuna <= colunaFinal; auxColuna++)
        {
            while (campoJogador01[posicao[linhaInicial], auxColuna] != null)
            {
                espacoComEmbarcacao = true;
                Console.WriteLine("Comandante Você está tentando sobrepor suas embarcações assim vamos perder, tente novamente:");
                posicaoNavio = Console.ReadLine().ToUpper();
                SubstingsInput();
            }
        }
    }
    else if (colunaInicial == colunaFinal)
    {

        espaco = colunaFinal - colunaInicial + 1;
        while (espaco != frotaEmbarcacoes[escolhaNavio])
        {
            Console.WriteLine("Número de quadrantes é inválido, tente novamente: ");
            posicaoNavio = Console.ReadLine().ToUpper();
            SubstingsInput();
        }

        for (int auxLinha = posicao[linhaInicial]; auxLinha <= posicao[linhaFinal]; auxLinha++)
        {
            while (campoJogador01[auxLinha, colunaInicial] != null)
            {
                espacoComEmbarcacao = true;
                Console.WriteLine("Comandante Você está tentando sobrepor suas embarcações assim vamos perder, tente novamente:");
                posicaoNavio = Console.ReadLine().ToUpper();
                SubstingsInput();
            }
        }
    }
}

void ExibeCampoJogador01()
{
    for (int i = 0; i < 11; i++)
    {
        for (int j = 0; j < 21; j++)
        {
            Console.Write(campoDeJogoJogador01[i, j]);
        }
        Console.WriteLine();
    }
}

void ExibibePosicionamentoJogador01()
{
    for (int i = 0; i < 11; i++)
    {
        for (int j = 0; j < 21; j++)
        {
            Console.Write(campoDePosicionamentoJogador01[i, j]);
        }
        Console.WriteLine();
    }
}

void Jogador01Acerta02()
{

    if (campoDePosicionamentoJogador02[iLinhaDoTiro, (iColunaDoTiro * 2)] == "*")
    {
        Console.WriteLine($"Comandante {NomeJogador01} você acertou uma embarcação de seu adersário, continue assim e vença essa batalha!");
        campoDeJogoJogador02[iLinhaDoTiro, (iColunaDoTiro * 2)] = "X";
        acertosJogador01++;
    }
    else
    {
        Console.WriteLine($"Que pena Comandante {NomeJogador01} sua pontaria não foi certeira e você acertou a água!");
        campoDeJogoJogador02[iLinhaDoTiro, (iColunaDoTiro * 2)] = "A";
    }
}
#endregion

#region Métodos Para o Jogador 02
void AdicionarEmbarcaçãoJogador02()
{

    int linhaIcialOcpada = posicao[linhaInicial];
    int linhaFinalOcpada = posicao[linhaFinal];
    int colunaInicialOcpada = colunaInicial * 2;
    int colunaFinalOcpada = colunaFinal * 2;
    int auxColuna;
    int auxLinha;

    if (linhaInicial == linhaFinal)
    {
        for (auxColuna = colunaInicial; auxColuna <= colunaFinal; auxColuna++)
        {
            campoJogador02[linhaIcialOcpada, auxColuna] = escolhaNavio;
        }

        for (auxColuna = colunaInicialOcpada; auxColuna <= colunaFinalOcpada; auxColuna++)
        {
            if (auxColuna % 2 == 0)
            {
                campoDePosicionamentoJogador02[linhaIcialOcpada + 1, auxColuna + 2] = "*";
            }
        }
    }
    else if (colunaInicial == colunaFinal)
    {
        for (auxLinha = linhaIcialOcpada; auxLinha <= linhaFinalOcpada; auxLinha++)
        {
            campoJogador02[auxLinha, colunaInicial] = escolhaNavio;
        }

        for (auxLinha = (linhaIcialOcpada + 1); auxLinha <= (linhaFinalOcpada + 1); auxLinha++)
        {
            campoDePosicionamentoJogador02[auxLinha, colunaFinalOcpada + 2] = "*";
        }

    }

}

void PosicionamentoJogador02()
{
    posicaoNavio = Console.ReadLine().ToUpper();
    SubstingsInput();

    var LinhaInicialExiste = posicao.ContainsKey(linhaInicial);
    var LinhaFinalExiste = posicao.ContainsKey(linhaFinal);
    var ColunaInicialExiste = Array.Exists(indiceColunas, apoioL => apoioL == colunaInicial - 1);
    var ColunaFinalExiste = Array.Exists(indiceColunas, apoioL => apoioL == colunaFinal - 1);


    if (!LinhaInicialExiste || !LinhaFinalExiste || !ColunaInicialExiste || !ColunaFinalExiste)
    {
        Console.WriteLine(posicaoInvalida);
        posicaoNavio = Console.ReadLine().ToUpper();
        SubstingsInput();
    }


    espacoComEmbarcacao = false;

    colunaInicial--;
    colunaFinal--;

    ValidaçãoEspaçoOcupadoJogador02();

    AdicionarEmbarcaçãoJogador02();
}

void ValidaçãoEspaçoOcupadoJogador02()
{
    if (linhaInicial == linhaFinal)
    {

        espaco = colunaFinal - colunaInicial + 1;
        while (espaco != frotaEmbarcacoes[escolhaNavio])
        {
            Console.WriteLine("Número de quadrantes é inválido, tente novamente: ");
            posicaoNavio = Console.ReadLine().ToUpper();
            SubstingsInput();
        }


        for (int auxColuna = colunaInicial; auxColuna <= colunaFinal; auxColuna++)
        {
            while (campoJogador02[posicao[linhaInicial], auxColuna] != null)
            {
                espacoComEmbarcacao = true;
                Console.WriteLine("Comandante Você está tentando sobrepor suas embarcações assim vamos perder, tente novamente:");
                posicaoNavio = Console.ReadLine().ToUpper();
                SubstingsInput();
            }
        }
    }
    else if (colunaInicial == colunaFinal)
    {

        espaco = colunaFinal - colunaInicial + 1;
        while (espaco != frotaEmbarcacoes[escolhaNavio])
        {
            Console.WriteLine("Número de quadrantes é inválido, tente novamente: ");
            posicaoNavio = Console.ReadLine().ToUpper();
            SubstingsInput();
        }

        for (int auxLinha = posicao[linhaInicial]; auxLinha <= posicao[linhaFinal]; auxLinha++)
        {
            while (campoJogador02[auxLinha, colunaInicial] != null)
            {
                espacoComEmbarcacao = true;
                Console.WriteLine("Comandante Você está tentando sobrepor suas embarcações assim vamos perder, tente novamente:");
                posicaoNavio = Console.ReadLine().ToUpper();
                SubstingsInput();
            }
        }
    }
}

void ExibeCampoJogador02()
{
    for (int i = 0; i < 11; i++)
    {
        for (int j = 0; j < 21; j++)
        {
            Console.Write(campoDeJogoJogador02[i, j]);
        }
        Console.WriteLine();
    }
}

void ExibibePosicionamentoJogador02()
{
    for (int i = 0; i < 11; i++)
    {
        for (int j = 0; j < 21; j++)
        {
            Console.Write(campoDePosicionamentoJogador02[i, j]);
        }
        Console.WriteLine();
    }
}

void Jogador02Acerta01()
{
    if (campoDePosicionamentoJogador01[iLinhaDoTiro, (iColunaDoTiro * 2)] == "*")
    {
        Console.WriteLine($"Comandante {NomeJogador02} você acertou uma embarcação de seu adersário, continue assim e vença essa batalha!");
        campoDeJogoJogador01[iLinhaDoTiro, (iColunaDoTiro * 2)] = "X";
        acertosJogador02++;
    }
    else
    {
        Console.WriteLine($"Que pena Comandante {NomeJogador02} sua pontaria não foi certeira e você acertou a água!");
        campoDeJogoJogador01[iLinhaDoTiro, (iColunaDoTiro * 2)] = "A";
    }
}
#endregion

#region Métodos Tiros
void LocalDoTiro()
{
    bool LinhaDoTiro = true;
    bool ColunaDoTiro = true;

    ValidaçãoDeTiroVálido();

    LinhaDoTiro = letrasDoIndiceDeLinhas.Contains(sLinhaDoTiro);
    ColunaDoTiro = int.TryParse(sColunaDoTiro, out iColunaDoTiro);

    while (!LinhaDoTiro || !ColunaDoTiro || !espacoLivre)
    {
        Console.Write(posicaoInvalida);
        posicaoNavio = Console.ReadLine().ToUpper();

        ValidaçãoDeTiroVálido();

        LinhaDoTiro = letrasDoIndiceDeLinhas.Contains(sLinhaDoTiro);
        ColunaDoTiro = int.TryParse(sColunaDoTiro, out iColunaDoTiro);

    }

    iLinhaDoTiro = Array.IndexOf(letrasDoIndiceDeLinhas, sLinhaDoTiro);

}

void ValidaçãoDeTiroVálido()
{
    if (posicaoNavio.Length == 2)
    {
        sLinhaDoTiro = posicaoNavio.Substring(0, 1);
        sColunaDoTiro = posicaoNavio.Substring(1, 1);
        espacoLivre = true;
    }
    else if (posicaoNavio.Length == 3)
    {
        sLinhaDoTiro = posicaoNavio.Substring(0, 1);
        sColunaDoTiro = posicaoNavio.Substring(1, 2);
        espacoLivre = true;
    }
    else
    {
        espacoLivre = false;
    }
}
#endregion

#endregion


#region Titulo do Jogo
Console.WriteLine(@"
  ____            _             _   _                 _   _                           _               _              _     _            ____               _        
 | __ )    __ _  | |_    __ _  | | | |__     __ _    | \ | |   __ _  __   __   __ _  | |             | |       ___  | |_  ( )  ___     / ___|   ___     __| |   ___ 
 |  _ \   / _` | | __|  / _` | | | | '_ \   / _` |   |  \| |  / _` | \ \ / /  / _` | | |    _____    | |      / _ \ | __| |/  / __|   | |      / _ \   / _` |  / _ \
 | |_) | | (_| | | |_  | (_| | | | | | | | | (_| |   | |\  | | (_| |  \ V /  | (_| | | |   |_____|   | |___  |  __/ | |_      \__ \   | |___  | (_) | | (_| | |  __/
 |____/   \__,_|  \__|  \__,_| |_| |_| |_|  \__,_|   |_| \_|  \__,_|   \_/    \__,_| |_|             |_____|  \___|  \__|     |___/    \____|  \___/   \__,_|  \___|");
Console.WriteLine(@"
    _            _                   __  __          _                           _                               _         
   /_\    _  _  | |_   ___   _ _    |  \/  |  __ _  | |_   ___   _  _   ___     /_\    _  _   __ _   _  _   ___ | |_   ___ 
  / _ \  | || | |  _| / _ \ | '_|   | |\/| | / _` | |  _| / -_) | || | (_-<    / _ \  | || | / _` | | || | (_-< |  _| / _ \
 /_/ \_\  \_,_|  \__| \___/ |_|     |_|  |_| \__,_|  \__| \___|  \_,_| /__/   /_/ \_\  \_,_| \__, |  \_,_| /__/  \__| \___/
                                                                                             |___/                          
");
#endregion

#region Regras do Jogo
Console.WriteLine(@"
  ___                                
 | _ \  ___   __ _   _ _   __ _   ___
 |   / / -_) / _` | | '_| / _` | (_-<
 |_|_\ \___| \__, | |_|   \__,_| /__/
             |___/                 

O jogo de batalha Naval consiste em posicionar embaracações no seu campo e seu
adversário faz o mesmo, respeitando o posicionamento onde não é permitido embarcações
colcadas na diagonal, fora do tabuleiro ou mesmo embarcações que não correspondem ao tamanho desejado.

Após esse passo cada jogador tenta acertar a embarcação do seu adversário.

Ganha aquele que afundar todas as embarcações do seu adversário.");

Console.WriteLine(@" 
=========== Clique Qualquer Tecla Para Continuar ===========");
Console.ReadKey();
Console.Clear();
#endregion

#region Numero de Jogadores
selecaoJogadores:
Console.WriteLine(@"
  ___         _         _                                                                             _             _                          _                        
 / __|  ___  | |  ___  (_)  ___   _ _    ___     ___     _ _    _  _   _ __    ___   _ _   ___     __| |  ___      (_)  ___   __ _   __ _   __| |  ___   _ _   ___   ___
 \__ \ / -_) | | / -_) | | / _ \ | ' \  / -_)   / _ \   | ' \  | || | | '  \  / -_) | '_| / _ \   / _` | / -_)     | | / _ \ / _` | / _` | / _` | / _ \ | '_| / -_) (_-<
 |___/ \___| |_| \___| |_| \___/ |_||_| \___|   \___/   |_||_|  \_,_| |_|_|_| \___| |_|   \___/   \__,_| \___|    _/ | \___/ \__, | \__,_| \__,_| \___/ |_|   \___| /__/
                                                                                                                 |__/        |___/                                      
1 - Jogue contra o computador e prove que o ser humano é melhor que as máquinas!!!
2 - Jogue contra seu amigo e descubra quem é o melhor comandate!!!");

int escolhaMenuJogadores;
var validacaoMenuJogadores = int.TryParse(Console.ReadLine(), out escolhaMenuJogadores);
while ((escolhaMenuJogadores != 1 && escolhaMenuJogadores != 2) || !validacaoMenuJogadores)
{
    Console.Write("Opção Inválida, escolha uma das opção do Jogo, por favor tente novamente: ");
    validacaoMenuJogadores = int.TryParse(Console.ReadLine(), out escolhaMenuJogadores);
}

#region Jogo contra o Computador
if (escolhaMenuJogadores == 1)
{
    Console.Clear();
    Console.WriteLine(@"
                                                                                                                                                                                                                                                    
 _ .-') _       ('-.      .-')                                               _ (`-.      ('-.        ('-. .-.                 _   .-')        ('-.           .-') _                 
( (  OO) )    _(  OO)    ( OO ).                                            ( (OO  )   _(  OO)      ( OO )  /                ( '.( OO )_     ( OO ).-.      ( OO ) )                
 \     .'_   (,------.  (_)---\_)     .-----.    ,--. ,--.     ,--.        _.`     \  (,------.     ,--. ,--.   ,--. ,--.     ,--.   ,--.)   / . --. /  ,--./ ,--,'    .-'),-----.  
 ,`'--..._)   |  .---'  /    _ |     '  .--./    |  | |  |     |  |.-')   (__...--''   |  .---'     |  | |  |   |  | |  |     |   `.'   |    | \-.  \   |   \ |  |\   ( OO'  .-.  ' 
 |  |  \  '   |  |      \  :` `.     |  |('-.    |  | | .-')   |  | OO )   |  /  | |   |  |         |   .|  |   |  | | .-')   |         |  .-'-'  |  |  |    \|  | )  /   |  | |  | 
 |  |   ' |  (|  '--.    '..`''.)   /_) |OO  )   |  |_|( OO )  |  |`-' |   |  |_.' |  (|  '--.      |       |   |  |_|( OO )  |  |'.'|  |   \| |_.'  |  |  .     |/   \_) |  |\|  | 
 |  |   / :   |  .--'   .-._)   \   ||  |`-'|    |  | | `-' / (|  '---.'   |  .___.'   |  .--'      |  .-.  |   |  | | `-' /  |  |   |  |    |  .-.  |  |  |\    |      \ |  | |  | 
 |  '--'  /   |  `---.  \       /  (_'  '--'\   ('  '-'(_.-'   |      |    |  |        |  `---.     |  | |  |  ('  '-'(_.-'   |  |   |  |    |  | |  |  |  | \   |       `|  '-'  |
 `-------'     `------'  `-----'      `-----'    `-----'       `------'     `--'       `------'     `--' `--'   `-----'       `--'   `--'    `--' `--'  `--'  `--'        `-------'  


MEU MESTRE AINDA NÃO ME ADAPTOU PARA GANHAR DE VOCÊ NESTE JOGO, EM BREVE MOSTRAREI QUE SOU O MELHOR!!!


=========== Pressione Qualquer Tecla Para Voltar Para a Seleção de Jogadores ===========");
    Console.ReadKey();
    Console.Clear();
    goto selecaoJogadores;

}
#endregion
#region Jogo Multiplayer
else if (escolhaMenuJogadores == 2)
{
    Console.Clear();
    JogoMultiplayer();
}
#endregion

#endregion
