using AVLTree;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AVLTree
{
    class ArvoreAgencias
    {
        List<string> ListaAgencias;
        AvlTree<int, string> Root;
        public ArvoreAgencias(string path)
        {
            InicializaArquivo(path);
        }

        public AvlTree<int, string> Inicializacao()
        {
            Root = new AvlTree<int, string>();

            try
            {
                foreach (var node in ListaAgencias)
                {
                    Root.Insert(Convert.ToInt32(node), string.Empty);
                }
                return Root;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao inserir um nó: " + ex.Message);
                return null;
            }
        }
        private void InicializaArquivo(string path)
        {
            ListaAgencias = new List<string>();
            string arquivo = System.IO.File.ReadAllText(path).Trim();
            //Console.WriteLine(arquivo);

            ListaAgencias = arquivo.Split('\n').ToList();
            //Console.WriteLine(ListaAgencias[1]);
        }
    }
}
