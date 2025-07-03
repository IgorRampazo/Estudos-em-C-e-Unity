using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioAreaTriangulo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exercicio

            int a, b;

            Console.Write("Informe a base: ");
            a = int.Parse(Console.ReadLine());

            Console.Write("Informe a altura: ");
            b = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nA área do Triangulo é '{(a * b) / 2}'");
        }
    }
}
