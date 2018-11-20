using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AVLTree
{
    class Program
    {
        static List<string> listaCorrespondencia = new List<string>();
        private static void BuscaArquivo(string conta, string diretorio)
        {
            try
            {
                IEnumerable<string> lines = File.ReadAllLines(diretorio);
                listaCorrespondencia = !String.IsNullOrEmpty(conta) ? lines.Where(line => line.Contains(conta)).ToList() : Enumerable.Empty<string>().ToList();
            } catch (Exception ex)
            {
                Console.WriteLine("O diretório indicado não existe;");
                return;
            }
        }
        private static string retornaCliente(string conta)
        {
            string cliente = conta.Split('-')[conta.Split('-').Length - 2];
            return cliente.Trim();
        }

        private static string retornaSaldoCliente(string conta)
        {
            string saldo = conta.Split('-')[conta.Split('-').Length - 1];
            return saldo.Trim();
        }
        static void Main(string[] args)
        {
            string agencia, conta, diretorio;
            int opcao;
            AvlNode<int, string> node = new AvlNode<int, string>();
            ArvoreAgencias arvore = new ArvoreAgencias(@"C:\Users\Denes\Downloads\arquivos\agencias");
            AvlTree<int, string> raiz = arvore.Inicializacao();


            Console.WriteLine("Bem-Vindo ao sistema de Agências!\n");

            while (true)
            {
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("1-Saber a quem pertence uma conta específica;");
                Console.WriteLine("2-Saber quantas contas estão vinculadas a uma agência;");
                Console.WriteLine("3-Saber quantas agências estão registradas no sistema;");
                Console.WriteLine("4-Saber qual o saldo de uma conta específica;");
                Console.WriteLine("5-Sair;");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Insira a agência que deseja buscar:");
                        agencia = Console.ReadLine().Trim();
                        Console.WriteLine("Insira a conta vinculada a esta agência que deseja buscar:");
                        conta = Console.ReadLine().Trim();

                        node = raiz.Search(int.Parse(agencia));
                        diretorio = node.Value;
                        //diretorio = @"C:\Users\Denes\Downloads\arquivos\contas\0.txt";
                        BuscaArquivo(conta, diretorio);

                        if (listaCorrespondencia.Count > 0)
                        {
                            foreach (var item in listaCorrespondencia)
                            {
                                Console.WriteLine("O cliente vinculado a essa conta é " + retornaCliente(item) + ".\n");
                            }
                        }
                        else Console.WriteLine("Não há clientes que possuem o número de conta procurado.");
                        break;
                    case 2:
                        Console.WriteLine("Insira a agência:");
                        agencia = Console.ReadLine().Trim();
                        node = raiz.Search(int.Parse(agencia));
                        diretorio = node.Value;
                        //diretorio = @"C:\Users\Denes\Downloads\arquivos\contas\0.txt";
                        int count = File.ReadAllLines(diretorio).Count();
                        Console.WriteLine("Há " + Convert.ToString(count) + " contas vinculadas a essa agência.\n");
                        break;
                    case 3:
                        Console.WriteLine("Há " + arvore.Count() + " agências vinculadas ao sistema.\n");
                        break;
                    case 4:
                        Console.WriteLine("Insira a agência que deseja buscar:");
                        agencia = Console.ReadLine().Trim();
                        Console.WriteLine("Insira a conta vinculada a esta agência que deseja buscar:");
                        conta = Console.ReadLine().Trim();

                        node = raiz.Search(int.Parse(agencia));
                        diretorio = node.Value;
                        //diretorio = @"C:\Users\Denes\Downloads\arquivos\contas\0.txt";
                        BuscaArquivo(conta, diretorio);

                        if (listaCorrespondencia.Count > 0)
                        {
                            foreach (var item in listaCorrespondencia)
                            {
                                Console.WriteLine("O cliente " + retornaCliente(item) + " possui " + retornaSaldoCliente(item)+ " em sua conta.\n");
                            }
                        }
                        else Console.WriteLine("Não há clientes que possuem o número de conta procurado.");
                        break;
                    case 5:
                        return;
                }
            }

           

            
            

            
            
            Console.ReadKey();
        }
    }
}
