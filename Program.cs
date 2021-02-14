using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_da_Velha_____Jabil
{
    class Program
    {
        //BRUNO SILVA RODRIGUES
        #region voidMain
        static void Main(string[] args)
        {
            Tabuleiro t = new Tabuleiro();
            Jogador j = new Jogador();
            int mn = 0;    //Declarando a variável mn para ser armazenada o valor retornado do método menu, para não precisar ficar chamando o método várias vezes
            mn = menu(); //chamando o método menu e armazenando o resultado em mn



            if (mn != 1 && mn != 2) //se mn for um resultado inválido(diferente de 1 ou 2) o usuário digita novamente até ser um número válido
            {
                while (mn != 1 && mn != 2)
                {

                    Console.Clear(); //Limpando a tela
                    Console.WriteLine("Opção inválida, Tente novamente: "); //Fazendo o usuário digitar de novo caso não tenha digitado as opções válidas, "1" ou "2"
                    mn = menu();


                    if (mn == 1) //quando o usuário digitar 1 vai para o modo de jogo Jogador vs Jogador chamando o método jogadorvsJogador()
                    {
                        j.jogadorvsJogador(t.tabuleiroFachada, t.tabuleiroPosicoes, t.tabuleiroPontos);
                    }
                    if (mn == 2) //quando o usuário digitar 2 vai para o modo de jogo automático chamando o método automatico()
                    {
                        j.automatico();
                    }

                }
            }
            else
            {
                if (mn == 1) //quando o usuário digitar 1 vai para o modo de jogo Jogador vs Jogador chamando o método jogadorvsJogador()
                {
                    j.jogadorvsJogador(t.tabuleiroFachada, t.tabuleiroPosicoes, t.tabuleiroPontos);
                }
                if (mn == 2) //quando o usuário digitar 2 vai para o modo de jogo automático chamando o método automatico()
                {
                    j.automatico();
                }

            }

        }

        #endregion


        #region classes
        //********************CLASSES********************

        public class Tabuleiro
        {
            public string[,] tabuleiroFachada = new string[3, 3]; //DECLARANDO AS MATRIZES TABULEIRO FACHADA(QUE VAI SER O TABULEIRO COM NÚMEROS QUE APARECE NA TELA) E
            public int[,] tabuleiroPosicoes = new int[3, 3];      //TABULEIRO REAL(QUE VAI SER O TABULEIRO ONDE OS VALORES SERÃO SUBSTITUÍDOS POR "X" E "O"
            public int[,] tabuleiroPontos = new int[3, 3];

            

            public void mostraTabuleiro(string[,] tabuleiroFachada) //Método para mostrar o tabuleiro com os números de 1 a 9
            {
                Console.WriteLine("\t");
                Console.WriteLine(tabuleiroFachada[0, 0] + " | " + tabuleiroFachada[0, 1] + " | " + tabuleiroFachada[0, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(tabuleiroFachada[1, 0] + " | " + tabuleiroFachada[1, 1] + " | " + tabuleiroFachada[1, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(tabuleiroFachada[2, 0] + " | " + tabuleiroFachada[2, 1] + " | " + tabuleiroFachada[2, 2]);
                Console.WriteLine("\t");
            }

            public int contaLinha(int[,] tabuleiroPontos, int i, int j) //Método para contar as linhas, recebe como parâmetro i e jque indicarão as posições
            {                                                           //no tabuleiro
                int soma = 0;


                for (int k = 0; k < 3; k++)
                {
                    soma = soma + tabuleiroPontos[i, j];
                    j++;

                }

                return soma;
            }

            public int contaColuna(int[,] tabuleiroPontos, int i, int j)  //Método para contar as colunas, recebe como parâmetro i e j que indicarão as posições
            {                                                             //no tabuleiro
                int soma = 0;


                for (int k = 0; k < 3; k++)
                {
                    soma = soma + tabuleiroPontos[i, j];
                    i++;
                }


                return soma;
            }


            public bool Venceu(int[,] tabuleiroPontos)  //Método para saber se existe um vencedor
            {
                int i = 0;
                int j = 0;



                if (contaLinha(tabuleiroPontos, i, j) == 3 || contaLinha(tabuleiroPontos, i, j) == -3) //Checa a linha 0 para ver se tem 3 números iguais
                {
                    return true;
                }
                else
                {
                    if (contaColuna(tabuleiroPontos, i, j) == 3 || contaColuna(tabuleiroPontos, i, j) == -3)  //Se não tiver checa a coluna 0 
                    {
                        return true;
                    }
                    else //Se ainda não tiver encontrado 3 números iguais 
                    {
                        i = 1;
                        if (contaLinha(tabuleiroPontos, i, j) == 3 || contaLinha(tabuleiroPontos, i, j) == -3)  //Checa a linha 1
                        {
                            return true;
                        }
                        else
                        {
                            j = 1;
                            i = 0;
                            if (contaColuna(tabuleiroPontos, i, j) == 3 || contaColuna(tabuleiroPontos, i, j) == -3) //Checa a coluna 1
                            {
                                return true;
                            }
                            else
                            {
                                i = 2;
                                j = 0;
                                if (contaLinha(tabuleiroPontos, i, j) == 3 || contaLinha(tabuleiroPontos, i, j) == -3)  //Checa a linha 2
                                {
                                    return true;
                                }
                                else
                                {
                                    j = 2;
                                    i = 0;
                                    if (contaColuna(tabuleiroPontos, i, j) == 3 || contaColuna(tabuleiroPontos, i, j) == -3)  //Checa a coluna 2, até aqui já checou todas as linhas e 
                                    {                                                                                         //todas as colunas
                                        return true;   //OK
                                    }
                                    else
                                    {
                                        //CHECANDO DIAGONAIS

                                        int soma = 0;
                                        soma = tabuleiroPontos[0, 0] + tabuleiroPontos[1, 1] + tabuleiroPontos[2, 2];


                                        if (soma == 3 || soma == -3)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            soma = tabuleiroPontos[2, 0] + tabuleiroPontos[1, 1] + tabuleiroPontos[0, 2];
                                            if (soma == 3 || soma == -3)
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false; //Não encontrou nehum campeão
                                            }
                                        }

                                    }
                                }
                            }
                        }

                    }
                }




                return false;
            }



            //O método Venceu() diz se alguém já venceu durante o jogo, o método quemVenceu diz quem venceu, X ou O.
            //X = 1 e O = -3, então se tiver 3 Xs seguidos em qualquer ocasião, o resultado vai ser 3, e se tiver 3 Os seguidas o resultado será -3.
            //Se tiver qualquer outro resultado, será empate.
            public void quemVenceu(int[,] tabuleiroPontos)
            {
                int i = 0;
                int j = 0;



                if (contaLinha(tabuleiroPontos, i, j) == 3) //Checa a linha 0 para ver se tem 3 números(1) que é o valor de X seguidos, cuja soma é 3.
                {
                    Console.WriteLine("Vencedor: Jogador1 (X)");

                }
                else
                {
                    if (contaLinha(tabuleiroPontos, i, j) == -3) //Checa a linha 0 para ver se tem 3 números(-1) que é o valor de O seguidos, cuja soma é -3.
                    {
                        Console.WriteLine("Vencedor: Jogador2 (O)");

                    }
                    else
                    {
                        if (contaColuna(tabuleiroPontos, i, j) == 3)  //Checa a coluna 0 para ver se tem 3 números(1) que é o valor de X seguidos, cuja soma é 3.
                        {
                            Console.WriteLine("Vencedor: Jogador1 (X)");

                        }
                        else
                        {
                            if (contaColuna(tabuleiroPontos, i, j) == -3)  //Checa a coluna 0 para ver se tem 3 números(-1) que é o valor de O seguidos, cuja soma é -3.
                            {
                                Console.WriteLine("Vencedor: Jogador2 (O)");

                            }
                            else //Se ainda não tiver encontrado 3 números iguais 
                            {
                                i = 1;
                                if (contaLinha(tabuleiroPontos, i, j) == 3)  //Checa a linha 1 para ver se tem 3 números(1) que é o valor de X seguidos, cuja soma é 3.
                                {
                                    Console.WriteLine("Vencedor: Jogador1 (X)");

                                }
                                else
                                {
                                    if (contaLinha(tabuleiroPontos, i, j) == -3)  //Checa a linha 1 para ver se tem 3 números(-1) que é o valor de O seguidos, cuja soma é -3.
                                    {
                                        Console.WriteLine("Vencedor: Jogador2 (O)");

                                    }
                                    else
                                    {
                                        j = 1;
                                        i = 0;
                                        if (contaColuna(tabuleiroPontos, i, j) == 3) //Checa a coluna 1 para ver se tem 3 números(1) que é o valor de X seguidos, cuja soma é 3.
                                        {
                                            Console.WriteLine("Vencedor: Jogador1 (X)");

                                        }
                                        else
                                        {
                                            if (contaColuna(tabuleiroPontos, i, j) == -3) //Checa a coluna 1 para ver se tem 3 números(-1) que é o valor de O seguidos, cuja soma é -3.
                                            {
                                                Console.WriteLine("Vencedor: Jogador2 (O)");

                                            }
                                            else
                                            {
                                                i = 2;
                                                j = 0;
                                                if (contaLinha(tabuleiroPontos, i, j) == 3)  //Checa a linha 2 para ver se tem 3 números(1) que é o valor de X seguidos, cuja soma é 3.
                                                {
                                                    Console.WriteLine("Vencedor: Jogador1 (X)");

                                                }
                                                else
                                                {
                                                    if (contaLinha(tabuleiroPontos, i, j) == -3) //Checa a linha 2 para ver se tem 3 números(-1) que é o valor de O seguidos, cuja soma é -3.
                                                    {
                                                        Console.WriteLine("Vencedor: Jogador2 (O)");

                                                    }
                                                    else
                                                    {
                                                        j = 2;
                                                        i = 0;
                                                        if (contaColuna(tabuleiroPontos, i, j) == 3)  //Checa a coluna 2 para ver se tem 3 números(1) que é o valor de X seguidos, cuja soma é 3.
                                                        {
                                                            Console.WriteLine("Vencedor: Jogador1 (X)");               //OK

                                                        }
                                                        else
                                                        {
                                                            if (contaColuna(tabuleiroPontos, i, j) == -3)  //Checa a coluna 2 para ver se tem 3 números(-1) que é o valor de O seguidos, cuja soma é -3.
                                                            {
                                                                Console.WriteLine("Vencedor: Jogador2 (O)");

                                                            }
                                                            else
                                                            {
                                                                //CHECANDO DIAGONAIS
                                                                //Checou todas as linhas e todas as coluna e ainda não encontrou um vencedor, checa as diagonais
                                                                int soma = 0;
                                                                soma = tabuleiroPontos[0, 0] + tabuleiroPontos[1, 1] + tabuleiroPontos[2, 2];


                                                                if (soma == 3)  //CHECANDO A PRIMEIRA DIAGONAL
                                                                {
                                                                    Console.WriteLine("Vencedor: Jogador1 (X)");

                                                                }
                                                                else
                                                                {
                                                                    if (soma == -3)
                                                                    {
                                                                        Console.WriteLine("Vencedor: Jogador2 (O)");

                                                                    }
                                                                    else
                                                                    {  //CHECANDO A SEGUNDA DIAGONAL
                                                                        soma = tabuleiroPontos[2, 0] + tabuleiroPontos[1, 1] + tabuleiroPontos[0, 2];
                                                                        if (soma == 3)
                                                                        {
                                                                            Console.WriteLine("Vencedor: Jogador1 (X)");

                                                                        }
                                                                        else
                                                                        {
                                                                            if (soma == -3)
                                                                            {
                                                                                Console.WriteLine("Vencedor: Jogador2 (O)");

                                                                            }
                                                                            else  //Se depois de percorrer tudo, não encontrar nenhum campeão, significa que o jogo terminou empatado.
                                                                            {
                                                                                Console.WriteLine("JOGO EMPATADO");

                                                                            }
                                                                        }

                                                                    }
                                                                }


                                                            }
                                                        }

                                                    }
                                                }

                                            }
                                        }

                                    }

                                }
                            }
                        }
                    }


                }
            }




            public int Confere(int marcar)//Método para Caso o usuário digite um número inválido, o programa repete até ser digitado um número válido
            {
                if (marcar < 1 || marcar > 9)
                {
                    Console.WriteLine("Opção inválida, o número deve ser um número de 1 a 9 que não esteja marcado. Tecle ENTER para tentar novamente");
                    Console.ReadKey();

                }

                return marcar;
            }

            
        }



        #region classeJogador
        //Classe Jogador 
        public class Jogador : Tabuleiro
        {

            public void jogadorvsJogador(string[,] tabuleiroFachada, int[,] tabuleiroPosicoes, int[,] tabuleiroPontos) //caso o usuário digite 1, o modo de jogo é jogador contra jogador
            {
                int marcar = 0;
                int jogador = 1;
                int contagem = 0;



                //Tabuleiro que vai aparecer na tela
                tabuleiroFachada[0, 0] = "1";
                tabuleiroFachada[0, 1] = "2";
                tabuleiroFachada[0, 2] = "3";
                tabuleiroFachada[1, 0] = "4";
                tabuleiroFachada[1, 1] = "5";
                tabuleiroFachada[1, 2] = "6";
                tabuleiroFachada[2, 0] = "7";
                tabuleiroFachada[2, 1] = "8";
                tabuleiroFachada[2, 2] = "9";



                //Tabuleiro onde estão as posições que vão ser ocupadas
                tabuleiroPosicoes[0, 0] = 1;
                tabuleiroPosicoes[0, 1] = 2;
                tabuleiroPosicoes[0, 2] = 3;
                tabuleiroPosicoes[1, 0] = 4;
                tabuleiroPosicoes[1, 1] = 5;
                tabuleiroPosicoes[1, 2] = 6;
                tabuleiroPosicoes[2, 0] = 7;
                tabuleiroPosicoes[2, 1] = 8;
                tabuleiroPosicoes[2, 2] = 9;

                //Tabulero onde vai se contar os pontose decidir o vencedor ou empate
                //0 índica que a posição está vazia
                //1 indica que a posição está ocupada por X
                //-1 indica que a posição está ocupada por O
                tabuleiroPontos[0, 0] = 0;
                tabuleiroPontos[0, 1] = 0;
                tabuleiroPontos[0, 2] = 0;
                tabuleiroPontos[1, 0] = 0;
                tabuleiroPontos[1, 1] = 0;
                tabuleiroPontos[1, 2] = 0;   //Todos estão definidos com 0 porque no começo todos os espaços do tabuleiro estão vazios
                tabuleiroPontos[2, 0] = 0;
                tabuleiroPontos[2, 1] = 0;
                tabuleiroPontos[2, 2] = 0;



                do
                {

                    Console.Clear();
                    Console.WriteLine("VOCÊ ESCOLHEU JOGADOR VS JOGADOR");
                    Console.WriteLine("\t");
                    Console.WriteLine("Digite o número que está na posição onde deseja marcar: ");
                    Console.WriteLine("\t");
                    Console.WriteLine(tabuleiroFachada[0, 0] + " | " + tabuleiroFachada[0, 1] + " | " + tabuleiroFachada[0, 2]);
                    Console.WriteLine("----------");
                    Console.WriteLine(tabuleiroFachada[1, 0] + " | " + tabuleiroFachada[1, 1] + " | " + tabuleiroFachada[1, 2]);
                    Console.WriteLine("----------");
                    Console.WriteLine(tabuleiroFachada[2, 0] + " | " + tabuleiroFachada[2, 1] + " | " + tabuleiroFachada[2, 2]);
                    Console.WriteLine("\t");
                    marcar = int.Parse(Console.ReadLine());



                    Confere(marcar); //Conferindo se o número digitado é válido


                    #region repetição para achar a posição desejada
                    for (int i = 0; i < 3; i++) //Programa vai percorrer a matriz tabuleiroFachada até encontrar a posição que foi selecionada
                    {
                        if (tabuleiroPosicoes[i, 0] == marcar) //PERCORRE A PRIMEIRA COLUNA
                        {


                            if (jogador == 1) //Se for a vez do jogador 1
                            {
                                if (tabuleiroPontos[i, 0] != 0)
                                {

                                    Console.WriteLine("Essa posição já está marcada, tecle ENTER para escolher outra:"); //Caso a posição já esteja marcado
                                    Console.ReadKey();

                                }
                                else
                                {
                                    tabuleiroPontos[i, 0] = 1; //Ocupando a posição que foi selecionada
                                    tabuleiroFachada[i, 0] = "X";
                                    jogador++; //variável jogador fica igual a 2, avançando para o jogador 2
                                    contagem++;

                                    if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                    {
                                        if (Venceu(tabuleiroPontos) == true)
                                        {

                                            Console.WriteLine("\a");
                                            Console.Clear();
                                            Console.WriteLine("\t");
                                            quemVenceu(tabuleiroPontos);
                                            mostraTabuleiro(tabuleiroFachada);
                                            Console.ReadKey();
                                            Environment.Exit(0);
                                        }
                                    }
                                }
                            }
                            else   //Senão, vai ser o jogador 2
                            {
                                if (tabuleiroPontos[i, 0] != 0)
                                {

                                    Console.WriteLine("Essa posição já está marcada, tecle ENTER para escolher outra:"); //Caso a posição já esteja marcado
                                    Console.ReadKey();

                                }
                                else
                                {

                                    tabuleiroPontos[i, 0] = -1; //Ocupando a posição que foi selecionada
                                    tabuleiroFachada[i, 0] = "O";
                                    jogador--; //variável jogador volta a ser 1, avançando para o jogador 1
                                    contagem++;

                                    if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                    {
                                        if (Venceu(tabuleiroPontos) == true)
                                        {
                                            Console.WriteLine("\a");
                                            Console.Clear();
                                            Console.WriteLine("\t");
                                            quemVenceu(tabuleiroPontos);
                                            mostraTabuleiro(tabuleiroFachada);
                                            Console.ReadKey();
                                            Environment.Exit(0);
                                        }
                                    }
                                }
                            }


                        }
                        else     //SE NÃO ACHAR A POSIÇÃO DESEJADA NA PRIMEIRA COLUNA, PERCORRE A SEGUNDA COLUNA
                        {
                            if (tabuleiroPosicoes[i, 1] == marcar)
                            {

                                if (jogador == 1) //Se for a vez do jogador 1
                                {
                                    if (tabuleiroPontos[i, 1] != 0)
                                    {
                                        Console.WriteLine("Essa posição já está marcada, tecle ENTER para escolher outra:"); //Caso a posição já esteja marcado
                                        Console.ReadKey();

                                    }
                                    else
                                    {

                                        tabuleiroPontos[i, 1] = 1; //Ocupando a posição que foi selecionada
                                        tabuleiroFachada[i, 1] = "X";
                                        jogador++; //variável jogador fica igual a 2, avançando para o jogador 2
                                        contagem++;

                                        if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                        {
                                            if (Venceu(tabuleiroPontos) == true)
                                            {
                                                Console.WriteLine("\a");
                                                Console.Clear();
                                                Console.WriteLine("\t");
                                                quemVenceu(tabuleiroPontos);
                                                mostraTabuleiro(tabuleiroFachada);
                                                Console.ReadKey();
                                                Environment.Exit(0);
                                            }
                                        }
                                    }
                                }
                                else   //Senão, vai ser o jogador 2
                                {
                                    if (tabuleiroPontos[i, 1] != 0)
                                    {

                                        Console.WriteLine("Essa posição já está marcada, tecle ENTER para escolher outra:"); //Caso a posição já esteja marcado
                                        Console.ReadKey();

                                    }
                                    else
                                    {

                                        tabuleiroPontos[i, 1] = -1; //Ocupando a posição que foi selecionada
                                        tabuleiroFachada[i, 1] = "O";
                                        jogador--; //variável jogador volta a ser 1, avançando para o jogador 1
                                        contagem++;

                                        if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                        {
                                            if (Venceu(tabuleiroPontos) == true)
                                            {
                                                Console.WriteLine("\a");
                                                Console.Clear();
                                                Console.WriteLine("\t");
                                                quemVenceu(tabuleiroPontos);
                                                mostraTabuleiro(tabuleiroFachada);
                                                Console.ReadKey();
                                                Environment.Exit(0);
                                            }
                                        }
                                    }
                                }

                            }
                            else   //PERCORRE A TERCEIRA COLUNA PROCURANDO A POSIÇÃO DESEJADA SE NÃO TIVER ENCONTRADO NAS DUAS ANTERIORES
                            {
                                if (tabuleiroPosicoes[i, 2] == marcar)
                                {

                                    if (jogador == 1) //Se for a vez do jogador 1
                                    {
                                        if (tabuleiroPontos[i, 2] != 0)
                                        {
                                            Console.WriteLine("Essa posição já está marcada, tecle ENTER para escolher outra:"); //Caso a posição já esteja marcado
                                            Console.ReadKey();

                                        }
                                        else
                                        {
                                            tabuleiroPontos[i, 2] = 1; //Ocupando a posição que foi selecionada
                                            tabuleiroFachada[i, 2] = "X";
                                            jogador++; //variável jogador fica igual a 2, avançando para o jogador 2
                                            contagem++;

                                            if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                            {
                                                if (Venceu(tabuleiroPontos) == true)
                                                {
                                                    Console.WriteLine("\a");
                                                    Console.Clear();
                                                    Console.WriteLine("\t");
                                                    quemVenceu(tabuleiroPontos);
                                                    mostraTabuleiro(tabuleiroFachada);
                                                    Console.ReadKey();
                                                    Environment.Exit(0);
                                                }
                                            }
                                        }
                                    }
                                    else  //Senão, vai ser o jogador 2
                                    {
                                        if (tabuleiroPontos[i, 2] != 0)
                                        {

                                            Console.WriteLine("Essa posição já está marcada, tecle ENTER para escolher outra:"); //Caso a posição já esteja marcado
                                            Console.ReadKey();

                                        }
                                        else
                                        {
                                            tabuleiroPontos[i, 2] = -1; //Ocupando a posição que foi selecionada
                                            tabuleiroFachada[i, 2] = "O";
                                            jogador--; //variável jogador volta a ser 1, avançando para o jogador 1
                                            contagem++;

                                            if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                            {
                                                if (Venceu(tabuleiroPontos) == true)
                                                {
                                                    Console.WriteLine("\a");
                                                    Console.Clear();
                                                    Console.WriteLine("\t");
                                                    quemVenceu(tabuleiroPontos);
                                                    mostraTabuleiro(tabuleiroFachada);
                                                    Console.ReadKey();
                                                    Environment.Exit(0);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }




                } while (contagem < 9);  //Repetindo tudo isso até todas as posições serem preenchidas.


                Console.Clear();
                Console.WriteLine("\t");
                Console.WriteLine(tabuleiroFachada[0, 0] + " | " + tabuleiroFachada[0, 1] + " | " + tabuleiroFachada[0, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(tabuleiroFachada[1, 0] + " | " + tabuleiroFachada[1, 1] + " | " + tabuleiroFachada[1, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(tabuleiroFachada[2, 0] + " | " + tabuleiroFachada[2, 1] + " | " + tabuleiroFachada[2, 2]);
                Console.Clear();
                Console.WriteLine("\t");
                quemVenceu(tabuleiroPontos);
                mostraTabuleiro(tabuleiroFachada);



                #endregion


                Console.ReadKey();
            }

            public void automatico() //caso o usuário digite 2, o modo de jogo é automático, onde o usuário escolhe entre jogador contra máquina  ou 
            {                               //máquina contra máquina
                int esc = 0;
                Console.Clear();
                Console.WriteLine("VOCÊ ESCOLHEU O MODO AUTOMÁTICO");
                Console.WriteLine("\t");
                Console.WriteLine("Escolha a opção de jogo: ");
                Console.WriteLine("Tecle 1 para: Usuário vs Máquina");
                Console.WriteLine("Tecle 2 para: Máquina vs Máquina");
                esc = int.Parse(Console.ReadLine());


                if (esc != 1 && esc != 2) //se mn for um resultado inválido(diferente de 1 ou 2) o usuário digita novamente até ser um número válido
                {
                    while (esc != 1 && esc != 2)
                    {

                        Console.Clear(); //Limpando a tela
                        Console.WriteLine("Opção inválida, Tente novamente: "); //Fazendo o usuário digitar de novo caso não tenha digitado as opções válidas, "1" ou "2"
                        automatico();


                        if (esc == 1) //quando o usuário digitar 1 vai para o modo de jogo Jogador vs Máquina chamando o método jogadorvsMaquina()
                        {
                            jogadorvsMaquina(tabuleiroFachada, tabuleiroPosicoes, tabuleiroPontos);
                        }
                        if (esc == 2) //quando o usuário digitar 2 vai para o modo de jogo máquina vs máquina chamando o método maquinavsMaquina()
                        {
                            maquinavsMaquina(tabuleiroFachada, tabuleiroPosicoes, tabuleiroPosicoes);
                        }

                    }
                }
                else
                {
                    if (esc == 1) //quando o usuário digitar 1 vai para o modo de jogo Jogador vs Maquina chamando o método jogadorvsMaquina()
                    {
                        jogadorvsMaquina(tabuleiroFachada, tabuleiroPosicoes, tabuleiroPontos);
                    }
                    if (esc == 2) //quando o usuário digitar 2 vai para o modo de jogo maquina vs maquina chamando o método maquinavsMaquina()
                    {
                        maquinavsMaquina(tabuleiroFachada, tabuleiroPosicoes, tabuleiroPontos);
                    }

                }
            }



            public static void jogadorvsMaquina(string[,] tabuleiroFachada, int[,] tabuleiroPosicoes, int[,] tabuleiroPontos)
            {
                Tabuleiro t = new Tabuleiro();
                int marcar = 0;
                int jogador = 1;
                int contagem = 0;
                Random R = new Random(); //Declarando a variável R que vai gerar números aleatórios para marcar no tabuleiro quando for a vez da máquina jogar.


                //Tabuleiro que vai aparecer na tela
                tabuleiroFachada[0, 0] = "1";
                tabuleiroFachada[0, 1] = "2";
                tabuleiroFachada[0, 2] = "3";
                tabuleiroFachada[1, 0] = "4";
                tabuleiroFachada[1, 1] = "5";
                tabuleiroFachada[1, 2] = "6";
                tabuleiroFachada[2, 0] = "7";
                tabuleiroFachada[2, 1] = "8";
                tabuleiroFachada[2, 2] = "9";



                //Tabuleiro onde estão as posições que vão ser ocupadas
                tabuleiroPosicoes[0, 0] = 1;
                tabuleiroPosicoes[0, 1] = 2;
                tabuleiroPosicoes[0, 2] = 3;
                tabuleiroPosicoes[1, 0] = 4;
                tabuleiroPosicoes[1, 1] = 5;
                tabuleiroPosicoes[1, 2] = 6;
                tabuleiroPosicoes[2, 0] = 7;
                tabuleiroPosicoes[2, 1] = 8;
                tabuleiroPosicoes[2, 2] = 9;

                //Tabulero onde vai se contar os pontos e decidir o vencedor ou empate
                //0 índica que a posição está vazia
                //1 indica que a posição está ocupada por X
                //-1 indica que a posição está ocupada por O
                tabuleiroPontos[0, 0] = 0;
                tabuleiroPontos[0, 1] = 0;
                tabuleiroPontos[0, 2] = 0;
                tabuleiroPontos[1, 0] = 0;
                tabuleiroPontos[1, 1] = 0;
                tabuleiroPontos[1, 2] = 0;   //Todos estão definidos com 0 porque no começo todos os espaços do tabuleiro estão vazios
                tabuleiroPontos[2, 0] = 0;
                tabuleiroPontos[2, 1] = 0;
                tabuleiroPontos[2, 2] = 0;



                do
                {

                    if (jogador == 1)
                    {

                        Console.Clear();
                        Console.WriteLine("VOCÊ ESCOLHEU MODO JOGADOR VS MÁQUINA");
                        Console.WriteLine("\t");
                        Console.WriteLine("Digite o número que está na posição onde deseja marcar: ");
                        Console.WriteLine("\t");
                        Console.WriteLine(tabuleiroFachada[0, 0] + " | " + tabuleiroFachada[0, 1] + " | " + tabuleiroFachada[0, 2]);
                        Console.WriteLine("----------");
                        Console.WriteLine(tabuleiroFachada[1, 0] + " | " + tabuleiroFachada[1, 1] + " | " + tabuleiroFachada[1, 2]);
                        Console.WriteLine("----------");
                        Console.WriteLine(tabuleiroFachada[2, 0] + " | " + tabuleiroFachada[2, 1] + " | " + tabuleiroFachada[2, 2]);
                        Console.WriteLine("\t");
                        marcar = int.Parse(Console.ReadLine());
                    }
                    else //Se for a vez da máquina(Jogador == 2)
                    {
                        marcar = R.Next(1, 10); //Gerando um número aleatório de 1 a 9 para marcar



                    }


                    t.Confere(marcar); //Conferindo se o número digitado é válido


                    #region repetição para achar a posição desejada
                    for (int i = 0; i < 3; i++) //Programa vai percorrer a matriz tabuleiroFachada até encontrar a posição que foi selecionada
                    {
                        if (tabuleiroPosicoes[i, 0] == marcar) //PERCORRE A PRIMEIRA COLUNA
                        {


                            if (jogador == 1) //Se for a vez do jogador 1
                            {
                                if (tabuleiroPontos[i, 0] != 0)
                                {

                                    Console.WriteLine("Essa posição já está marcada, tecle ENTER para escolher outra:"); //Caso a posição já esteja marcado
                                    Console.ReadKey();

                                }
                                else
                                {
                                    tabuleiroPontos[i, 0] = 1; //Ocupando a posição que foi selecionada
                                    tabuleiroFachada[i, 0] = "X";
                                    jogador++; //variável jogador fica igual a 2, avançando para o jogador 2
                                    contagem++;

                                    if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                    {
                                        if (t.Venceu(tabuleiroPontos) == true)
                                        {

                                            Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                            Console.Clear();
                                            Console.WriteLine("\t");
                                            t.quemVenceu(tabuleiroPontos);
                                            t.mostraTabuleiro(tabuleiroFachada);
                                            Console.ReadKey();
                                            Environment.Exit(0);
                                        }
                                    }
                                }
                            }
                            else   //Senão, vai ser o jogador 2
                            {

                                if (tabuleiroPontos[i, 0] != 0)
                                {                                        //Caso o valor gerado aleatoriamente já esteja marcado, vai gerar um novo número aleatório até ocupar uma
                                                                         //posição que esteja válida
                                    marcar = R.Next(1, 10);


                                }
                                else
                                {

                                    tabuleiroPontos[i, 0] = -1; //Ocupando a posição que foi selecionada
                                    tabuleiroFachada[i, 0] = "O";
                                    jogador--; //variável jogador volta a ser 1, avançando para o jogador 1
                                    contagem++;

                                    if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                    {
                                        if (t.Venceu(tabuleiroPontos) == true)
                                        {
                                            Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                            Console.Clear();
                                            Console.WriteLine("\t");
                                            t.quemVenceu(tabuleiroPontos);
                                            t.mostraTabuleiro(tabuleiroFachada);
                                            Console.ReadKey();
                                            Environment.Exit(0);
                                        }
                                    }
                                }
                            }


                        }
                        else     //SE NÃO ACHAR A POSIÇÃO DESEJADA NA PRIMEIRA COLUNA, PERCORRE A SEGUNDA COLUNA
                        {
                            if (tabuleiroPosicoes[i, 1] == marcar)
                            {

                                if (jogador == 1) //Se for a vez do jogador 1
                                {
                                    if (tabuleiroPontos[i, 1] != 0)
                                    {
                                        Console.WriteLine("Essa posição já está marcada, tecle ENTER para escolher outra:"); //Caso a posição já esteja marcado
                                        Console.ReadKey();

                                    }
                                    else
                                    {

                                        tabuleiroPontos[i, 1] = 1; //Ocupando a posição que foi selecionada
                                        tabuleiroFachada[i, 1] = "X";
                                        jogador++; //variável jogador fica igual a 2, avançando para o jogador 2
                                        contagem++;

                                        if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                        {
                                            if (t.Venceu(tabuleiroPontos) == true)
                                            {
                                                Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                                Console.Clear();
                                                Console.WriteLine("\t");
                                                t.quemVenceu(tabuleiroPontos);
                                                t.mostraTabuleiro(tabuleiroFachada);
                                                Console.ReadKey();
                                                Environment.Exit(0);
                                            }
                                        }
                                    }
                                }
                                else   //Senão, vai ser o jogador 2
                                {
                                    if (tabuleiroPontos[i, 1] != 0)       //Caso o valor gerado aleatoriamente já esteja marcado, vai gerar um novo número aleatório até ocupar uma
                                    {                                     //Posição que seja válida

                                        marcar = R.Next(1, 10);
                                    }
                                    else
                                    {

                                        tabuleiroPontos[i, 1] = -1; //Ocupando a posição que foi selecionada
                                        tabuleiroFachada[i, 1] = "O";
                                        jogador--; //variável jogador volta a ser 1, avançando para o jogador 1
                                        contagem++;

                                        if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                        {
                                            if (t.Venceu(tabuleiroPontos) == true)
                                            {
                                                Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                                Console.Clear();
                                                Console.WriteLine("\t");
                                                t.quemVenceu(tabuleiroPontos);
                                                t.mostraTabuleiro(tabuleiroFachada);
                                                Console.ReadKey();
                                                Environment.Exit(0);
                                            }
                                        }
                                    }
                                }

                            }
                            else   //PERCORRE A TERCEIRA COLUNA PROCURANDO A POSIÇÃO DESEJADA SE NÃO TIVER ENCONTRADO NAS DUAS ANTERIORES
                            {
                                if (tabuleiroPosicoes[i, 2] == marcar)
                                {

                                    if (jogador == 1) //Se for a vez do jogador 1
                                    {
                                        if (tabuleiroPontos[i, 2] != 0)
                                        {
                                            Console.WriteLine("Essa posição já está marcada, tecle ENTER para escolher outra:"); //Caso a posição já esteja marcado
                                            Console.ReadKey();

                                        }
                                        else
                                        {
                                            tabuleiroPontos[i, 2] = 1; //Ocupando a posição que foi selecionada
                                            tabuleiroFachada[i, 2] = "X";
                                            jogador++; //variável jogador fica igual a 2, avançando para o jogador 2
                                            contagem++;

                                            if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                            {
                                                if (t.Venceu(tabuleiroPontos) == true)
                                                {
                                                    Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                                    Console.Clear();
                                                    Console.WriteLine("\t");
                                                    t.quemVenceu(tabuleiroPontos);
                                                    t.mostraTabuleiro(tabuleiroFachada);
                                                    Console.ReadKey();
                                                    Environment.Exit(0);
                                                }
                                            }
                                        }
                                    }
                                    else  //Senão, vai ser o jogador 2
                                    {
                                        if (tabuleiroPontos[i, 2] != 0)
                                        {
                                            marcar = R.Next(1, 10);

                                        }
                                        else
                                        {
                                            tabuleiroPontos[i, 2] = -1; //Ocupando a posição que foi selecionada
                                            tabuleiroFachada[i, 2] = "O";
                                            jogador--; //variável jogador volta a ser 1, avançando para o jogador 1
                                            contagem++;

                                            if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                            {
                                                if (t.Venceu(tabuleiroPontos) == true)
                                                {
                                                    Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                                    Console.Clear();
                                                    Console.WriteLine("\t");
                                                    t.quemVenceu(tabuleiroPontos);
                                                    t.mostraTabuleiro(tabuleiroFachada);
                                                    Console.ReadKey();
                                                    Environment.Exit(0);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }






                } while (contagem < 9);  //Repetindo tudo isso até todas as posições serem preenchidas.


                Console.Clear();
                Console.WriteLine("\t");
                Console.WriteLine(tabuleiroFachada[0, 0] + " | " + tabuleiroFachada[0, 1] + " | " + tabuleiroFachada[0, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(tabuleiroFachada[1, 0] + " | " + tabuleiroFachada[1, 1] + " | " + tabuleiroFachada[1, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(tabuleiroFachada[2, 0] + " | " + tabuleiroFachada[2, 1] + " | " + tabuleiroFachada[2, 2]);
                Console.Clear();
                Console.WriteLine("\t");
                t.quemVenceu(tabuleiroPontos);
                t.mostraTabuleiro(tabuleiroFachada);



                #endregion



                Console.ReadKey();
            }

            public static void maquinavsMaquina(string[,] tabuleiroFachada, int[,] tabuleiroPosicoes, int[,] tabuleiroPontos)
            {
                Tabuleiro t = new Tabuleiro();
                int marcar = 0;
                int jogador = 1;
                int contagem = 0;
                Random R = new Random(); //Declarando a variável R que vai gerar números aleatórios para marcar no tabuleiro quando for a vez da máquina jogar.


                //Tabuleiro que vai aparecer na tela
                tabuleiroFachada[0, 0] = "1";
                tabuleiroFachada[0, 1] = "2";
                tabuleiroFachada[0, 2] = "3";
                tabuleiroFachada[1, 0] = "4";
                tabuleiroFachada[1, 1] = "5";
                tabuleiroFachada[1, 2] = "6";
                tabuleiroFachada[2, 0] = "7";
                tabuleiroFachada[2, 1] = "8";
                tabuleiroFachada[2, 2] = "9";



                //Tabuleiro onde estão as posições que vão ser ocupadas
                tabuleiroPosicoes[0, 0] = 1;
                tabuleiroPosicoes[0, 1] = 2;
                tabuleiroPosicoes[0, 2] = 3;
                tabuleiroPosicoes[1, 0] = 4;
                tabuleiroPosicoes[1, 1] = 5;
                tabuleiroPosicoes[1, 2] = 6;
                tabuleiroPosicoes[2, 0] = 7;
                tabuleiroPosicoes[2, 1] = 8;
                tabuleiroPosicoes[2, 2] = 9;

                //Tabulero onde vai se contar os pontos e decidir o vencedor ou empate
                //0 índica que a posição está vazia
                //1 indica que a posição está ocupada por X
                //-1 indica que a posição está ocupada por O
                tabuleiroPontos[0, 0] = 0;
                tabuleiroPontos[0, 1] = 0;
                tabuleiroPontos[0, 2] = 0;
                tabuleiroPontos[1, 0] = 0;
                tabuleiroPontos[1, 1] = 0;
                tabuleiroPontos[1, 2] = 0;   //Todos estão definidos com 0 porque no começo todos os espaços do tabuleiro estão vazios
                tabuleiroPontos[2, 0] = 0;
                tabuleiroPontos[2, 1] = 0;
                tabuleiroPontos[2, 2] = 0;

                

                do
                {
                    Console.Clear();
                    Console.WriteLine("VOCÊ ESCOLHEU MODO MÁQUINA VS MÁQUINA");
                    Console.WriteLine("\t");
                    Console.WriteLine("Tecle ENTER para próxima rodada: ");
                    Console.WriteLine("\t");
                    Console.WriteLine(tabuleiroFachada[0, 0] + " | " + tabuleiroFachada[0, 1] + " | " + tabuleiroFachada[0, 2]);
                    Console.WriteLine("----------");
                    Console.WriteLine(tabuleiroFachada[1, 0] + " | " + tabuleiroFachada[1, 1] + " | " + tabuleiroFachada[1, 2]);
                    Console.WriteLine("----------");
                    Console.WriteLine(tabuleiroFachada[2, 0] + " | " + tabuleiroFachada[2, 1] + " | " + tabuleiroFachada[2, 2]);
                    

                    marcar = R.Next(1, 9); //Gerando um número aleatório de 1 a 9 para marcar




                    t.Confere(marcar); //Conferindo se o número digitado é válido


                    #region repetição para achar a posição desejada
                    for (int i = 0; i < 3; i++) //Programa vai percorrer a matriz tabuleiroFachada até encontrar a posição que foi selecionada
                    {
                        if (tabuleiroPosicoes[i, 0] == marcar) //PERCORRE A PRIMEIRA COLUNA
                        {


                            if (jogador == 1) //Se for a vez do jogador 1
                            {
                                if (tabuleiroPontos[i, 0] != 0)
                                {
                                    marcar = R.Next(1, 10);           //Caso o valor gerado aleatoriamente já esteja marcado, vai gerar um novo número aleatório até ocupar uma
                                                                                       //posição que esteja válida
                                    

                                }
                                else
                                {
                                    tabuleiroPontos[i, 0] = 1; //Ocupando a posição que foi selecionada
                                    tabuleiroFachada[i, 0] = "X";
                                    jogador++; //variável jogador fica igual a 2, avançando para o jogador 2
                                    contagem++;

                                    if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                    {
                                        if (t.Venceu(tabuleiroPontos) == true)
                                        {

                                            Console.WriteLine("\a"); //Soltando um Bip pra alertar que alguém já venceu
                                            Console.Clear();
                                            Console.WriteLine("\t");
                                            t.quemVenceu(tabuleiroPontos);
                                            t.mostraTabuleiro(tabuleiroFachada);
                                            Console.ReadKey();
                                            Environment.Exit(0);
                                        }
                                    }
                                }
                            }
                            else   //Senão, vai ser o jogador 2
                            {

                                if (tabuleiroPontos[i, 0] != 0)
                                {                                           //Caso o valor gerado aleatoriamente já esteja marcado, vai gerar um novo número aleatório até ocupar uma
                                    marcar = R.Next(1, 10 );                     //posição que esteja válida
                                   



                                }
                                else
                                {

                                    tabuleiroPontos[i, 0] = -1; //Ocupando a posição que foi selecionada
                                    tabuleiroFachada[i, 0] = "O";
                                    jogador--; //variável jogador volta a ser 1, avançando para o jogador 1
                                    contagem++;
                                    Console.ReadKey();

                                    if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                    {
                                        if (t.Venceu(tabuleiroPontos) == true)
                                        {
                                            Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                            Console.Clear();
                                            Console.WriteLine("\t");
                                            t.quemVenceu(tabuleiroPontos);
                                            t.mostraTabuleiro(tabuleiroFachada);
                                            Console.ReadKey();
                                            Environment.Exit(0);
                                        }
                                    }
                                }
                            }


                        }
                        else     //SE NÃO ACHAR A POSIÇÃO DESEJADA NA PRIMEIRA COLUNA, PERCORRE A SEGUNDA COLUNA
                        {
                            if (tabuleiroPosicoes[i, 1] == marcar)
                            {

                                if (jogador == 1) //Se for a vez do jogador 1
                                {
                                    if (tabuleiroPontos[i, 1] != 0)
                                    {
                                       marcar = R.Next(1, 10);

                                    }
                                    else
                                    {

                                        tabuleiroPontos[i, 1] = 1; //Ocupando a posição que foi selecionada
                                        tabuleiroFachada[i, 1] = "X";
                                        jogador++; //variável jogador fica igual a 2, avançando para o jogador 2
                                        contagem++;
                                        Console.ReadKey();

                                        if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                        {
                                            if (t.Venceu(tabuleiroPontos) == true)
                                            {
                                                Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                                Console.Clear();
                                                Console.WriteLine("\t");
                                                t.quemVenceu(tabuleiroPontos);
                                                t.mostraTabuleiro(tabuleiroFachada);
                                                Console.ReadKey();
                                                Environment.Exit(0);
                                            }
                                        }
                                    }
                                }
                                else   //Senão, vai ser o jogador 2
                                {
                                    if (tabuleiroPontos[i, 1] != 0)       //Caso o valor gerado aleatoriamente já esteja marcado, vai gerar um novo número aleatório até ocupar uma
                                    {                                     //posição válida
                                        marcar = R.Next(1, 10);


                                    }
                                    else
                                    {

                                        tabuleiroPontos[i, 1] = -1; //Ocupando a posição que foi selecionada
                                        tabuleiroFachada[i, 1] = "O";
                                        jogador--; //variável jogador volta a ser 1, avançando para o jogador 1
                                        contagem++;
                                        Console.ReadKey();

                                        if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                        {
                                            if (t.Venceu(tabuleiroPontos) == true)
                                            {
                                                Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                                Console.Clear();
                                                Console.WriteLine("\t");
                                                t.quemVenceu(tabuleiroPontos);
                                                t.mostraTabuleiro(tabuleiroFachada);
                                                Console.ReadKey();
                                                Environment.Exit(0);
                                            }
                                        }
                                    }
                                }

                            }
                            else   //PERCORRE A TERCEIRA COLUNA PROCURANDO A POSIÇÃO DESEJADA SE NÃO TIVER ENCONTRADO NAS DUAS ANTERIORES
                            {
                                if (tabuleiroPosicoes[i, 2] == marcar)
                                {

                                    if (jogador == 1) //Se for a vez do jogador 1
                                    {
                                        if (tabuleiroPontos[i, 2] != 0)  //Se a posição já estiver ocupada
                                        {
                                            marcar = R.Next(1, 10);



                                            //Caso o valor gerado aleatoriamente já esteja marcado, vai gerar um novo número aleatório até ocupar uma
                                            //posição que esteja válida

                                        }
                                        else
                                        {
                                            tabuleiroPontos[i, 2] = 1; //Ocupando a posição que foi selecionada
                                            tabuleiroFachada[i, 2] = "X";
                                            jogador++; //variável jogador fica igual a 2, avançando para o jogador 2
                                            contagem++;

                                            if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                            {
                                                if (t.Venceu(tabuleiroPontos) == true)
                                                {
                                                    Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                                    Console.Clear();
                                                    Console.WriteLine("\t");
                                                    t.quemVenceu(tabuleiroPontos);
                                                    t.mostraTabuleiro(tabuleiroFachada);
                                                    Console.ReadKey();
                                                    Environment.Exit(0);
                                                }
                                            }
                                        }
                                    }
                                    else  //Senão, vai ser o jogador 2
                                    {
                                        if (tabuleiroPontos[i, 2] != 0)
                                        {
                                            marcar = R.Next(1, 10);

                                        }
                                        else
                                        {
                                            tabuleiroPontos[i, 2] = -1; //Ocupando a posição que foi selecionada
                                            tabuleiroFachada[i, 2] = "O";
                                            jogador--; //variável jogador volta a ser 1, avançando para o jogador 1
                                            contagem++;

                                            if (contagem >= 5)  //Checando se já existe um vencedor, só é possível haver um vencedor a partir da 5º rodada, por isso, contagem >= 5
                                            {
                                                if (t.Venceu(tabuleiroPontos) == true)
                                                {
                                                    Console.WriteLine("\a");  //Soltando um Bip pra alertar que alguém já venceu
                                                    Console.Clear();
                                                    Console.WriteLine("\t");
                                                    t.quemVenceu(tabuleiroPontos);
                                                    t.mostraTabuleiro(tabuleiroFachada);
                                                    Console.ReadKey();
                                                    Environment.Exit(0);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }






                } while (contagem < 9);  //Repetindo tudo isso até todas as posições serem preenchidas.


                Console.Clear();
                Console.WriteLine("\t");
                Console.WriteLine(tabuleiroFachada[0, 0] + " | " + tabuleiroFachada[0, 1] + " | " + tabuleiroFachada[0, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(tabuleiroFachada[1, 0] + " | " + tabuleiroFachada[1, 1] + " | " + tabuleiroFachada[1, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(tabuleiroFachada[2, 0] + " | " + tabuleiroFachada[2, 1] + " | " + tabuleiroFachada[2, 2]);
                Console.Clear();
                Console.WriteLine("\t");
                t.quemVenceu(tabuleiroPontos);
                t.mostraTabuleiro(tabuleiroFachada);



                #endregion



                Console.ReadKey();
            }
        }

        #endregion
        #endregion




        //*****************MÉTODOS***********

        //Método menu para escolher o modo de jogo
        static int menu()
        {
            Console.WriteLine("JOGO DA VELHA");
            Console.WriteLine("Escolha o estilo de jogo desejado: ");
            Console.WriteLine("Tecle 1 para: Jogador vs Jogador");
            Console.WriteLine("Tecle 2 para: Modo automático");
            int escolha = int.Parse(Console.ReadLine());

            return escolha;
        }

        
    }
}
