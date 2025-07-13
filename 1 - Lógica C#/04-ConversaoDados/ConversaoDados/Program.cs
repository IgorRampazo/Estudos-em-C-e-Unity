using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // # # # # --- Conversão de Dados --- # # # # //

            string caracter = "1";
            int tab, i, j;

            Console.Write("Tabuada do... : ");
            tab = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nTabuada do {tab}:\n");
            for (i = 1; i <= 10; i++)
                Console.WriteLine($"{tab} x {i} = {mx(tab, i)}");
        }

        static int mx(int a, int b)
        {
            return a * b;
        }
    }
}