using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDETxt
{
    internal class Program
    {
        static void ExibirArquivo(string arquivo)
        {
            try
            {
                string line = "";
                StreamReader sr = new StreamReader(arquivo);
                
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        static void GravarArquivo(string arquivo, string texto, bool add)
        {
            try
            {
                StreamWriter sr = new StreamWriter(arquivo, add);
                sr.WriteLine(texto);
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        static int Menu()
        {
            // Limpando console
            Console.Clear();
            // Exibindo Menu
            Console.WriteLine("# # # --- Editor de Texto --- # # #\n");

            Console.WriteLine("[1] - Abrir/Criar arquivo");
            Console.WriteLine("[2] - Exibir arquivo");
            Console.WriteLine("[3] - Gravar no arquivo");
            Console.WriteLine("[4] - Editar arquivo");
            Console.WriteLine("[5] - Finalizar Programa\n");
            
            Console.Write("Selecione uma opção: ");
            return int.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            int opcao = 0;
            string arquivo = "", texto = "";

            while (opcao != 5)
            {
                opcao = Menu();
                Console.Clear() ;

                switch(opcao)
                {
                    case 1:
                        Console.Write("Informe o nome do Arquivo: ");
                        arquivo = Console.ReadLine();
                        break;

                    case 2:
                        ExibirArquivo(arquivo);
                        break;

                    case 3:
                        Console.Write("Informe o texto: \n\n");
                        texto = Console.ReadLine();
                        GravarArquivo(arquivo, texto, false);
                        break;

                    case 4:
                        Console.Write("Informe o texto: \n\n");
                        texto = Console.ReadLine();
                        GravarArquivo(arquivo, texto, true);
                        break;
                }
            }
        }
    }
}
