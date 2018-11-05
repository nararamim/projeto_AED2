using AVLTree;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            ArvoreAgencias arvore = new ArvoreAgencias(@"C:\Users\Denes\Downloads\arquivos\agencias");
            AvlTree<int, string> raiz = arvore.Inicializacao();

            //Console.ReadKey();
        }
    }
}
