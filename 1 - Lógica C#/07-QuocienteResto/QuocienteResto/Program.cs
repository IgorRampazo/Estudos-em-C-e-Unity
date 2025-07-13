using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuocienteResto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Excercicio

            double n1 = 0;
            double n2 = 0;
            double rest = 0;
            double result = 0;

            Console.Write("Informe o numerador: ");
            n1 = double.Parse(Console.ReadLine());

            Console.Write("Informe o denominador: ");
            n2 = double.Parse(Console.ReadLine());

            result = n1 / n2;
            rest = n1 % n2;

            Console.WriteLine($"\nResultado final: {result}");
            Console.WriteLine($"\nResto: {rest}");
        }
    }
}
