using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vetor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome1 = "Igor Rampazo";
            string nome2 = "Mulequinho";

            string[] Nomes = new string[5];

            Nomes[0] = nome1;
            Nomes[1] = nome2;

            foreach (string item in Nomes)
                Console.WriteLine(item);
        }
    }
}
