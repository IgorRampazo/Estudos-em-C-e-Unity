using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condicao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age;
            bool ticket, companion;

            Console.Write("Idade: ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Você tem ingresso? (s/n): ");
            ticket = Console.ReadLine().ToLower() == "s";

            Console.Write("Você está acompanhado? (s/n): ");
            companion = Console.ReadLine().ToLower() == "s";

            if (age < 12 || age > 60)
                Console.WriteLine("\nEntrada Liberada: Gratis\n");
            else if (age >= 12 && age < 18 && companion)
                Console.WriteLine("\nEntrada Liberada: c/ Acompanhante\n");
            else if (age >= 18 && ticket)
                Console.WriteLine("\nEntrada Liberada: Maior Idade c/ Ingresso\n");
            else
                Console.WriteLine("\nEntrada Negada!\n");

            Console.ReadKey();
        }
    }
}
