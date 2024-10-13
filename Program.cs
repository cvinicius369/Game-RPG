/*By:         Caio Vinicius
* Project:    RPG in C# (C-Sharp)
* Name Game:  A Sombra do Corvo
*E-mail:      vinicius182102@gmail.com

* Notas: Ultima atualização oficial em: 13/10/2024 - status: em andamento
            Foi implementada a persistencia de dados e correção de bugs, permitindo agora que o
                codigo use novos atributos como habilidades especiais e energia vital
        
* Atividades: 
            - Tornar o codigo limpo (clean code)
            - implementar mapa em pixel art
            - alterar itens de compra (para separar itens que podem ser comprados durante batalhas e
                itens que podem ser comprados foras das batalhas)
*/
using Battles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;

public class DataManagment{
    const string localFile = "./dataGamer.csv";
    public static bool existData(string? name){
        var dados = LerArquivo();
        return dados.Any(d => d[1].Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    public static bool existID(string? id){
        var dados = LerArquivo();
        return dados.Any(d => d[0].Equals(id, StringComparison.OrdinalIgnoreCase));
    }
    public static string ObterValor(string? nome, int coluna) {
        var dados = LerArquivo();
        var dado = dados.FirstOrDefault(d => d[1].Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (dado != null) { int index = coluna; return index != -1 ? dado[index] : "Coluna inválida.";
        }
        return "Dado não encontrado.";
    }
    public static void ReadData(string id){
        var dados = LerArquivo();
        var dado = dados.FirstOrDefault(d => d[0] == id);
        if (dados != null){ Console.WriteLine(string.Join('\t', dado)); } 
        else { Console.WriteLine("Dado nao encontrado!"); }
    }
    public static void UpdateData(string id, int column, string newData){
        var dados = LerArquivo();
        var dado = dados.FirstOrDefault(d => d[0] == id);
        if (dado != null){
            if (column > -1){
                dado[column] = newData;
                WriteFile(dados);
                Console.WriteLine("Dado Alterado com sucesso");
            } else { Console.WriteLine("Coluna Invalida"); }
        } else { Console.WriteLine("Nenhum dado encontrado!"); }
    }
    public static void NewData(params string[] new_data){
        using (StreamWriter sw = new StreamWriter(localFile, true)){ sw.WriteLine(string.Join(";", new_data)); }
    }
    public static void DeleteData(string id){
        var dados = LerArquivo();
        var dado = dados.FirstOrDefault(d => d[0] == id);
        if(dado != null){
            dados.Remove(dado);
            WriteFile(dados);
            Console.WriteLine("Dado deletado com sucesso!");
        }
    }
    static List<string[]> LerArquivo(){
        var dados = new List<string[]>();
        if (File.Exists(localFile)){
            using (StreamReader sr = new StreamReader(localFile)){ string line;
                while ((line = sr.ReadLine()) != null){ dados.Add(line.Split(';')); }  
            } } return dados;
    }
    static void WriteFile(List<string[]> dados){
        using (StreamWriter sw = new StreamWriter(localFile)){ foreach(var dado in dados){ sw.WriteLine(string.Join(";", dado)); } }
    }

    public static void saveData(Entity user){
        string name = user.getName(); string level = user.getLevel();
        string skill = user.getSkill(); string ultimate = user.getUltimate();
        string typeUser = user.getTypeUser(); 
        string progress = Convert.ToString(user.getProgress());
        string hp = Convert.ToString(user.getHp()); 
        string def = Convert.ToString(user.getDef()); 
        string atk = Convert.ToString(user.getAtk());
        string doblons = Convert.ToString(user.getDoblons()); 
        string xp = Convert.ToString(user.getXp());
        string power = Convert.ToString(user.getPower()); 
        string vitalEnergy = Convert.ToString(user.getVitalEnergy());
        string idUser = Convert.ToString(user.getId());
        UpdateData(idUser, 2, level);     UpdateData(idUser, 3, hp);
        UpdateData(idUser, 4, def);       UpdateData(idUser, 5, atk);
        UpdateData(idUser, 6, doblons);   UpdateData(idUser, 7, xp);
        UpdateData(idUser, 8, power);     UpdateData(idUser, 9, vitalEnergy);
        UpdateData(idUser, 10, skill);    UpdateData(idUser, 11, ultimate);
        UpdateData(idUser, 12, typeUser); UpdateData(idUser, 13, progress);
        Console.WriteLine("Dados Salvos com Sucesso.");
    }
}
class Dialogo
{
    public static string? nome;
    public static void poem1(){
        Console.WriteLine("              A sombra do corvo cobre meu coração, Cessa o jorro de minhas lagrimas");
        Console.WriteLine("                                 - Poema Seordah, autor desconhecido.");
        Principal.Separador();
    }

    public static void presents1(){
        Console.ReadKey();
        string[] textos = new string[]
        {
            "- Do que você se recorda? - Voz misteriosa\n",
            "- Ruas...Uma gangue de garotos...um caolho...\n",
            "- Você tem um nome? \n",
            "- Meu nome...\n"
        };

        foreach (string texto in textos) { ImprimirComAtraso(texto, 50); }
        Console.Write("Digite seu nome: ");
        nome = Console.ReadLine();

        if (!string.IsNullOrEmpty(nome)){
            string textonome = $"Meu nome é {nome}\n";
            ImprimirComAtraso(textonome, 50);
            Console.ReadKey();
        } else { Console.WriteLine("Nao sabia que alguem teria o nome de Null ou Vazio nesse jogo ^^"); }

        Principal.Separador();
        string[] textos2 = new string[]
        {
           "- Voce foi encontrado na rua, inconsciente devido a uma surra que a gangue do caolho lhe deu, Frentis te trouxe para cá, a casa da Sexta Ordem!\n",
           "- Além disso, Mestre Sollis deseja que você vá até ele para se apresentar.\n",
           "Chegando ao local mestre Sollis não disse nada além de uma ordem para que voce levantasse a espada de madeira e o atacasse.\n"
        };
        foreach (string texto in textos2) { ImprimirComAtraso(texto, 50); }
    }
    private static void ImprimirComAtraso(string texto, int atraso){
        foreach (char c in texto){
            Console.Write(c);
            Thread.Sleep(atraso); // Atraso entre cada caractere
        }
        Console.ReadKey();
    }
}
class Dialogo2 : Dialogo{
    public static void Presents3()
    {
        string[] textos3 = new string[]
        {
            "- Mestre Sollis te massacrou! - Comentou o rapaz ruivo enquanto lhe entregava bandagens - Tome, vai te ajudar a se curar.\n",
            "O rapaz entregou um frasco de flor rubra e um traje de couro\n"
        };
        foreach (string texto in textos3) { ImprimirComAtraso(texto, 50); }
        Console.ReadKey();
        Principal.Separador();
    }
    private static void ImprimirComAtraso(string texto, int atraso)
    {
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(atraso); // Atraso entre cada caractere
        }
        Console.ReadKey();
    }
};
class Game{
    public static void Starting(Entity user){
        Entity sollis = new Entity(0, "Sollis", "Mestre da 4a Ordem", 200, 10, 80, 20, 1000, 10000, "Super Agilidade", "Super Forca", 10000, "Comum", 0);
        if (int.Parse(DataManagment.ObterValor(user.getName(), 13)) == 0){ Starting(user); }
        else if (int.Parse(DataManagment.ObterValor(user.getName(), 13)) == 1){ Battle_F1.Battle1(user);}

        Console.WriteLine("Jogo Iniciado");
        Console.WriteLine("Para apresentar seus atributos digite 1, 2 para iniciar o jogo ou 3 para sair");
        Principal.Separador();
        string? action = Console.ReadLine();
        if (action == "1") {
            Console.WriteLine("Nome: "          + user.getName());
            Console.WriteLine("Nivel: "         + user.getLevel());
            Console.WriteLine("Vida: "          + user.getHp());
            Console.WriteLine("Dano: "          + user.getAtk());
            Console.WriteLine("Defesa: "        + user.getDef());
            Console.WriteLine("Doblons: "       + user.getDoblons());
            Console.WriteLine("XP: "            + user.getXp());
            Console.WriteLine("Poder Maximo: "  + user.getPower());
            Console.WriteLine("Energia Vital: " + user.getVitalEnergy());
            Console.WriteLine("Skill: "         + user.getSkill());
            Console.WriteLine("Ultimate: "      + user.getUltimate());
            Principal.Separador();
            Console.ReadKey();
            Dialogo.poem1();
            Dialogo.presents1();
            PrincipalsBattles.Battle_Initial(user, sollis);
        }
        else{ 
            if (action == "2") { 
                Dialogo.poem1();
                Dialogo.presents1();
                Console.Write("Digite 1 para ir a casa da Ordem ou 2 para ir a batalha: ");
                string? newaction = Console.ReadLine(); Principal.Separador();
                if (newaction == "1") {
                    Taverna.ComprasInBattle(user);
                    PrincipalsBattles.Battle_Initial(user, sollis);
                }
                else{ 
                    if (newaction == "2") { PrincipalsBattles.Battle_Initial(user, sollis); }
                    else {
                        Console.WriteLine("Acao Invalida!");
                        Console.ReadKey();
                        Console.Clear();
                        Starting(user);
                    }
               }
            } else { 
                if (action == "3") { Console.WriteLine("Saindo . . ."); }
                else {
                    Console.WriteLine("Comando não esperado!");
                    Console.ReadKey();
                    Starting(user);
                }
            }
        }
    }
}
class Taverna{
    public static void ComprasInBattle(Entity user){
        Console.WriteLine("[1] - Elixir da Cura (+25 HP): 5 Doblons       | [2] - Espada Comum (+10 ATK): 20 Doblons");
        Console.WriteLine("[3] - Armadura de Couro (+10 DEF): 20 Doblons  | [0] - Voltar para a batalha");
        Console.Write("-> "); int compra = int.Parse(Console.ReadLine());
        
        if (compra == 0) { Console.WriteLine("Saindo da taverna"); }
        else if (compra == 1){
            if (user.getDoblons() >= 5){
                user.setDoblons(user.getDoblons() - 5);
                user.setHp(user.getHp() + 25);
                Console.WriteLine("Compra Realizada, você ganhou +25 HP");
            } else { Console.WriteLine("Doblons Insuficientes"); }
        } else if (compra == 2){
            if (user.getDoblons() >= 20){
                user.setDoblons(user.getDoblons() - 20);
                user.setAtk(user.getAtk() + 10);
                Console.WriteLine("Compra Realizada, você ganhou +10 ATK");
            } else { Console.WriteLine("Doblons Insuficientes"); }
        } else if (compra == 3){
            if (user.getDoblons() >= 20){
                user.setDoblons(user.getDoblons() - 20);
                user.setDef(user.getDef() + 10);
                Console.WriteLine("Compra Realizada, você ganhou +10 DEF");
            } else { Console.WriteLine("Doblons Insuficientes"); }
        } else { Console.WriteLine("Valor invalido saindo da taverna"); }
    }
    public static void CompraOutsideBattle(Entity user){
        Console.WriteLine("Ainda em desenvolvimento");
    }
}
class Principal{
    public static void Separador() { Console.WriteLine("----------------------------------------------------------------------------------------------------------------------"); }
    public static int Jogadado(){
        int dado; Random rdm = new Random();
        dado = rdm.Next(100); Console.WriteLine("[DADO LANCADO] -> " + dado);
        return dado;
    }
    public static void Main(string[] args){
        string? iniciogame;
        Console.WriteLine("                              A    S O M B R A    D O    C O R V O");
        Separador();

        Console.Write("Digite seu nome: ");
        int novoId = 1;
        string? nomeplayer = Console.ReadLine();

        if (DataManagment.existData(nomeplayer)){  Console.WriteLine($"Bem vindo de volta Mestre {nomeplayer}"); } 
        else {
            while (DataManagment.existID(novoId.ToString())){ novoId += 1; }
            Console.WriteLine("Escolha seu dom: ");
            Console.WriteLine("[1] - Canção do Sangue  | [2] - Conexão com Animais  | [3] - Manipulação do Fogo");
            Console.WriteLine("[4] - Projeção Astral   | [5] - Super Força          | [6] - Controle Corporal");
            int dote = int.Parse(Console.ReadLine());

            if (dote == 1) { DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "10", "sexto sentido", "Danca Sangrenta", "Sangue", "0"); }
            else if (dote == 2){ DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "10", "Reforco Animal", "Controle Animal", "Animal", "0"); }
            else if(dote == 3){ DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "10", "Lanca Chamas", "Firestorm", "Fogo", "0"); }
            else if (dote == 4){ DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "10", "Analise Astral", "Morte Astral", "Alma", "0"); }
            else if (dote == 5){ DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "10", "Estrangulamento", "Martelo da Morte", "Forca", "0"); }
            else if (dote == 6){ DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "10", "Paralisacao", "Auto Destruicao", "Controle", "0"); }
            else { DataManagment.NewData(novoId.ToString(), nomeplayer, "nenhum", "100", "0", "10", "25", "0", "0", "10", "nenhum", "Furia de Soldado", "Comum", "0"); }
            Console.WriteLine("Novo player cadastrado!");
            Console.WriteLine($"Dado criado para {nomeplayer} com sucesso.");
        }
        int idUser      = int.Parse(DataManagment.ObterValor(nomeplayer, 0));  
        string nameUser = DataManagment.ObterValor(nomeplayer, 1);
        string level    = DataManagment.ObterValor(nomeplayer, 2); 
        int hp          = int.Parse(DataManagment.ObterValor(nomeplayer, 3)); 
        int def         = int.Parse(DataManagment.ObterValor(nomeplayer, 4));
        int atk         = int.Parse(DataManagment.ObterValor(nomeplayer, 5));
        int doblons     = int.Parse(DataManagment.ObterValor(nomeplayer, 6)); 
        int xp          = int.Parse(DataManagment.ObterValor(nomeplayer, 7));
        int power       = int.Parse(DataManagment.ObterValor(nomeplayer, 8));
        int vitalEnergy = int.Parse(DataManagment.ObterValor(nomeplayer, 9));
        string skill    = DataManagment.ObterValor(nomeplayer, 10);
        string ultimate = DataManagment.ObterValor(nomeplayer, 11);
        string typeUser = DataManagment.ObterValor(nomeplayer, 12);

        Entity user = new Entity(idUser, nameUser, level, hp, def, atk, doblons, xp, power, skill, ultimate, vitalEnergy, typeUser, 0);
        DataManagment.ReadData(novoId.ToString());

        Console.Write("[0] - Taverna  | [1] - Iniciar Game");
        iniciogame = Console.ReadLine();

        if (iniciogame == "1") { 
            if (int.Parse(DataManagment.ObterValor(nomeplayer, 13)) == 0){ Game.Starting(user); }
            else if (int.Parse(DataManagment.ObterValor(nomeplayer, 13)) == 1){ Battles.Battle_F1.Battle1(user);}
        } else {
            Console.WriteLine("Tecla não esperada!");
            Console.ReadKey();
            Console.Clear();
            Main(args);
        }
    }
};
