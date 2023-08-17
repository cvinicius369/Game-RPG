//------------------------------------------------------------------------------| Atributos do sistema
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
//------------------------------------------------------------------------------| Caixas de dialogos
class Dialogo
{
    public static string nome;
    public static void poem1()
    {
        Console.WriteLine("              A sombra do corvo cobre meu coração, Cessa o jorro de minhas lagrimas");
        Console.WriteLine("                                 - Poema Seordah, autor desconhecido.");
        Principal.Separador();
    }
    public static void presents1()
    {
        Console.ReadKey();
        string texto1 = "- Do que você se recorda? - Voz misteriosa\n", texto2 = "- Ruas...Uma gangue de garotos...um caolho...\n";
        string texto3 = "- Você tem um nome? \n", texto4 = "- Meu nome...\nDigite seu nome: ";
        foreach (char c in texto1)
        {
            Console.Write(c);
            Thread.Sleep(50); // Atraso de 50 milissegundos entre cada caractere
        }
        Console.ReadKey();
        foreach (char c in texto2)
        {
            Console.Write(c);
            Thread.Sleep(50); // Atraso de 50 milissegundos entre cada caractere
        }
        Console.ReadKey();
        foreach (char c in texto3)
        {
            Console.Write(c);
            Thread.Sleep(50); // Atraso de 50 milissegundos entre cada caractere
        }
        Console.ReadKey();
        foreach (char c in texto4)
        {
            Console.Write(c);
            Thread.Sleep(50); // Atraso de 50 milissegundos entre cada caractere
        }
        nome = Console.ReadLine();
        if (nome != "" || nome != null)
        {
            string textonome = $"Meu nome é {nome}";
            foreach (char c in textonome)
            {
                Console.Write(c);
                Thread.Sleep(50); // Atraso de 50 milissegundos entre cada caractere
            }
            Console.ReadKey();
        } else
        {
            Console.WriteLine("Nao sabia que alguem teria o nome de Null ou Vazio nesse jogo ^^");
        }
        Principal.Separador();
    }
    public static void presents2()
    {
        string texto = "- Voce foi encontrado na rua, inconsciente devido a uma surra que a gangue do caolho lhe deu, Frentis te trouxe para cá, a casa da Sexta Ordem!\n";
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(40); // Atraso de 40 milissegundos entre cada caractere
        }
        Console.ReadKey();
        string texto2 = "- Mestre Sollis ordena que você vá até ele se apresentar!\n";
        string texto3 = "Chegando ao local mestre Sollis não disse nada além de uma ordem para que voce levantasse a espada de madeira e o atacasse.\n";
        foreach (char c in texto2)
        {
            Console.Write(c);
            Thread.Sleep(40); // Atraso de 40 milissegundos entre cada caractere
        }
        Console.ReadKey();
        foreach (char c in texto3)
        {
            Console.Write(c);
            Thread.Sleep(40); // Atraso de 40 milissegundos entre cada caractere
        }
        Console.ReadKey();
        Principal.Separador();
    }
}
//------------------------------------------------------------------------------| Classe Loja
class Loja
{
    public static int[] itens;
    public static int[] valores;
    //Função para criar loja
    public static int Negocios()
    {
        //Variaveis
        int espada = 20, adaga = 10, armadura = 100, peitocouro = 25, peitoferro = 50, florrubra = 25;
        itens = new int[] { espada, adaga, armadura, peitocouro, peitoferro, florrubra };
        int espadav = 10, adagav = 3, peitocv = 5, peitofv = 10, armadurav = 25, florrubrav = 5;
        valores = new int[] { espadav, adagav, peitocv, peitofv, armadurav, florrubrav };

        Console.WriteLine("ITENS DISPONÍVEIS");
        Principal.Separador();
        Console.WriteLine("1 - Espada: " + valores[0] + " moedas| Dano: " + itens[0]);
        Console.WriteLine("2 - Adaga: " + valores[1] + " moedas| Dano: " + itens[1]);
        Console.WriteLine("3 - Armadura: " + valores[4] + " moedas| Defesa: " + itens[2]);
        Console.WriteLine("4 - Peitoral de Couro: " + valores[2] + " moedas| Defesa: " + itens[3]);
        Console.WriteLine("5 - Peitoral de Ferro: " + valores[3] + " moedas| Defesa: " + itens[4]);
        Console.WriteLine("6 - Flor Rubra: " + valores[5] + " moedas| Regeneração: +" + itens[5]);
        Principal.Separador();

        return itens.Length;
    }
};
//------------------------------------------------------------------------------| Classe Game
class Game
{
    public static int vidaplayer = Player.vida, defesaplayer = Player.defesa, danoplayer = Player.dano;
    public static int vidasollis = Personagem.vidaSollis, defesasollis = Personagem.defesaSollis, danosollis = Personagem.danoSollis;
    public static string[] cartas { get; set; }//Transferi os dados da classe Personagem.Persons para que
                                                //Fosse possivel utilizar os dados delas.
    //Funções para o inicio do game
    public static int Starting()
    {
        Player player = new Player(); // Cria uma instância de Player
        Console.WriteLine("Jogo Iniciado");
        Principal.Separador();
        Dialogo.poem1();
        Dialogo.presents1();
        Dialogo.presents2();
        Player.dadosplayer();
        BattleSollis1();
        return 0;
    }
    public static void BattleSollis1()
    {
        Player player = new Player();
        Principal principal = new Principal();
        Personagem personagem = new Personagem();
        Dialogo dialogo = new Dialogo();
        int dado = Principal.Jogadado();
        string nome = Dialogo.nome;
        string carta0 = "Nenhuma", carta1 = Personagem.PersonsVAS(), carta2 = Personagem.PersonsMSo();
        cartas = new string[] { carta0, carta1, carta2 };

        while (vidaplayer > 0 && vidasollis > 0)
        {
            int dado1 = Principal.Jogadado();
            string option1;
            if (dado1 > 50)
            {
                Console.WriteLine("SORTE: Você ataca primneiro!");
                vidasollis -= danoplayer;
                Console.WriteLine($"Oponente: {carta2} ficou com: {vidasollis} de vida após o ataque de: {nome} que teve: {danoplayer} de dano");
                Console.ReadKey();
                Principal.Separador();
            }
            else
            {
                Console.WriteLine("Inimigo começa primeiro!");
                vidaplayer -= danosollis;
                Console.WriteLine($"{nome} ficou com: {vidaplayer} De vida após o ataque de: {carta2} que teve: {danosollis} de dano");
                Console.ReadKey();
                Principal.Separador();
            }
            Console.WriteLine("Digite 1 para ir á loja ou qualquer tecla para continuar o jogo: ");
            option1 = Console.ReadLine();

            if (option1 == "1")
            {
                Principal.Separador();
                Loja.Negocios();
                Compras.comprasplay();
            }
        }
        if (vidaplayer <= 0)
        {
            Console.WriteLine("Você perdeu! O oponente venceu.");
        }
        else if (vidasollis <= 0)
        {
            Console.WriteLine("Parabéns! Você venceu o oponente.");
        }
    }
};

//------------------------------------------------------------------------------| Classe Player
class Player
{
    //Dados do player
    public static int[] atributos { get; set; }
    public static int vida = 100, defesa = 0, dano = 5, stamina = 50, moeda = 20;
    public static string[] cartas { get; set; }
    public static void dadosplayer()
    {
        Personagem personagem = new Personagem();
        int vida = 100, defesa = 0, dano = 5, stamina = 50, moeda = 20;
        atributos = new int[] { vida, defesa, dano, stamina, moeda};
        string carta0 = "Nenhuma", carta1 = Personagem.PersonsVAS(), carta2 = Personagem.PersonsMSo();
        cartas = new string[] { carta0, carta1, carta2};
        Dialogo dialogo = new Dialogo();

        //int action;

        Principal.Separador();
        Console.WriteLine("DADOS DE " + Dialogo.nome);
        Principal.Separador();
        Console.WriteLine("Vida: " + atributos[0]);
        Console.WriteLine("Defesa: " + atributos[1]);
        Console.WriteLine("Dano: " + atributos[2]);
        Console.WriteLine("Stamina: " + atributos[3]);
        Console.WriteLine("Doblons: " + atributos[4]);
        Console.WriteLine("Carta: " + cartas[1]);
        Principal.Separador();

        Console.WriteLine("Digite 1 para compras");
        string action = Console.ReadLine();
        if (action == "1")
        {
            Compras.comprasplay();
        }
        else
        {
            Console.WriteLine("Nao entendi sua solicitação...Jogo iniciando");
        }
        Principal.Separador();
    }
};
/*
    //Na classe e função acima, foram atribuidos valores ao player, todos os atributos
    //Ao final da função dadosplayer() o player digitando 1 será direcionado para a classe 
        compras : player, onde ele poderá fazer compras para sua melhoria pessoal
 */
//------------------------------------------------------------------------------| Classe player-Compras
class Compras : Player
{
    public static void comprasplay()
    {
        Game game = new Game();
        Loja.Negocios();
        Console.WriteLine("1. Espada\n2. Adaga\n3. Armadura Completa\n4. Peitoral de Couro\n5. Peitoral de Ferro\n6. Flor Rubra");
        Console.Write("Produto: ");

        if (int.TryParse(Console.ReadLine(), out int compra))
        {
            if (compra == 1)
            {
                if (moeda >= 10) // Verifica se há moedas suficientes
                {
                    moeda -= 10; // Subtrai as moedas gastas
                    atributos[2] += 20; // Aumenta o dano
                    Game.danoplayer += 20;

                    Console.WriteLine("Você comprou uma Espada, gastou 20 Doblons e aumentou seu dano para " + atributos[2]);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
            else if (compra == 2)
            {
                if (moeda >= 3)
                {
                    moeda -= 3; //Subtrai os doblons
                    dano += 10; //Aumenta o dano
                    Game.danoplayer += 10;

                    Console.WriteLine("Você comprou uma Adaga, gastou 5 Doblons e aumentou seu dano para " + dano);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
            else if (compra == 3)
            {
                if (moeda >= 25)
                {
                    moeda -= 25; //Subtrai os doblons
                    defesa += 100; //Aumenta a defesa
                    Game.defesaplayer += 100;

                    Console.WriteLine("Você comprou um set de Armadura, gastou 25 Doblons e aumentou sua defesa para " + defesa);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            } else if (compra == 4)
            {
                if (moeda >= 5)
                {
                    moeda -= 5; //Subtrai os doblons
                    defesa += 25; //Aumenta a defesa
                    Game.danoplayer += 25;

                    Console.WriteLine("Você comprou um peitoral de couro, gastou 5 Doblons e aumentou sua defesa para " + defesa);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            } else if (compra == 5)
            {
                if (moeda >= 10)
                {
                    moeda -= 10; //Subtrai os doblons
                    defesa += 50; //Aumenta a defesa
                    Game.danoplayer += 50;

                    Console.WriteLine("Você comprou um peitoral de ferro, gastou 10 Doblons e aumentou sua defesa para " + defesa);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            } else if (compra == 6)
            {
                if (moeda >= 5)
                {
                    moeda -= 5; //Subtrai os doblons
                    vida += 25; //Aumenta a vida
                    Game.vidaplayer += 25;

                    Console.WriteLine("Você comprou uma flor rubra, gastou 5 Doblons e aumentou sua vida para " + vida);
                }
                else
                {
                    Console.WriteLine("Doblons Insuficientes");
                }
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
        }
        Principal.Separador();
    }
};
//------------------------------------------------------------------------------| Classe Personagem
class Personagem
{
    //Função para criar personagens
    public static string PersonsVAS()
    {
        string carta1 = "Vaelin Al Sorna";
        return carta1;
    }
    public static string PersonsMSo()
    {
        string carta2 = "Mestre Sollis";
        return carta2;
    }
    //Dados do Vaelin
    public static int[] atributosVaelin { get; set; }
    public static int vidaVaelin = 150, defesaVaelin = 70, danoVaelin = 75, staminaVaelin = 250; 
    public static int[] atributosMSo  { get; set; }
    public static int vidaSollis = 200, defesaSollis = 80, danoSollis = 85, staminaSollis = 250;
    //Repeti essas linhas de codigo para que fosse possível usa-las em outras classes
    public static int VaelinAlSorna(string[] args)
    {
        int vida = 150, defesa = 70, dano = 75, stamina = 250;
        atributosVaelin = new int[] { vida, defesa, dano, stamina };

        Principal.Separador();
        Console.WriteLine("DADOS DE " + Personagem.PersonsVAS());
        Principal.Separador();
        Console.WriteLine("Vida: " + atributosVaelin[0]);
        Console.WriteLine("Defesa: " + atributosVaelin[1]);
        Console.WriteLine("Dano: " + atributosVaelin[2]);
        Console.WriteLine("Stamina: " + atributosVaelin[3]);
        Principal.Separador();
        return 0;
    }
    //Dados do Mestre Sollis
    public static int MestreSollis()
    {
        int vida = 200, defesa = 80, dano = 85, stamina = 250;
        atributosMSo = new int[] { vida, defesa, dano, stamina };
        return 0;
    }
};
//------------------------------------------------------------------------------| Classe principal
class Principal
{
    //Função para criar uma linha separadora
    public static void Separador()
    {
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
    }
    //Função para gerar um valor aleatorio
    public static int Jogadado()
    {
        int dado;
        Random rdm = new Random();
        dado = rdm.Next(100);
        Console.WriteLine("[DADO LANCADO] -> " + dado);
        return dado;
    }
    //Metodo para mostrar atributos
    public static void AmostraAtributos()
    {

    }
    //Função principal
    public static void Main(string[] args)
    {
        string iniciogame;
        Console.WriteLine("                          A    S O M B R A    D O    C O R V O                   ");
        Separador();
        Console.Write("Digite 1 para iniciar o game: ");
        iniciogame = Console.ReadLine();
        
        if (iniciogame == "1")
        {
            Game.Starting();
        }
    }
};
