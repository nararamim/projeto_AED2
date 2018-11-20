using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int agencia, conta;
            string diretorio;
            ArvoreAgencias arvore = new ArvoreAgencias(@"C:\Users\Denes\Downloads\arquivos\agencias");
            AvlTree<int, string> raiz = arvore.Inicializacao();

            Console.WriteLine("Bem-Vindo ao sistema de Agências!\nInsira a agência que deseja buscar:");
            agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a conta vinculada a esta agência que deseja buscar:");
            conta = int.Parse(Console.ReadLine());

            AvlNode<int, string> node = raiz.Search(agencia);
            diretorio = node.Value;
            //Console.WriteLine("1-Procurar por uma agência e conta no Banco de Dados;");
            //Console.WriteLine("2-Deletar uma conta do Banco de Dados;");
            //Console.ReadKey();
        }
    }
}
