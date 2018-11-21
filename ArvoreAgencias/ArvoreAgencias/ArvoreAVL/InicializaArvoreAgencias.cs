using AVLTree;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AVLTree
{
    public class ArvoreAgencias
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
            String caminho = @"C:\Users\nara-\Documents\projeto_AED2\arquivos\contas\";

            try
            {
                foreach (var node in ListaAgencias)
                {
                    int aux = (int)(2 * Convert.ToInt32(node) / 0.00037) + 1;
                  
                    Root.Insert(Convert.ToInt32(node), caminho + aux + ".txt");
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

            ListaAgencias = arquivo.Split('\n').ToList();
        }

        public int Count()
        {
            return ListaAgencias.Count();
        }
    }
}
