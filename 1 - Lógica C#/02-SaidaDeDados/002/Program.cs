// _____________________________ //
// ******** Bibliotecas ******** //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// namespace: Agrupamento de Classes, Interfaces
namespace _002
{
    internal class Program
    {
        // # # # # --- Saída de Dados --- # # # # //
        static void Main(string[] args)
        {
            int n1, n2;

            Console.WriteLine("Informe a nota 1: ");
            n1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a nota 2: ");
            n2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Média de {n1} e {n2}: {(n1 + n2)/2}");
        }
    }
}