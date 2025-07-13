using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cont = 0;
            string resp;

            string[] perguntas =
            {
                "O q tem capa mas n voa?",
                "O q tem dentes mas n morde?",
                "O q corre e nunca se cansa?",
                "O q quanto + seca, + molhada fica?",
                "O q cai de pé e corre deitado?",
                "O q tem olhos mas n vê?",
                "O q é cheio de buracos, mas ainda assim segura água?",
                "O q tem pescoço mas n tem cabeça?",
                "O q sobe quando a chuva desce?",
                "O q pode encher uma sala sem ocupar espaço?"
            };

            string[] respostas =
            {
                "Livro",
                "Pente",
                "Rio",
                "Toalha",
                "Chuva",
                "Batata",
                "Esponja",
                "Garrafa",
                "Guarda-chuva",
                "Luz"
            };

            for (int i = 0; i < perguntas.Length; i++)
            {
                Console.Write($"{perguntas[i]}\nResp: ");
                resp = Console.ReadLine();

                if (resp.ToLower() == respostas[i].ToLower())
                    cont++;
            }

            Console.WriteLine($"\n\nNumero de Pontos: {cont}/10");
        }
    }
}
